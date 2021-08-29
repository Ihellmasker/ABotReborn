using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;

namespace ABotReborn
{
  class Irc
  {
    private MainForm myForm;
    private String nick, password, channel, currency, admin, user = "";
    private int interval, payout = 0;
    private int messageInterval, messageTimer = 0, messageCounterMin, messageCounter = 0;
    private List<string> autoMessages;
    private int autoMessageLast = 0;
    private int[] intervals = { 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60 };
    private TcpClient irc;
    private StreamReader read;
    private StreamWriter write;
    private bool bettingOpen, poolLocked = false;
    private Pool pool;
    private Database db;
    private List<string> users = new List<string>();
    private DateTime time;
    private bool handoutGiven = false;
    private String[] betOptions;
    private int bettingCountdown = -1;
    private Timer currencyQueue;
    private List<string> usersToLookup = new List<string>();
    private ConcurrentQueue<string> highPriority = new ConcurrentQueue<string>();
    private ConcurrentQueue<string> normalPriority = new ConcurrentQueue<string>();
    private ConcurrentQueue<string> lowPriority = new ConcurrentQueue<string>();
    private Thread listener;
    private Thread KAthread;
    private Thread workerMinuteThread;
    private Thread workerSecondThread;
    private Timer messageQueue;
    private int attempt;
    private int subMultiplier;
    private int baseMoney = 200;

    public Irc(String channel, String currency, int interval, int payout, int subMultiplier, MainForm theForm, int messageInterval, int messageCounterMin, List<string> autoMessages)
    {
      setMainForm(theForm);
      setNick("ABotReborn");
      setPassword(System.IO.File.ReadAllText(@"abotreborn.auth")); // This file should contain your oauth from twitch
      setChannel(channel);
      setAdmin(channel);
      setCurrency(currency);
      setInterval(interval);
      setPayout(payout);
      setSubMultiplier(subMultiplier);
      setMessageInterval(messageInterval);
      setMessageCounterMin(messageCounterMin);
      setAutoMessages(autoMessages);

      Initialize();
    }
    public Irc(String channel, String currency, int interval, int payout, int subMultiplier, MainForm theForm) : this(channel, currency, interval, payout, subMultiplier, theForm, 0, 0, new List<string>()) { }
    
    private void Initialize()
    {
      db = new Database();
      db.newUser(capName(admin));
      db.setUserLevel(capName(admin), 3);

      Connect();
    }

    public void Close()
    {
      irc.Close();
      irc = null;

      messageQueue.Dispose();
      currencyQueue.Dispose();
    }

    private void Connect()
    {
      if (irc != null) irc.Close();

      irc = new TcpClient();

      Thread tempThread = new Thread(new ThreadStart(ircConnection));
      tempThread.Start();
    }

    private void ircConnection()
    {
      int count = 1;
      myForm.changeIRCState(MainForm.IRCState.connecting);
      while (irc != null && !irc.Connected)
      {
        printCommand("Connection attempt " + count, false, MainForm.ConsoleColor.orange);
        try
        {
          irc.Connect("irc.twitch.tv", 6667);

          read = new StreamReader(irc.GetStream());
          write = new StreamWriter(irc.GetStream());

          write.AutoFlush = true;

          sendRaw("PASS " + password);
          sendRaw("NICK " + nick);
          sendRaw("USER " + nick + " 8 * :" + nick);
          sendRaw("CAP REQ :twitch.tv/membership twitch.tv/commands"); // Get Member level
          sendRaw("JOIN " + channel);
        }
        catch (SocketException e)
        {
          printCommand("Unable to connect. Retrying in 5 seconds", false, MainForm.ConsoleColor.orange);
        }
        catch (Exception e)
        {
          LogError("Connect()", e);
        }
        count++;
        Thread.Sleep(5000);
      }

      myForm.changeIRCState(MainForm.IRCState.connected);
      myForm.activateChannelTab(channel);
      StartThreads();
    }

