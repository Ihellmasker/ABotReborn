namespace ABotReborn
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
      this.initialiseTab = new MetroFramework.Controls.MetroTabPage();
      this.connectionSpinner = new MetroFramework.Controls.MetroProgressSpinner();
      this.startButton = new MetroFramework.Controls.MetroButton();
      this.channelBox = new MetroFramework.Controls.MetroTextBox();
      this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
      this.settingsTab = new MetroFramework.Controls.MetroTabPage();
      this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
      this.settingsSave = new MetroFramework.Controls.MetroButton();
      this.autoMessage3Box = new MetroFramework.Controls.MetroTextBox();
      this.autoMessage2Box = new MetroFramework.Controls.MetroTextBox();
      this.autoMessage1Box = new MetroFramework.Controls.MetroTextBox();
      this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
      this.messageCounterMinBox = new MetroFramework.Controls.MetroTextBox();
      this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
      this.messageIntervalBox = new MetroFramework.Controls.MetroComboBox();
      this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
      this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
      this.autoMessagesToggle = new MetroFramework.Controls.MetroToggle();
      this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
      this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
      this.currencyBox = new MetroFramework.Controls.MetroTextBox();
      this.payoutBox = new MetroFramework.Controls.MetroComboBox();
      this.subMultiplierBox = new MetroFramework.Controls.MetroTextBox();
      this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
      this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
      this.intervalBox = new MetroFramework.Controls.MetroComboBox();
      this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
      this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
      this.channelTab = new MetroFramework.Controls.MetroTabPage();
      this.payoutText = new MetroFramework.Controls.MetroLabel();
      this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
      this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
      this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
      this.ircChatPanel = new MetroFramework.Controls.MetroPanel();
      this.ircStatusLabel = new MetroFramework.Controls.MetroLabel();
      this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
      this.ircCommandPanel = new MetroFramework.Controls.MetroPanel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsmChannel = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmStatus = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.metroTabControl1.SuspendLayout();
      this.initialiseTab.SuspendLayout();
      this.settingsTab.SuspendLayout();
      this.metroPanel1.SuspendLayout();
      this.channelTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // metroTabControl1
      // 
      this.metroTabControl1.Controls.Add(this.initialiseTab);
      this.metroTabControl1.Controls.Add(this.settingsTab);
      this.metroTabControl1.Controls.Add(this.channelTab);
      this.metroTabControl1.Location = new System.Drawing.Point(23, 63);
      this.metroTabControl1.Name = "metroTabControl1";
      this.metroTabControl1.SelectedIndex = 2;
      this.metroTabControl1.Size = new System.Drawing.Size(769, 415);
      this.metroTabControl1.TabIndex = 0;
      this.metroTabControl1.UseSelectable = true;
      // 
      // initialiseTab
      // 
      this.initialiseTab.Controls.Add(this.connectionSpinner);
      this.initialiseTab.Controls.Add(this.startButton);
      this.initialiseTab.Controls.Add(this.channelBox);
      this.initialiseTab.Controls.Add(this.metroLabel5);
      this.initialiseTab.HorizontalScrollbarBarColor = true;
      this.initialiseTab.HorizontalScrollbarHighlightOnWheel = false;
      this.initialiseTab.HorizontalScrollbarSize = 10;
      this.initialiseTab.Location = new System.Drawing.Point(4, 38);
      this.initialiseTab.Name = "initialiseTab";
      this.initialiseTab.Size = new System.Drawing.Size(761, 373);
      this.initialiseTab.TabIndex = 0;
      this.initialiseTab.Text = "Initialise";
      this.initialiseTab.VerticalScrollbarBarColor = true;
      this.initialiseTab.VerticalScrollbarHighlightOnWheel = false;
      this.initialiseTab.VerticalScrollbarSize = 10;
      // 
      // connectionSpinner
      // 
      this.connectionSpinner.Location = new System.Drawing.Point(196, 71);
      this.connectionSpinner.Maximum = 100;
      this.connectionSpinner.Name = "connectionSpinner";
      this.connectionSpinner.Size = new System.Drawing.Size(36, 36);
      this.connectionSpinner.TabIndex = 5;
      this.connectionSpinner.UseSelectable = true;
      this.connectionSpinner.Value = 80;
      this.connectionSpinner.Visible = false;
      // 
      // startButton
      // 
      this.startButton.Location = new System.Drawing.Point(18, 70);
      this.startButton.Name = "startButton";
      this.startButton.Size = new System.Drawing.Size(172, 37);
      this.startButton.TabIndex = 4;
      this.startButton.Text = "Send to Channel";
      this.startButton.UseSelectable = true;
      this.startButton.Click += new System.EventHandler(this.startButton_Click);
      // 
      // channelBox
      // 
      this.channelBox.Lines = new string[0];
      this.channelBox.Location = new System.Drawing.Point(18, 41);
      this.channelBox.MaxLength = 32767;
      this.channelBox.Name = "channelBox";
      this.channelBox.PasswordChar = '\0';
      this.channelBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.channelBox.SelectedText = "";
      this.channelBox.Size = new System.Drawing.Size(204, 23);
      this.channelBox.TabIndex = 3;
      this.channelBox.UseSelectable = true;
      this.channelBox.UseStyleColors = true;
      // 
      // metroLabel5
      // 
      this.metroLabel5.AutoSize = true;
      this.metroLabel5.Location = new System.Drawing.Point(18, 19);
      this.metroLabel5.Name = "metroLabel5";
      this.metroLabel5.Size = new System.Drawing.Size(96, 19);
      this.metroLabel5.TabIndex = 2;
      this.metroLabel5.Text = "Channel Name";
      // 
      // settingsTab
      // 
      this.settingsTab.Controls.Add(this.metroPanel1);
      this.settingsTab.HorizontalScrollbarBarColor = true;
      this.settingsTab.HorizontalScrollbarHighlightOnWheel = false;
      this.settingsTab.HorizontalScrollbarSize = 10;
      this.settingsTab.Location = new System.Drawing.Point(4, 38);
      this.settingsTab.Name = "settingsTab";
      this.settingsTab.Size = new System.Drawing.Size(761, 373);
      this.settingsTab.TabIndex = 1;
      this.settingsTab.Text = "Settings";
      this.settingsTab.VerticalScrollbarBarColor = true;
      this.settingsTab.VerticalScrollbarHighlightOnWheel = false;
      this.settingsTab.VerticalScrollbarSize = 10;
      // 
      // metroPanel1
      // 
      this.metroPanel1.AutoScroll = true;
      this.metroPanel1.Controls.Add(this.settingsSave);
      this.metroPanel1.Controls.Add(this.autoMessage3Box);
      this.metroPanel1.Controls.Add(this.autoMessage2Box);
      this.metroPanel1.Controls.Add(this.autoMessage1Box);
      this.metroPanel1.Controls.Add(this.metroLabel14);
      this.metroPanel1.Controls.Add(this.messageCounterMinBox);
      this.metroPanel1.Controls.Add(this.metroLabel13);
      this.metroPanel1.Controls.Add(this.messageIntervalBox);
      this.metroPanel1.Controls.Add(this.metroLabel12);
      this.metroPanel1.Controls.Add(this.metroLabel11);
      this.metroPanel1.Controls.Add(this.autoMessagesToggle);
      this.metroPanel1.Controls.Add(this.metroLabel10);
      this.metroPanel1.Controls.Add(this.metroLabel9);
      this.metroPanel1.Controls.Add(this.currencyBox);
      this.metroPanel1.Controls.Add(this.payoutBox);
      this.metroPanel1.Controls.Add(this.subMultiplierBox);
      this.metroPanel1.Controls.Add(this.metroLabel2);
      this.metroPanel1.Controls.Add(this.metroLabel4);
      this.metroPanel1.Controls.Add(this.intervalBox);
      this.metroPanel1.Controls.Add(this.metroLabel1);
      this.metroPanel1.Controls.Add(this.metroLabel3);
      this.metroPanel1.HorizontalScrollbar = true;
      this.metroPanel1.HorizontalScrollbarBarColor = true;
      this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
      this.metroPanel1.HorizontalScrollbarSize = 10;
      this.metroPanel1.Location = new System.Drawing.Point(18, 19);
      this.metroPanel1.Name = "metroPanel1";
      this.metroPanel1.Size = new System.Drawing.Size(709, 344);
      this.metroPanel1.TabIndex = 14;
      this.metroPanel1.VerticalScrollbar = true;
      this.metroPanel1.VerticalScrollbarBarColor = true;
      this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
      this.metroPanel1.VerticalScrollbarSize = 10;
      // 
      // settingsSave
      // 
      this.settingsSave.Location = new System.Drawing.Point(61, 572);
      this.settingsSave.Name = "settingsSave";
      this.settingsSave.Size = new System.Drawing.Size(172, 37);
      this.settingsSave.TabIndex = 26;
      this.settingsSave.Text = "Save Settings";
      this.settingsSave.UseSelectable = true;
      this.settingsSave.Click += new System.EventHandler(this.settingsSave_Click);
      // 
      // autoMessage3Box
      // 
      this.autoMessage3Box.Lines = new string[0];
      this.autoMessage3Box.Location = new System.Drawing.Point(0, 515);
      this.autoMessage3Box.MaxLength = 32767;
      this.autoMessage3Box.Name = "autoMessage3Box";
      this.autoMessage3Box.PasswordChar = '\0';
      this.autoMessage3Box.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.autoMessage3Box.SelectedText = "";
      this.autoMessage3Box.Size = new System.Drawing.Size(300, 51);
      this.autoMessage3Box.TabIndex = 25;
      this.autoMessage3Box.UseSelectable = true;
      this.autoMessage3Box.UseStyleColors = true;
      // 
      // autoMessage2Box
      // 
      this.autoMessage2Box.Lines = new string[0];
      this.autoMessage2Box.Location = new System.Drawing.Point(0, 458);
      this.autoMessage2Box.MaxLength = 32767;
      this.autoMessage2Box.Name = "autoMessage2Box";
      this.autoMessage2Box.PasswordChar = '\0';
      this.autoMessage2Box.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.autoMessage2Box.SelectedText = "";
      this.autoMessage2Box.Size = new System.Drawing.Size(300, 51);
      this.autoMessage2Box.TabIndex = 24;
      this.autoMessage2Box.UseSelectable = true;
      this.autoMessage2Box.UseStyleColors = true;
      // 
      // autoMessage1Box
      // 
      this.autoMessage1Box.Lines = new string[0];
      this.autoMessage1Box.Location = new System.Drawing.Point(0, 401);
      this.autoMessage1Box.MaxLength = 32767;
      this.autoMessage1Box.Multiline = true;
      this.autoMessage1Box.Name = "autoMessage1Box";
      this.autoMessage1Box.PasswordChar = '\0';
      this.autoMessage1Box.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.autoMessage1Box.SelectedText = "";
      this.autoMessage1Box.Size = new System.Drawing.Size(300, 51);
      this.autoMessage1Box.TabIndex = 23;
      this.autoMessage1Box.UseSelectable = true;
      this.autoMessage1Box.UseStyleColors = true;
      // 
      // metroLabel14
      // 
      this.metroLabel14.AutoSize = true;
      this.metroLabel14.Location = new System.Drawing.Point(0, 379);
      this.metroLabel14.Name = "metroLabel14";
      this.metroLabel14.Size = new System.Drawing.Size(65, 19);
      this.metroLabel14.TabIndex = 22;
      this.metroLabel14.Text = "Messages";
      // 
      // messageCounterMinBox
      // 
      this.messageCounterMinBox.Lines = new string[] {
        "20"};
      this.messageCounterMinBox.Location = new System.Drawing.Point(0, 353);
      this.messageCounterMinBox.MaxLength = 32767;
      this.messageCounterMinBox.Name = "messageCounterMinBox";
      this.messageCounterMinBox.PasswordChar = '\0';
      this.messageCounterMinBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.messageCounterMinBox.SelectedText = "";
      this.messageCounterMinBox.Size = new System.Drawing.Size(300, 23);
      this.messageCounterMinBox.TabIndex = 21;
      this.messageCounterMinBox.Text = "20";
      this.messageCounterMinBox.UseSelectable = true;
      this.messageCounterMinBox.UseStyleColors = true;
      // 
      // metroLabel13
      // 
      this.metroLabel13.AutoSize = true;
      this.metroLabel13.Location = new System.Drawing.Point(0, 331);
      this.metroLabel13.Name = "metroLabel13";
      this.metroLabel13.Size = new System.Drawing.Size(159, 19);
      this.metroLabel13.TabIndex = 20;
      this.metroLabel13.Text = "Minimum Message Count";
      // 
      // messageIntervalBox
      // 
      this.messageIntervalBox.FormattingEnabled = true;
      this.messageIntervalBox.ItemHeight = 23;
      this.messageIntervalBox.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60"});
      this.messageIntervalBox.Location = new System.Drawing.Point(0, 299);
      this.messageIntervalBox.Name = "messageIntervalBox";
      this.messageIntervalBox.Size = new System.Drawing.Size(300, 29);
      this.messageIntervalBox.TabIndex = 19;
      this.messageIntervalBox.UseSelectable = true;
      // 
      // metroLabel12
      // 
      this.metroLabel12.AutoSize = true;
      this.metroLabel12.Location = new System.Drawing.Point(0, 277);
      this.metroLabel12.Name = "metroLabel12";
      this.metroLabel12.Size = new System.Drawing.Size(112, 19);
      this.metroLabel12.TabIndex = 18;
      this.metroLabel12.Text = "Minimum Interval";
      // 
      // metroLabel11
      // 
      this.metroLabel11.AutoSize = true;
      this.metroLabel11.Location = new System.Drawing.Point(0, 255);
      this.metroLabel11.Name = "metroLabel11";
      this.metroLabel11.Size = new System.Drawing.Size(56, 19);
      this.metroLabel11.TabIndex = 17;
      this.metroLabel11.Text = "Enabled";
      // 
      // autoMessagesToggle
      // 
      this.autoMessagesToggle.AutoSize = true;
      this.autoMessagesToggle.Location = new System.Drawing.Point(220, 257);
      this.autoMessagesToggle.Name = "autoMessagesToggle";
      this.autoMessagesToggle.Size = new System.Drawing.Size(80, 17);
      this.autoMessagesToggle.TabIndex = 16;
      this.autoMessagesToggle.Text = "Off";
      this.autoMessagesToggle.UseSelectable = true;
      // 
      // metroLabel10
      // 
      this.metroLabel10.AutoSize = true;
      this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
      this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
      this.metroLabel10.Location = new System.Drawing.Point(0, 230);
      this.metroLabel10.Name = "metroLabel10";
      this.metroLabel10.Size = new System.Drawing.Size(134, 25);
      this.metroLabel10.TabIndex = 15;
      this.metroLabel10.Text = "Auto Messages";
      // 
      // metroLabel9
      // 
      this.metroLabel9.AutoSize = true;
      this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
      this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
      this.metroLabel9.Location = new System.Drawing.Point(0, 0);
      this.metroLabel9.Name = "metroLabel9";
      this.metroLabel9.Size = new System.Drawing.Size(184, 25);
      this.metroLabel9.TabIndex = 14;
      this.metroLabel9.Text = "Currency and Payouts";
      // 
      // currencyBox
      // 
      this.currencyBox.Lines = new string[] {
        "gil"};
      this.currencyBox.Location = new System.Drawing.Point(0, 47);
      this.currencyBox.MaxLength = 32767;
      this.currencyBox.Name = "currencyBox";
      this.currencyBox.PasswordChar = '\0';
      this.currencyBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.currencyBox.SelectedText = "";
      this.currencyBox.Size = new System.Drawing.Size(300, 23);
      this.currencyBox.TabIndex = 11;
      this.currencyBox.Text = "gil";
      this.currencyBox.UseSelectable = true;
      this.currencyBox.UseStyleColors = true;
      // 
      // payoutBox
      // 
      this.payoutBox.FormattingEnabled = true;
      this.payoutBox.ItemHeight = 23;
      this.payoutBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "60",
            "70",
            "75",
            "80",
            "90",
            "100"});
      this.payoutBox.Location = new System.Drawing.Point(0, 150);
      this.payoutBox.Name = "payoutBox";
      this.payoutBox.Size = new System.Drawing.Size(300, 29);
      this.payoutBox.TabIndex = 9;
      this.payoutBox.UseSelectable = true;
      // 
      // subMultiplierBox
      // 
      this.subMultiplierBox.Lines = new string[] {
        "2"};
      this.subMultiplierBox.Location = new System.Drawing.Point(0, 204);
      this.subMultiplierBox.MaxLength = 32767;
      this.subMultiplierBox.Name = "subMultiplierBox";
      this.subMultiplierBox.PasswordChar = '\0';
      this.subMultiplierBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.subMultiplierBox.SelectedText = "";
      this.subMultiplierBox.Size = new System.Drawing.Size(300, 23);
      this.subMultiplierBox.TabIndex = 13;
      this.subMultiplierBox.Text = "2";
      this.subMultiplierBox.UseSelectable = true;
      this.subMultiplierBox.UseStyleColors = true;
      // 
      // metroLabel2
      // 
      this.metroLabel2.AutoSize = true;
      this.metroLabel2.Location = new System.Drawing.Point(0, 127);
      this.metroLabel2.Name = "metroLabel2";
      this.metroLabel2.Size = new System.Drawing.Size(56, 19);
      this.metroLabel2.TabIndex = 8;
      this.metroLabel2.Text = "Amount";
      // 
      // metroLabel4
      // 
      this.metroLabel4.AutoSize = true;
      this.metroLabel4.Location = new System.Drawing.Point(0, 182);
      this.metroLabel4.Name = "metroLabel4";
      this.metroLabel4.Size = new System.Drawing.Size(87, 19);
      this.metroLabel4.TabIndex = 12;
      this.metroLabel4.Text = "Sub Multipler";
      // 
      // intervalBox
      // 
      this.intervalBox.FormattingEnabled = true;
      this.intervalBox.ItemHeight = 23;
      this.intervalBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "10",
            "15",
            "20",
            "30",
            "60"});
      this.intervalBox.Location = new System.Drawing.Point(0, 95);
      this.intervalBox.Name = "intervalBox";
      this.intervalBox.Size = new System.Drawing.Size(300, 29);
      this.intervalBox.TabIndex = 6;
      this.intervalBox.UseSelectable = true;
      // 
      // metroLabel1
      // 
      this.metroLabel1.AutoSize = true;
      this.metroLabel1.Location = new System.Drawing.Point(0, 73);
      this.metroLabel1.Name = "metroLabel1";
      this.metroLabel1.Size = new System.Drawing.Size(52, 19);
      this.metroLabel1.TabIndex = 7;
      this.metroLabel1.Text = "Interval";
      // 
      // metroLabel3
      // 
      this.metroLabel3.AutoSize = true;
      this.metroLabel3.Location = new System.Drawing.Point(0, 25);
      this.metroLabel3.Name = "metroLabel3";
      this.metroLabel3.Size = new System.Drawing.Size(101, 19);
      this.metroLabel3.TabIndex = 10;
      this.metroLabel3.Text = "Currency Name";
      // 
      // channelTab
      // 
      this.channelTab.Controls.Add(this.payoutText);
      this.channelTab.Controls.Add(this.metroLabel15);
      this.channelTab.Controls.Add(this.metroLabel8);
      this.channelTab.Controls.Add(this.metroLabel7);
      this.channelTab.Controls.Add(this.ircChatPanel);
      this.channelTab.Controls.Add(this.ircStatusLabel);
      this.channelTab.Controls.Add(this.metroLabel6);
      this.channelTab.Controls.Add(this.ircCommandPanel);
      this.channelTab.HorizontalScrollbarBarColor = true;
      this.channelTab.HorizontalScrollbarHighlightOnWheel = false;
      this.channelTab.HorizontalScrollbarSize = 10;
      this.channelTab.Location = new System.Drawing.Point(4, 38);
      this.channelTab.Name = "channelTab";
      this.channelTab.Size = new System.Drawing.Size(761, 373);
      this.channelTab.TabIndex = 2;
      this.channelTab.Text = "Channel";
      this.channelTab.VerticalScrollbarBarColor = true;
      this.channelTab.VerticalScrollbarHighlightOnWheel = false;
      this.channelTab.VerticalScrollbarSize = 10;
      // 
      // payoutText
      // 
      this.payoutText.AutoSize = true;
      this.payoutText.Location = new System.Drawing.Point(463, 19);
      this.payoutText.Name = "payoutText";
      this.payoutText.Size = new System.Drawing.Size(122, 19);
      this.payoutText.TabIndex = 10;
      this.payoutText.Text = "0 x every 0 minutes";
      // 
      // metroLabel15
      // 
      this.metroLabel15.AutoSize = true;
      this.metroLabel15.Location = new System.Drawing.Point(382, 19);
      this.metroLabel15.Name = "metroLabel15";
      this.metroLabel15.Size = new System.Drawing.Size(53, 19);
      this.metroLabel15.TabIndex = 9;
      this.metroLabel15.Text = "Payouts";
      // 
      // metroLabel8
      // 
      this.metroLabel8.AutoSize = true;
      this.metroLabel8.Location = new System.Drawing.Point(382, 38);
      this.metroLabel8.Name = "metroLabel8";
      this.metroLabel8.Size = new System.Drawing.Size(87, 19);
      this.metroLabel8.TabIndex = 8;
      this.metroLabel8.Text = "Chat Console";
      // 
      // metroLabel7
      // 
      this.metroLabel7.AutoSize = true;
      this.metroLabel7.Location = new System.Drawing.Point(18, 38);
      this.metroLabel7.Name = "metroLabel7";
      this.metroLabel7.Size = new System.Drawing.Size(123, 19);
      this.metroLabel7.TabIndex = 7;
      this.metroLabel7.Text = "Command Console";
      // 
      // ircChatPanel
      // 
      this.ircChatPanel.AutoScroll = true;
      this.ircChatPanel.HorizontalScrollbar = true;
      this.ircChatPanel.HorizontalScrollbarBarColor = true;
      this.ircChatPanel.HorizontalScrollbarHighlightOnWheel = false;
      this.ircChatPanel.HorizontalScrollbarSize = 10;
      this.ircChatPanel.Location = new System.Drawing.Point(382, 63);
      this.ircChatPanel.Name = "ircChatPanel";
      this.ircChatPanel.Size = new System.Drawing.Size(358, 307);
      this.ircChatPanel.TabIndex = 6;
      this.ircChatPanel.VerticalScrollbar = true;
      this.ircChatPanel.VerticalScrollbarBarColor = true;
      this.ircChatPanel.VerticalScrollbarHighlightOnWheel = false;
      this.ircChatPanel.VerticalScrollbarSize = 10;
      // 
      // ircStatusLabel
      // 
      this.ircStatusLabel.AutoSize = true;
      this.ircStatusLabel.Location = new System.Drawing.Point(98, 19);
      this.ircStatusLabel.Name = "ircStatusLabel";
      this.ircStatusLabel.Size = new System.Drawing.Size(98, 19);
      this.ircStatusLabel.Style = MetroFramework.MetroColorStyle.Red;
      this.ircStatusLabel.TabIndex = 4;
      this.ircStatusLabel.Text = "Not Connected";
      this.ircStatusLabel.UseStyleColors = true;
      this.ircStatusLabel.WrapToLine = true;
      // 
      // metroLabel6
      // 
      this.metroLabel6.AutoSize = true;
      this.metroLabel6.Location = new System.Drawing.Point(18, 19);
      this.metroLabel6.Name = "metroLabel6";
      this.metroLabel6.Size = new System.Drawing.Size(61, 19);
      this.metroLabel6.TabIndex = 3;
      this.metroLabel6.Text = "Irc Status";
      // 
      // ircCommandPanel
      // 
      this.ircCommandPanel.AutoScroll = true;
      this.ircCommandPanel.HorizontalScrollbar = true;
      this.ircCommandPanel.HorizontalScrollbarBarColor = true;
      this.ircCommandPanel.HorizontalScrollbarHighlightOnWheel = true;
      this.ircCommandPanel.HorizontalScrollbarSize = 10;
      this.ircCommandPanel.Location = new System.Drawing.Point(18, 63);
      this.ircCommandPanel.Name = "ircCommandPanel";
      this.ircCommandPanel.Size = new System.Drawing.Size(358, 307);
      this.ircCommandPanel.TabIndex = 2;
      this.ircCommandPanel.VerticalScrollbar = true;
      this.ircCommandPanel.VerticalScrollbarBarColor = true;
      this.ircCommandPanel.VerticalScrollbarHighlightOnWheel = true;
      this.ircCommandPanel.VerticalScrollbarSize = 10;
      this.ircCommandPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ircStreamChat_ControlAdded);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::ABotReborn.Properties.Resources.ABotReborn;
      this.pictureBox1.Location = new System.Drawing.Point(334, 9);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(60, 60);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "ABotReborn";
      this.notifyIcon.Visible = true;
      this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
      this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmChannel,
            this.tsmStatus,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.toolStripMenuItem2});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(185, 104);
      // 
      // tsmChannel
      // 
      this.tsmChannel.Enabled = false;
      this.tsmChannel.Name = "tsmChannel";
      this.tsmChannel.Size = new System.Drawing.Size(184, 22);
      this.tsmChannel.Text = "Channel: None";
      // 
      // tsmStatus
      // 
      this.tsmStatus.Enabled = false;
      this.tsmStatus.Name = "tsmStatus";
      this.tsmStatus.Size = new System.Drawing.Size(184, 22);
      this.tsmStatus.Text = "Status: Disconnected";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
      this.toolStripMenuItem1.Text = "Open";
      this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
      this.toolStripMenuItem2.Text = "Exit";
      this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
      this.ClientSize = new System.Drawing.Size(818, 505);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.metroTabControl1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Resizable = false;
      this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
      this.Text = "ABotReborn · A Twitch.tv Bot";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.metroTabControl1.ResumeLayout(false);
      this.initialiseTab.ResumeLayout(false);
      this.initialiseTab.PerformLayout();
      this.settingsTab.ResumeLayout(false);
      this.metroPanel1.ResumeLayout(false);
      this.metroPanel1.PerformLayout();
      this.channelTab.ResumeLayout(false);
      this.channelTab.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private MetroFramework.Controls.MetroTabControl metroTabControl1;
    private MetroFramework.Controls.MetroTabPage initialiseTab;
    private MetroFramework.Controls.MetroTabPage settingsTab;
    private MetroFramework.Controls.MetroComboBox payoutBox;
    private MetroFramework.Controls.MetroLabel metroLabel2;
    private MetroFramework.Controls.MetroLabel metroLabel1;
    private MetroFramework.Controls.MetroComboBox intervalBox;
    private MetroFramework.Controls.MetroTextBox currencyBox;
    private MetroFramework.Controls.MetroLabel metroLabel3;
    private MetroFramework.Controls.MetroTextBox subMultiplierBox;
    private MetroFramework.Controls.MetroLabel metroLabel4;
    private MetroFramework.Controls.MetroButton startButton;
    private MetroFramework.Controls.MetroTextBox channelBox;
    private MetroFramework.Controls.MetroLabel metroLabel5;
    private MetroFramework.Controls.MetroTabPage channelTab;
    private MetroFramework.Controls.MetroLabel ircStatusLabel;
    private MetroFramework.Controls.MetroLabel metroLabel6;
    private MetroFramework.Controls.MetroPanel ircCommandPanel;
    private MetroFramework.Controls.MetroPanel ircChatPanel;
    private MetroFramework.Controls.MetroLabel metroLabel8;
    private MetroFramework.Controls.MetroLabel metroLabel7;
    private MetroFramework.Controls.MetroProgressSpinner connectionSpinner;
    private MetroFramework.Controls.MetroPanel metroPanel1;
    private MetroFramework.Controls.MetroLabel metroLabel9;
    private MetroFramework.Controls.MetroLabel metroLabel10;
    private MetroFramework.Controls.MetroLabel metroLabel12;
    private MetroFramework.Controls.MetroLabel metroLabel11;
    private MetroFramework.Controls.MetroToggle autoMessagesToggle;
    private MetroFramework.Controls.MetroTextBox autoMessage3Box;
    private MetroFramework.Controls.MetroTextBox autoMessage2Box;
    private MetroFramework.Controls.MetroTextBox autoMessage1Box;
    private MetroFramework.Controls.MetroLabel metroLabel14;
    private MetroFramework.Controls.MetroTextBox messageCounterMinBox;
    private MetroFramework.Controls.MetroLabel metroLabel13;
    private MetroFramework.Controls.MetroComboBox messageIntervalBox;
    private MetroFramework.Controls.MetroButton settingsSave;
    private MetroFramework.Controls.MetroLabel payoutText;
    private MetroFramework.Controls.MetroLabel metroLabel15;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem tsmChannel;
    private System.Windows.Forms.ToolStripMenuItem tsmStatus;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
  }
}