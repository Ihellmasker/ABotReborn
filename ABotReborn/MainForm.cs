using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ABotReborn
{
  public partial class MainForm : MetroForm
  {
    private Irc IRC;

    public MainForm()
    {
      InitializeComponent();

      channelBox.Text = global::ABotReborn.Properties.Settings.Default.channel;
      currencyBox.Text = global::ABotReborn.Properties.Settings.Default.currency;
      intervalBox.SelectedIndex = global::ABotReborn.Properties.Settings.Default.interval;
      payoutBox.SelectedIndex = global::ABotReborn.Properties.Settings.Default.payout;
      subMultiplierBox.Text = global::ABotReborn.Properties.Settings.Default.subMultiplier;
      autoMessagesToggle.Checked = global::ABotReborn.Properties.Settings.Default.autoMessageEnabled;
      messageIntervalBox.SelectedIndex = global::ABotReborn.Properties.Settings.Default.amMinInterval;
      messageCounterMinBox.Text = global::ABotReborn.Properties.Settings.Default.amMinCount;
      autoMessage1Box.Text = global::ABotReborn.Properties.Settings.Default.autoMessage1;
      autoMessage2Box.Text = global::ABotReborn.Properties.Settings.Default.autoMessage2;
      autoMessage3Box.Text = global::ABotReborn.Properties.Settings.Default.autoMessage3;

      channelTab.Parent = null;
      metroTabControl1.SelectedTab = initialiseTab;

      notifyIcon.Visible = false;
    }

    private void startButton_Click(object sender, EventArgs e)
    {
      String channel = channelBox.Text;
      String currency = currencyBox.Text;
      int interval = int.Parse(intervalBox.SelectedItem.ToString());
      int payout = int.Parse(payoutBox.SelectedItem.ToString());
      int subMultiplier = int.Parse(subMultiplierBox.Text);
      bool autoMessageEnabled = autoMessagesToggle.Checked;
      int amInterval = int.Parse(messageIntervalBox.SelectedItem.ToString());
      int amMessageCount = int.Parse(messageCounterMinBox.Text);
      List<string> messages = new List<string>();
      if(autoMessage1Box.Text != "")
        messages.Add(autoMessage1Box.Text);
      if(autoMessage2Box.Text != "")
        messages.Add(autoMessage2Box.Text);
      if(autoMessage3Box.Text != "")
        messages.Add(autoMessage3Box.Text);

      saveSettings();

      startButton.Enabled = false;
      connectionSpinner.Visible = true;

      if (autoMessageEnabled)
        IRC = new Irc(channel.ToLower(), currency, interval, payout, subMultiplier, this, amInterval, amMessageCount, messages);
      else
        IRC = new Irc(channel.ToLower(), currency, interval, payout, subMultiplier, this);
    }

    delegate void activateChannelTabCallback(string channel);
    public void activateChannelTab(string channel)
    {
      if (metroTabControl1.InvokeRequired)
      {
        activateChannelTabCallback d = new activateChannelTabCallback(activateChannelTab);
        Invoke(d, new object[] { channel });
      }
      else
      {
        channelTab.Parent = metroTabControl1;
        channelTab.Text = channel;
        metroTabControl1.SelectedTab = channelTab;
        connectionSpinner.Visible = false;
        tsmChannel.Text = "Channel: " + channel;
      }
    }

    public enum IRCState { notConnected, disconnected, reconnecting, connecting, connected };

    delegate void changeIRCStateCallback(IRCState state);
    public void changeIRCState(IRCState state)
    {
      if (ircStatusLabel.InvokeRequired)
      {
        changeIRCStateCallback d = new changeIRCStateCallback(changeIRCState);
        Invoke(d, new object[] { state });
      }
      else
      {
        switch (state)
        {
          case IRCState.notConnected:
            ircStatusLabel.Style = MetroFramework.MetroColorStyle.Red;
            ircStatusLabel.Text = "Not Connected";
            break;
          case IRCState.disconnected:
            ircStatusLabel.Style = MetroFramework.MetroColorStyle.Red;
            ircStatusLabel.Text = "Disconnected";
            break;
          case IRCState.reconnecting:
            ircStatusLabel.Style = MetroFramework.MetroColorStyle.Orange;
            ircStatusLabel.Text = "Reconnecting";
            break;
          case IRCState.connecting:
            ircStatusLabel.Style = MetroFramework.MetroColorStyle.Orange;
            ircStatusLabel.Text = "Connecting";
            break;
          case IRCState.connected:
            ircStatusLabel.Style = MetroFramework.MetroColorStyle.Green;
            ircStatusLabel.Text = "Connected";
            break;
        }
        tsmStatus.Text = "Status: " + ircStatusLabel.Text;
      }
    }

    public enum ConsoleType { command, chat };
    public enum ConsoleColor { standard, green, blue, orange, red };

    delegate void insertConsoleLineCallback(string text, ConsoleType type, ConsoleColor color);
    public void insertConsoleLine(string text, ConsoleType type, ConsoleColor color)
    {
      if (metroTabControl1.InvokeRequired)
      {
        insertConsoleLineCallback d = new insertConsoleLineCallback(insertConsoleLine);
        Invoke(d, new object[] { text, type, color });
      }
      else
      {
        MetroFramework.Controls.MetroLabel newLine = new MetroFramework.Controls.MetroLabel();
        newLine.AutoSize = true;
        newLine.Size = new System.Drawing.Size(ircCommandPanel.Width - 15, 19);
        //newLine.MaximumSize = new Size(ircStreamChat.Width - 15, 0);
        //newLine.AutoSize = true;
        newLine.AutoSize = false;

        MetroFramework.Controls.MetroPanel thisPanel = null;
        switch (type)
        {
          case ConsoleType.command:
            thisPanel = ircCommandPanel;
            break;
          case ConsoleType.chat:
            thisPanel = ircChatPanel;
            break;
        }
        if (thisPanel != null)
        {
          int lines = thisPanel.Controls.Count - 1;
          if (lines <= 1)
            newLine.Location = new System.Drawing.Point(0, 1);
          else
            newLine.Location = new System.Drawing.Point(0, thisPanel.Controls[thisPanel.Controls.Count - 1].Bottom + 1);
          thisPanel.Controls.Add(newLine);
          newLine.Text = text;

          switch (color)
          {
            case ConsoleColor.standard:
              newLine.Style = MetroFramework.MetroColorStyle.Default;
              newLine.UseStyleColors = false;
              break;
            case ConsoleColor.green:
              newLine.Style = MetroFramework.MetroColorStyle.Green;
              newLine.UseStyleColors = true;
              break;
            case ConsoleColor.blue:
              newLine.Style = MetroFramework.MetroColorStyle.Blue;
              newLine.UseStyleColors = true;
              break;
            case ConsoleColor.orange:
              newLine.Style = MetroFramework.MetroColorStyle.Orange;
              newLine.UseStyleColors = true;
              break;
            case ConsoleColor.red:
              newLine.Style = MetroFramework.MetroColorStyle.Red;
              newLine.UseStyleColors = true;
              break;
          }

          thisPanel.VerticalScroll.Value = thisPanel.VerticalScroll.Maximum;
          ((MetroFramework.Controls.MetroScrollBar)thisPanel.Controls[0]).Value = ((MetroFramework.Controls.MetroScrollBar)thisPanel.Controls[0]).Maximum;
        }
      }
    }

    private void ircStreamChat_ControlAdded(object sender, ControlEventArgs e)
    {
      ircCommandPanel.ScrollControlIntoView(e.Control);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IRC != null)
      {
        IRC.Close();
      }
    }

    private void saveSettings()
    {
      //save session settings
      Properties.Settings.Default.channel = channelBox.Text;
      Properties.Settings.Default.currency = currencyBox.Text;
      Properties.Settings.Default.interval = intervalBox.SelectedIndex;
      if (IRC != null)
      {
        IRC.setInterval(int.Parse(intervalBox.SelectedItem.ToString()));
      }
      Properties.Settings.Default.payout = payoutBox.SelectedIndex;
      if (IRC != null)
      {
        IRC.setPayout(int.Parse(payoutBox.SelectedItem.ToString()));
      }
      Properties.Settings.Default.subMultiplier = subMultiplierBox.Text;
      Properties.Settings.Default.autoMessageEnabled = autoMessagesToggle.Checked;
      Properties.Settings.Default.amMinInterval = messageIntervalBox.SelectedIndex;
      Properties.Settings.Default.amMinCount = messageCounterMinBox.Text;
      Properties.Settings.Default.autoMessage1 = autoMessage1Box.Text;
      Properties.Settings.Default.autoMessage2 = autoMessage2Box.Text;
      Properties.Settings.Default.autoMessage3 = autoMessage3Box.Text;

      Properties.Settings.Default.Save();
    }

    delegate void setCurrentPayoutMessageCallback(int interval, int amount, string currency);
    public void setCurrentPayoutMessage(int interval, int amount, string currency)
    {
      if (payoutText.InvokeRequired)
      {
        setCurrentPayoutMessageCallback d = new setCurrentPayoutMessageCallback(setCurrentPayoutMessage);
        Invoke(d, new object[] { interval, amount, currency });
      }
      else
      {
        payoutText.Text = amount + " " + currency + " every " + interval + " minutes";
      }
    }

    private void settingsSave_Click(object sender, EventArgs e)
    {
      saveSettings();
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      if (FormWindowState.Minimized == this.WindowState)
      {
        notifyIcon.Visible = true;
        this.Hide();
      }

      else if (FormWindowState.Normal == this.WindowState)
      {
        notifyIcon.Visible = false;
      }
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
      this.Show();
      this.WindowState = FormWindowState.Normal;
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void notifyIcon_Click(object sender, EventArgs e)
    {
      this.Show();
      this.WindowState = FormWindowState.Normal;
    }

    private void notifyIcon_DoubleClick(object sender, EventArgs e)
    {
      this.Show();
      this.WindowState = FormWindowState.Normal;
    }
  }
}