    private void StartThreads()
    {
      listener = new Thread(new ThreadStart(Listen));
      listener.Start();

      workerMinuteThread = new Thread(new ThreadStart(workerMinute));
      workerMinuteThread.Start();

      KAthread = new Thread(new ThreadStart(KeepAlive));
      KAthread.Start();

      workerSecondThread = new Thread(new ThreadStart(workerSecond));
      workerSecondThread.Start();

      messageQueue = new Timer(handleMessageQueue, null, 0, 4000);

      currencyQueue = new Timer(handleCurrencyQueue, null, Timeout.Infinite, Timeout.Infinite);
    }

    private void Listen()
    {
      try
      {
        while (irc != null && irc.Connected)
        {
          parseMessage(read.ReadLine());
        }
      }
      catch (IOException e)
      {

      }
      catch (Exception e)
      {
        LogError("Listen()", e);
      }
    }

    private void KeepAlive()
    {
      while (irc != null)
      {
        Thread.Sleep(30000);
        sendRaw("PING 1245");
      }
    }

    private void parseMessage(String message)
    {          
      String[] msg = message.Split(' ');

      if (msg[0].Equals("PING"))
        sendRaw("PONG " + msg[1]);
      else if (msg[1].Equals("PRIVMSG"))
      {
        user = capName(getUser(message));
        addUserToList(user);
        String temp = message.Substring(message.IndexOf(":", 1) + 1);
        printChat(user + ": " + temp);
        handleMessage(temp);
        if (capName(getUser(message)) != capName(this.nick)) // Check its not the bot
          messageCounter++;
      }
      else if (msg[1].Equals("JOIN"))
      {
        if (capName(getUser(message)) != capName(this.nick)) // Check its not the bot
        {
          user = capName(getUser(message));
          addUserToList(user);
          printChat(getUser(message) + " joined", true, MainForm.ConsoleColor.green);
          if (!db.userExists(user))
          {
            db.newUser(user);
            db.addCurrency(user, baseMoney);
          }
        }
        else
          printChat(getUser(message) + " joined", true, MainForm.ConsoleColor.green);
      }
      else if (msg[1].Equals("PART"))
      {
        removeUserFromList(capName(getUser(message)));
        printChat(user + " left", true, MainForm.ConsoleColor.orange);
      }
      else if (msg[1].Equals("352"))
        addUserToList(capName(msg[4]));
      else
      {
        //print(message);
      }
    }

    private void handleMessage(String message)
    {
      String[] msg = message.Split(' ');

      /////////////////Currency Commands/////////////////////
      #region currency
      if (msg[0].Equals("!" + currency, StringComparison.OrdinalIgnoreCase))
      {
        ///////////Check your Currency////////////
        if (msg.Length == 1) addToLookups(user);

        else if (msg.Length == 2 && db.getUserLevel(user) >= 2)
        {
          if (db.userExists(capName(msg[1]))) sendMessage(capName(msg[1]) + " has " + db.checkCurrency(capName(msg[1])) + " " + currency, 2);
          else sendMessage(capName(msg[1]) + " is not a valid user.", 2);
        }
        else if (msg.Length >= 3)
        {
          /////////////MOD ADD CURRENCY//////////////
          if (msg[1].Equals("add") && db.getUserLevel(user) >= 2)
          {
            int amount;
            if (int.TryParse(msg[2], out amount) && msg.Length >= 4)
            {
              if (msg[3].Equals("all"))
              {
                foreach (String nick in users)
                  db.addCurrency(capName(nick), amount);
                sendMessage("Added " + amount + " " + currency + " to everyone.", 1);
                Log(user + " added " + amount + " " + currency + " to everyone.");
              }
              else
              {
                if (db.userExists(capName(msg[3])))
                {
                  db.addCurrency(capName(msg[3]), amount);
                  sendMessage("Added " + amount + " " + currency + " to " + capName(msg[3]), 1);
                  Log(user + " added " + amount + " " + currency + " to " + capName(msg[3]));
                }
                else sendMessage(capName(msg[3]) + " doesn't exist BibleThump", 2);
              }
            }
          }

          ////////////MOD REMOVE CURRENCY////////////////
          if (msg[1].Equals("remove") && db.getUserLevel(user) >= 2)
          {
            int amount;
            if (msg[2] != null && int.TryParse(msg[2], out amount) && msg.Length > -4)
            {

              if (msg[3].Equals("all"))
              {
                foreach (String nick in users)
                {
                  db.removeCurrency(nick, amount);
                }
                sendMessage("Removed " + amount + " " + currency + " from everyone.", 1);
                Log(user + " removed " + amount + " " + currency + " from everyone.");
              }
              else
              {
                db.removeCurrency(capName(msg[3]), amount);
                sendMessage("Removed " + amount + " " + currency + " from " + capName(msg[3]), 1);
                Log(user + " removed " + amount + " " + currency + " from " + capName(msg[3]));
              }

            }
          }
        }
      }
      else if (msg[0].Equals("!top5"))
      {
        if (db.getUserLevel(user) >= 1)
        {
          sendMessage("Current Standings: " + db.getTopCurrency(capName(admin), 5), 3);
        }
      }
      #endregion
      /////////////////////END CURRENCY COMMANDS/////////////////////

      ///////////////////BETTING COMMANDS//////////////////////////
      #region betting
      //////////////////ADMIN BET COMMANDS/////////////////////////
      else if (msg[0].Equals("!gamble") && msg.Length >= 2)
      {
        if (db.getUserLevel(user) >= 1)
        {
          if (msg[1].Equals("open") && msg.Length >= 4)
          {
            if (!bettingOpen)
            {
              buildBetOptions(msg);
              pool = new Pool(db, betOptions);
              bettingOpen = true;
              bettingCountdown = 45;
              String temp = "New Betting Pool open for: ";
              for (int i = 0; i < betOptions.Length; i++)
              {
                temp += "(" + (i + 1).ToString() + ") " + betOptions[i] + " ";
              }
              sendMessage(temp, 2);
              sendMessage("Bet by typing \"!bet 50 1\" to bet 50 " + currency + " on option 1,  \"!bet 25 2\" to bet 25 on option 2, etc. Pool will close in 45 seconds.", 2);
            }
            else sendMessage("Betting Pool already opened.  Close or cancel the current one before starting a new one.", 1);
          }
          else if (msg[1].Equals("close"))
          {
            if (bettingOpen)
            {
              bettingCountdown = -1;
              closeBettingPool();
            }
            else sendMessage("No pool currently open.", 2);
          }
          else if (msg[1].Equals("winner") && msg.Length == 3)
          {
            if (bettingOpen && poolLocked)
            {
              int winIndex;
              if (int.TryParse(msg[2], out winIndex) && winIndex > 0)
              {
                winIndex = winIndex - 1;
                if (winIndex < betOptions.Length)
                {
                  pool.finishPool(winIndex);
                  bettingOpen = false;
                  poolLocked = false;
                  sendMessage("And the results are in! The Winner is " + betOptions[winIndex], 2);
                  String output = "";
                  Dictionary<string, int> winners = pool.getWinners();
                  output = "Winners:";
                  if (winners.Count == 0)
                  {
                    sendMessage(output + " No One! Kappa", 2);
                  }
                  for (int i = 0; i < winners.Count; i++)
                  {
                    output += " " + winners.ElementAt(i).Key + " - " + winners.ElementAt(i).Value + " (Bet " + pool.getBetAmount(winners.ElementAt(i).Key) + ")";
                    if (i == 0 && i == winners.Count - 1)
                    {
                      sendMessage(output, 2);
                      output = "";
                    }
                    else if ((i != 0 && i % 10 == 0) || i == winners.Count - 1)
                    {
                      sendMessage(output, 2);
                      output = "";
                    }
                  }

                }
                else
                {
                  sendMessage("Close the betting pool by typing \"!gamble winner 1\" if option 1 won, \"!gamble winner 2\" for option 2, etc.", 1);
                  sendMessage("You can type !bet help to get a list of the options for a reminder of which is each number if needed", 1);
                }
              }
              else
              {
                sendMessage("Close the betting pool by typing \"!gamble winner 1\" if option 1 won, \"!gamble winner 2\" for option 2, etc.", 1);
                sendMessage("You can type !bet help to get a list of the options for a reminder of which option is each number if needed", 1);
              }
            }
            else sendMessage("Betting pool must be open and bets must be locked before you can specify a winner.", 2);
          }
          else if (msg[1].Equals("cancel"))
          {
            if (pool != null)
            {
              pool.cancel();
              bettingOpen = false;
              poolLocked = false;
              sendMessage("Betting Pool canceled.  All bets refunded", 2);
            }
          }
        }
      }
      ////////////////USER BET COMMANDS////////////////////////
      else if (msg[0].Equals("!bet") && bettingOpen)
      {
        if (msg.Length >= 2)
        {
          int betAmount;
          int betOn;
          if (msg[1].Equals("help"))
          {
            if (bettingOpen)
            {
              String temp = "Betting open for: ";
              for (int i = 0; i < betOptions.Length; i++)
              {
                temp += "(" + (i + 1).ToString() + ") " + betOptions[i] + " ";
              }
              sendMessage(temp, 3);
              sendMessage("Bet by typing \"!bet 50 1\" to bet 50 " + currency + " on option 1,  \"bet 25 2\" to bet 25 on option 2, etc", 3);
            }
          }
          else if (int.TryParse(msg[1], out betAmount) && msg.Length >= 3 && bettingOpen && !poolLocked)
          {
            if (int.TryParse(msg[2], out betOn) && betOn > 0 && betOn <= betOptions.Length)
            {
              pool.placeBet(user, betOn - 1, betAmount);
              printCommand("Bet accepted from " + user, true, MainForm.ConsoleColor.blue);
            }
          }
        }
        else
        {
          if (pool.isInPool(user))
          {
            sendMessage(user + ": " + betOptions[pool.getBetOn(user)] + " (" + pool.getBetAmount(user) + ")", 2);
          }
        }
      }
      #endregion
      ////////////////END BET COMMANDS/////////////////////////

      ////////////////ADMIN COMMANDS//////////////////////////////
      #region admin
      else if (msg[0].Equals("!admin") && db.getUserLevel(user) == 3 && msg.Length >= 2)
      {
        if (msg[1].Equals("addmod") && msg.Length >= 3)
        {
          string tNick = capName(msg[2]);
          if (db.userExists(tNick))
          {
            if (!tNick.Equals(admin, StringComparison.OrdinalIgnoreCase))
            {
              db.setUserLevel(tNick, 1);
              sendMessage(tNick + " added as a bot moderator.", 1);
            }
            else sendMessage("Cannot change broadcaster access level.", 1);
          }
          else sendMessage(tNick + " does not exist in the database.  Have them type !<currency>, then try to add them again.", 1);
        }
        if (msg[1].Equals("addsuper") && msg.Length >= 3)
        {
          String tNick = capName(msg[2]);
          if (db.userExists(tNick))
          {
            if (!tNick.Equals(admin, StringComparison.OrdinalIgnoreCase))
            {
              db.setUserLevel(tNick, 2);
              sendMessage(tNick + " added as a bot Super Mod.", 1);
            }
            else sendMessage("Cannot change Broadcaster access level.", 1);
          }
          else sendMessage(tNick + " does not exist in the database.  Have them type !<currency>, then try to add them again.", 1);
        }
        if (msg[1].Equals("demote") && msg.Length >= 3)
        {
          string tNick = capName(msg[2]);
          if (db.userExists(tNick))
          {
            if (db.getUserLevel(tNick) > 0)
            {
              if (!tNick.Equals(admin, StringComparison.OrdinalIgnoreCase))
              {
                db.setUserLevel(tNick, db.getUserLevel(tNick) - 1);
                sendMessage(tNick + " demoted.", 1);
              }
              else sendMessage("Cannot change Broadcaster access level.", 1);
            }
            else sendMessage("User is already Access Level 0.  Cannot demote further.", 1);
          }
          else sendMessage(tNick + " does not exist in the database.  Have them type !<currency>, then try again.", 1);
        }
        if (msg[1].Equals("addsub") && msg.Length >= 3)
        {
          if (db.addSub(capName(msg[2])))
          {
            sendMessage(capName(msg[2]) + " added as a subscriber.", 2);
          }
          else sendMessage(capName(msg[2]) + " does not exist in the database.  Have them type !<currency> then try again.", 1);
        }
        if (msg[1].Equals("removesub") && msg.Length >= 3)
        {
          if (db.removeSub(capName(msg[2])))
          {
            sendMessage(capName(msg[2]) + " removed from subscribers.", 2);
          }
          else sendMessage(capName(msg[2]) + " does not exist in the database.", 1);
        }
      }
      #endregion
      ////////////////END ADMIN COMMANDS///////////////////////////

      ///////////////GENERAL COMMANDS//////////////////////////
      #region generalcommands
      else if (msg[0].Substring(0, 1) == "!")
      {
        sendMessage(user + " that command doesn't exist", 3);
      }
      #endregion
      ///////////////END GENERAL COMMANDS//////////////////////////
    }

    private void addUserToList(String nick)
    {
      lock (users)
      {
        if (!users.Contains(nick))
        {
          users.Add(nick);
        }
      }
    }

    private void removeUserFromList(String nick)
    {
      lock (users)
      {
        if (users.Contains(nick))
        {
          users.Remove(nick);
        }
      }
    }

    private void buildUserList()
    {
      sendRaw("WHO " + channel);
    }

    private String capName(String user)
    {
      return char.ToUpper(user[0]) + user.Substring(1);
    }

    private String getUser(String message)
    {
      String[] temp = message.Split('!');
      user = temp[0].Substring(1);
      return capName(user);
    }

    private void setNick(String tNick)
    {
      nick = tNick.ToLower();
    }

    private void setPassword(String tPassword)
    {
      password = tPassword;
    }

    private void setChannel(String tChannel)
    {
      if (tChannel.StartsWith("#"))
      {
        channel = tChannel;
      }
      else
      {
        channel = "#" + tChannel;
      }
    }

    private void setAdmin(String tChannel)
    {
      if (tChannel.StartsWith("#"))
      {
        admin = tChannel.Substring(1);
      }
      else
      {
        admin = tChannel;
      }
    }

    private void setCurrency(String tCurrency)
    {
      if (tCurrency.StartsWith("!"))
      {
        currency = tCurrency.Substring(1);
      }
      else
      {
        currency = tCurrency;
      }
    }

    public void setInterval(int tInterval)
    {
      interval = tInterval;
      myForm.setCurrentPayoutMessage(interval, payout, currency);
    }

    public void setPayout(int tPayout)
    {
      payout = tPayout;
      myForm.setCurrentPayoutMessage(interval, payout, currency);
    }
    private void setSubMultiplier(int tSubMultiplier)
    {
      subMultiplier = tSubMultiplier;
    }

    private void setMainForm(MainForm theForm)
    {
      this.myForm = theForm;
    }
    private void setMessageInterval(int interval)
    {
      this.messageInterval = interval;
    }
    private void setMessageCounterMin(int min)
    {
      this.messageCounterMin = min;
    }
    private void setAutoMessages(List<string> messages)
    {
      this.autoMessages = messages;
    }

    //private void print(String message, Boolean timestamp = true)
    //{
    //  //Console.WriteLine((timestamp ? "<" + DateTime.UtcNow.ToString("hh:mm.ss tt") + "> " : "") + message);
    //  myForm.insertConsoleLine((timestamp ? "<" + DateTime.UtcNow.ToString("hh:mm.ss tt") + "> " : "") + message, MainForm.ConsoleType.command, MainForm.ConsoleColor.standard);
    //}

    private void printCommand(string message, Boolean timestamp = true, MainForm.ConsoleColor color = MainForm.ConsoleColor.standard)
    {
      myForm.insertConsoleLine((timestamp ? "<" + DateTime.UtcNow.ToString("hh:mm.ss tt") + "> " : "") + message, MainForm.ConsoleType.command, color);
    }

    private void printChat(string message, Boolean timestamp = true, MainForm.ConsoleColor color = MainForm.ConsoleColor.standard)
    {
      myForm.insertConsoleLine((timestamp ? "<" + DateTime.UtcNow.ToString("hh:mm.ss tt") + "> " : "") + message, MainForm.ConsoleType.chat, color);
    }

    private void sendRaw(String message)
    {

      try
      {
        write.WriteLine(message);
        attempt = 0;
      }
      catch (Exception e)
      {
        attempt++;
        if (attempt >= 5)
        {
          myForm.changeIRCState(MainForm.IRCState.reconnecting);
          printCommand("Disconnected.  Attempting to reconnect.", false, MainForm.ConsoleColor.red);
          irc.Close();
          Connect();
          attempt = 0;
        }
      }

    }

    private void sendMessage(String message, int priority)
    {
      if (priority == 1)
      {
        highPriority.Enqueue(message);
      }
      else if (priority == 2)
      {
        normalPriority.Enqueue(message);
      }
      else lowPriority.Enqueue(message);
    }

    private bool checkTime()
    {
      time = DateTime.Now;
      int x = time.Minute;

      if (x % interval == 0)
      {
        handoutGiven = true;
        return handoutGiven;
      }

      handoutGiven = false;
      return handoutGiven;
    }

    private bool checkAutoMessage()
    {
      if (autoMessages.Count > 0 && messageTimer >= messageInterval && messageCounter >= messageCounterMin)
      {
        return true;
      }

      return false;
    }

    private bool checkStream()
    {
      if (irc.Connected)
      {
        using (var w = new WebClient())
        {
          String json_data = "";
          try
          {
            w.Proxy = null;
            json_data = w.DownloadString("https://api.twitch.tv/kraken/streams/" + channel.Substring(1));
            JObject stream = JObject.Parse(json_data);
            if (stream["stream"].HasValues)
            {
              return true;
            }
          }
          catch (SocketException e)
          {
            printCommand("Unable to connect to twitch API to check stream status. Skipping.", false, MainForm.ConsoleColor.orange);
          }
          catch (Exception e)
          {
            LogError("checkStream()", e);
          }
          return true;
        }

        return false;
      }
      return false;
    }

    private void handoutCurrency()
    {
      try
      {
        buildUserList();
        Thread.Sleep(5000);
        lock (users)
        {
          foreach (String person in users)
          {
            if (db.isSubscriber(person))
            {
              db.addCurrency(person, payout * subMultiplier);
            }
            else
            {
              db.addCurrency(person, payout);
            }
          }
        }
      }
      catch (Exception e)
      {
        LogError("handoutCurrency()", e);
      }
    }

    private void buildBetOptions(String[] temp)
    {
      try
      {
        betOptions = new String[temp.Length - 3];
        StringBuilder sb = new StringBuilder();
        for (int i = 2; i < temp.Length; i++)
        {
          sb.Append(temp[i]);
        }
        betOptions = sb.ToString().Split(',');
      }
      catch (Exception e)
      {
        LogError("buildBetOptions()", e);
      }
    }

    private void workerMinute()
    {
      while (irc != null)
      {
        try
        {
          if (checkTime() && checkStream())
          {
            printCommand("Handout happening now! Paying everyone " + payout + " " + currency, true, MainForm.ConsoleColor.green);
            handoutCurrency();
          }
          if (checkAutoMessage() && checkStream())
          {
            messageTimer = 0;
            messageCounter = 0;
            sendMessage(autoMessages[autoMessageLast], 3);
            autoMessageLast++;
            if (autoMessageLast > autoMessages.Count - 1)
              autoMessageLast = 0;
          }
          messageTimer++;
          Thread.Sleep(60000);
        }
        catch (SocketException e)
        {
          printCommand("No response from twitch.  Skipping handout.", false, MainForm.ConsoleColor.orange);
        }
        catch (Exception e)
        {
          LogError("doWork()", e);
        }
      }
    }

    private void workerSecond()
    {
      while (irc != null)
      {
        if (bettingCountdown > -1)
        {
          if (bettingCountdown == 0)
          {
            closeBettingPool();
          }
          else if (bettingCountdown == 15)
          {
            printCommand("15 seconds remaining on betting pool", false, MainForm.ConsoleColor.blue);
          }
          else if (bettingCountdown == 30)
          {
            printCommand("30 seconds remaining on betting pool", false, MainForm.ConsoleColor.blue);
          }

          bettingCountdown--;
        }
        Thread.Sleep(1000);
      }
    }

    private void closeBettingPool()
    {
      poolLocked = true;
      pool.closePool();
      sendMessage("Betting Pool is closed! A total of " + pool.getTotalBets() + " " + currency + " were bet.", 1);
      String output = "Bets for:";
      for (int i = 0; i < betOptions.Length; i++)
      {
        double x = 0;
        if (pool.getTotalBets() > 0)
          x = Math.Round(((double)pool.getTotalBetsOn(i) / pool.getTotalBets()) * 100);
        output += " " + betOptions[i] + " - " + pool.getNumberOfBets(i) + " (" + x + "%);";
      }
      sendMessage(output, 2);
    }

    private void addToLookups(String nick)
    {
      if (usersToLookup.Count == 0)
      {
        currencyQueue.Change(4000, Timeout.Infinite);
      }
      if (!usersToLookup.Contains(nick))
      {
        usersToLookup.Add(nick);
      }
    }

    private void handleCurrencyQueue(Object state)
    {
      if (usersToLookup.Count != 0)
      {
        String output = currency + ":";
        bool addComma = false;
        foreach (String person in usersToLookup)
        {
          if (addComma)
          {
            output += ", ";
          }

          int current = db.checkCurrency(person);

          if (current >= 0)
          {
            output += " " + person + " - " + current;
            if (bettingOpen)
            {
              if (pool.isInPool(person))
              {
                output += "[" + pool.getBetAmount(person) + "]";
              }
            }
            
          }
          else
          {
            output += " " + person + " wasn't found yet";
          }
          addComma = true;
        }
        sendRaw("PRIVMSG " + channel + " :" + output);
        usersToLookup.Clear();
      }
    }

    private void handleMessageQueue(Object state)
    {
      String message;
      if (highPriority.TryDequeue(out message))
      {
        printChat(nick + ": " + message);
        sendRaw("PRIVMSG " + channel + " :" + message);
        messageQueue.Change(4000, Timeout.Infinite);
      }
      else if (normalPriority.TryDequeue(out message))
      {
        printChat(nick + ": " + message);
        sendRaw("PRIVMSG " + channel + " :" + message);
        messageQueue.Change(4000, Timeout.Infinite);
      }
      else if (lowPriority.TryDequeue(out message))
      {
        printChat(nick + ": " + message);
        sendRaw("PRIVMSG " + channel + " :" + message);
        messageQueue.Change(4000, Timeout.Infinite);
      }
      else messageQueue.Change(4000, Timeout.Infinite);
    }

    private void Log(String output)
    {
      try
      {
        StreamWriter log = new StreamWriter("CommandLog.log", true);
        log.WriteLine("<" + DateTime.Now + "> " + output);
        log.Close();
      }
      catch (Exception e)
      {
        LogError("Log()", e);
      }
    }

    private void LogError(string function, Exception e)
    {
      printCommand(e.ToString(), false, MainForm.ConsoleColor.red);
      StreamWriter errorLog = new StreamWriter("Error_Log.log", true);
      errorLog.WriteLine("*************Error Message (via " + function + "): " + DateTime.Now + "*********************************");
      errorLog.WriteLine(e);
      errorLog.WriteLine("");
      errorLog.Close();
    }
  }
}
