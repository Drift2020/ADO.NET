namespace Milioners
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Start = new System.Windows.Forms.Button();
            this.ExitG = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem0 = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьИгруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановатьИгруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_tolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CreatQvest = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_Quest = new System.Windows.Forms.ToolStripMenuItem();
            this.Dell_Question = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.оИгреToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Stop = new System.Windows.Forms.Button();
            this.QuestTable = new System.Windows.Forms.Label();
            this.Ansver_A = new System.Windows.Forms.Button();
            this.Ansver_B = new System.Windows.Forms.Button();
            this.Ansver_C = new System.Windows.Forms.Button();
            this.Ansver_D = new System.Windows.Forms.Button();
            this.HelpVariant = new System.Windows.Forms.GroupBox();
            this.FandF = new System.Windows.Forms.Button();
            this.HelpCall = new System.Windows.Forms.Button();
            this.HelpRoom = new System.Windows.Forms.Button();
            this.CallLabel = new System.Windows.Forms.Label();
            this.AnsverPictureBox = new System.Windows.Forms.PictureBox();
            this.CallPictureBox = new System.Windows.Forms.PictureBox();
            this.Exit = new System.Windows.Forms.Button();
            this.Flag = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AnsverLabel = new System.Windows.Forms.Label();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.HelpBar = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.NumberlistView = new System.Windows.Forms.ListView();
            this.TimeWindow = new System.Windows.Forms.Timer(this.components);
            this.TimeColor = new System.Windows.Forms.Timer(this.components);
            this.TimeTrueAnsver = new System.Windows.Forms.Timer(this.components);
            this.TimeCallHelp = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimeHelpRoom = new System.Windows.Forms.Timer(this.components);
            this.TimerAnsver = new System.Windows.Forms.Label();
            this.TimeAnsver = new System.Windows.Forms.Timer(this.components);
            this.TimeWin = new System.Windows.Forms.Timer(this.components);
            this.LableWin = new System.Windows.Forms.Label();
            this.TimeTrueAnsverLose = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.HelpVariant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnsverPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CallPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.HelpBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(294, 197);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(188, 58);
            this.Start.TabIndex = 1;
            this.Start.Text = "Начать игру";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.StartGames);
            // 
            // ExitG
            // 
            this.ExitG.Location = new System.Drawing.Point(294, 343);
            this.ExitG.Name = "ExitG";
            this.ExitG.Size = new System.Drawing.Size(188, 58);
            this.ExitG.TabIndex = 2;
            this.ExitG.Text = "Выход";
            this.ExitG.UseVisualStyleBackColor = true;
            this.ExitG.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem0,
            this.ToolStripMenuItem1,
            this.ToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem0
            // 
            this.ToolStripMenuItem0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьИгруToolStripMenuItem,
            this.остановатьИгруToolStripMenuItem,
            this.Exit_tolbar});
            this.ToolStripMenuItem0.Name = "ToolStripMenuItem0";
            this.ToolStripMenuItem0.Size = new System.Drawing.Size(46, 20);
            this.ToolStripMenuItem0.Text = "Игра";
            // 
            // начатьИгруToolStripMenuItem
            // 
            this.начатьИгруToolStripMenuItem.Name = "начатьИгруToolStripMenuItem";
            this.начатьИгруToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.начатьИгруToolStripMenuItem.Text = "Начать игру";
            this.начатьИгруToolStripMenuItem.Click += new System.EventHandler(this.StartGames);
            // 
            // остановатьИгруToolStripMenuItem
            // 
            this.остановатьИгруToolStripMenuItem.Name = "остановатьИгруToolStripMenuItem";
            this.остановатьИгруToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.остановатьИгруToolStripMenuItem.Text = "Остановать игру";
            this.остановатьИгруToolStripMenuItem.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Exit_tolbar
            // 
            this.Exit_tolbar.Name = "Exit_tolbar";
            this.Exit_tolbar.Size = new System.Drawing.Size(165, 22);
            this.Exit_tolbar.Text = "Выход";
            this.Exit_tolbar.Click += new System.EventHandler(this.button2_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreatQvest,
            this.Edit_Quest,
            this.Dell_Question});
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(106, 20);
            this.ToolStripMenuItem1.Text = "Администратор";
            // 
            // CreatQvest
            // 
            this.CreatQvest.Name = "CreatQvest";
            this.CreatQvest.Size = new System.Drawing.Size(185, 22);
            this.CreatQvest.Text = "Создать вопрос";
            this.CreatQvest.Click += new System.EventHandler(this.CreatQvest_Click);
            // 
            // Edit_Quest
            // 
            this.Edit_Quest.Name = "Edit_Quest";
            this.Edit_Quest.Size = new System.Drawing.Size(185, 22);
            this.Edit_Quest.Text = "Изменение вопроса";
            this.Edit_Quest.Click += new System.EventHandler(this.Edit_Quest_Click);
            // 
            // Dell_Question
            // 
            this.Dell_Question.Name = "Dell_Question";
            this.Dell_Question.Size = new System.Drawing.Size(185, 22);
            this.Dell_Question.Text = "Удаление вопроса";
            this.Dell_Question.Click += new System.EventHandler(this.Dell_Question_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оИгреToolStripMenuItem});
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(68, 20);
            this.ToolStripMenuItem2.Text = "Помощь";
            // 
            // оИгреToolStripMenuItem
            // 
            this.оИгреToolStripMenuItem.Name = "оИгреToolStripMenuItem";
            this.оИгреToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.оИгреToolStripMenuItem.Text = "О игре";
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Stop.FlatAppearance.BorderSize = 0;
            this.Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stop.ForeColor = System.Drawing.Color.Yellow;
            this.Stop.Location = new System.Drawing.Point(156, 27);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(71, 32);
            this.Stop.TabIndex = 6;
            this.Stop.Text = "Стоп";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // QuestTable
            // 
            this.QuestTable.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.QuestTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestTable.ForeColor = System.Drawing.Color.Yellow;
            this.QuestTable.Location = new System.Drawing.Point(104, 326);
            this.QuestTable.Name = "QuestTable";
            this.QuestTable.Size = new System.Drawing.Size(436, 56);
            this.QuestTable.TabIndex = 11;
            this.QuestTable.Text = "label1";
            this.QuestTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ansver_A
            // 
            this.Ansver_A.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Ansver_A.FlatAppearance.BorderColor = System.Drawing.Color.LightYellow;
            this.Ansver_A.FlatAppearance.BorderSize = 2;
            this.Ansver_A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ansver_A.ForeColor = System.Drawing.Color.Yellow;
            this.Ansver_A.Location = new System.Drawing.Point(105, 407);
            this.Ansver_A.Name = "Ansver_A";
            this.Ansver_A.Size = new System.Drawing.Size(198, 35);
            this.Ansver_A.TabIndex = 12;
            this.Ansver_A.Text = "button3";
            this.Ansver_A.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ansver_A.UseVisualStyleBackColor = false;
            this.Ansver_A.Click += new System.EventHandler(this.AnsverClic);
            // 
            // Ansver_B
            // 
            this.Ansver_B.BackColor = System.Drawing.Color.Black;
            this.Ansver_B.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Ansver_B.FlatAppearance.BorderSize = 2;
            this.Ansver_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ansver_B.ForeColor = System.Drawing.Color.Yellow;
            this.Ansver_B.Location = new System.Drawing.Point(330, 407);
            this.Ansver_B.Name = "Ansver_B";
            this.Ansver_B.Size = new System.Drawing.Size(198, 35);
            this.Ansver_B.TabIndex = 13;
            this.Ansver_B.Text = "button4";
            this.Ansver_B.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ansver_B.UseVisualStyleBackColor = false;
            this.Ansver_B.Click += new System.EventHandler(this.AnsverClic);
            // 
            // Ansver_C
            // 
            this.Ansver_C.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Ansver_C.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Ansver_C.FlatAppearance.BorderSize = 2;
            this.Ansver_C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ansver_C.ForeColor = System.Drawing.Color.Yellow;
            this.Ansver_C.Location = new System.Drawing.Point(105, 448);
            this.Ansver_C.Name = "Ansver_C";
            this.Ansver_C.Size = new System.Drawing.Size(198, 35);
            this.Ansver_C.TabIndex = 14;
            this.Ansver_C.Text = "button5";
            this.Ansver_C.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ansver_C.UseVisualStyleBackColor = false;
            this.Ansver_C.Click += new System.EventHandler(this.AnsverClic);
            // 
            // Ansver_D
            // 
            this.Ansver_D.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Ansver_D.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Ansver_D.FlatAppearance.BorderSize = 2;
            this.Ansver_D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ansver_D.ForeColor = System.Drawing.Color.Yellow;
            this.Ansver_D.Location = new System.Drawing.Point(330, 448);
            this.Ansver_D.Name = "Ansver_D";
            this.Ansver_D.Size = new System.Drawing.Size(198, 35);
            this.Ansver_D.TabIndex = 15;
            this.Ansver_D.Text = "button6";
            this.Ansver_D.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ansver_D.UseVisualStyleBackColor = false;
            this.Ansver_D.Click += new System.EventHandler(this.AnsverClic);
            // 
            // HelpVariant
            // 
            this.HelpVariant.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HelpVariant.Controls.Add(this.FandF);
            this.HelpVariant.Controls.Add(this.HelpCall);
            this.HelpVariant.Controls.Add(this.HelpRoom);
            this.HelpVariant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.HelpVariant.Location = new System.Drawing.Point(540, 27);
            this.HelpVariant.Name = "HelpVariant";
            this.HelpVariant.Size = new System.Drawing.Size(200, 73);
            this.HelpVariant.TabIndex = 16;
            this.HelpVariant.TabStop = false;
            this.HelpVariant.Text = "Подсказки";
            // 
            // FandF
            // 
            this.FandF.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FandF.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.FandF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FandF.Image = global::Milioners.Properties.Resources._1;
            this.FandF.Location = new System.Drawing.Point(6, 19);
            this.FandF.Name = "FandF";
            this.FandF.Size = new System.Drawing.Size(53, 33);
            this.FandF.TabIndex = 8;
            this.FandF.UseVisualStyleBackColor = false;
            this.FandF.Click += new System.EventHandler(this.FandF_Click);
            // 
            // HelpCall
            // 
            this.HelpCall.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.HelpCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpCall.Image = global::Milioners.Properties.Resources._2;
            this.HelpCall.Location = new System.Drawing.Point(74, 19);
            this.HelpCall.Name = "HelpCall";
            this.HelpCall.Size = new System.Drawing.Size(53, 33);
            this.HelpCall.TabIndex = 9;
            this.HelpCall.UseVisualStyleBackColor = true;
            this.HelpCall.Click += new System.EventHandler(this.HelpCall_Click);
            // 
            // HelpRoom
            // 
            this.HelpRoom.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.HelpRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpRoom.Image = global::Milioners.Properties.Resources._3;
            this.HelpRoom.Location = new System.Drawing.Point(141, 19);
            this.HelpRoom.Name = "HelpRoom";
            this.HelpRoom.Size = new System.Drawing.Size(53, 33);
            this.HelpRoom.TabIndex = 10;
            this.HelpRoom.UseVisualStyleBackColor = true;
            this.HelpRoom.Click += new System.EventHandler(this.HelpRoom_Click);
            // 
            // CallLabel
            // 
            this.CallLabel.BackColor = System.Drawing.Color.DarkCyan;
            this.CallLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CallLabel.ForeColor = System.Drawing.Color.Yellow;
            this.CallLabel.Location = new System.Drawing.Point(168, 130);
            this.CallLabel.Name = "CallLabel";
            this.CallLabel.Size = new System.Drawing.Size(173, 52);
            this.CallLabel.TabIndex = 18;
            this.CallLabel.Text = "label1";
            this.CallLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnsverPictureBox
            // 
            this.AnsverPictureBox.Image = global::Milioners.Properties.Resources.Безымянный;
            this.AnsverPictureBox.Location = new System.Drawing.Point(447, 228);
            this.AnsverPictureBox.Name = "AnsverPictureBox";
            this.AnsverPictureBox.Size = new System.Drawing.Size(81, 95);
            this.AnsverPictureBox.TabIndex = 19;
            this.AnsverPictureBox.TabStop = false;
            // 
            // CallPictureBox
            // 
            this.CallPictureBox.Image = global::Milioners.Properties.Resources.zvonok;
            this.CallPictureBox.Location = new System.Drawing.Point(35, 98);
            this.CallPictureBox.Name = "CallPictureBox";
            this.CallPictureBox.Size = new System.Drawing.Size(133, 107);
            this.CallPictureBox.TabIndex = 17;
            this.CallPictureBox.TabStop = false;
            // 
            // Exit
            // 
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Image = global::Milioners.Properties.Resources.Exit;
            this.Exit.Location = new System.Drawing.Point(68, 27);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(62, 32);
            this.Exit.TabIndex = 5;
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Flag
            // 
            this.Flag.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Flag.FlatAppearance.BorderSize = 0;
            this.Flag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Flag.Image = global::Milioners.Properties.Resources._new;
            this.Flag.Location = new System.Drawing.Point(0, 27);
            this.Flag.Name = "Flag";
            this.Flag.Size = new System.Drawing.Size(62, 32);
            this.Flag.TabIndex = 4;
            this.Flag.UseVisualStyleBackColor = false;
            this.Flag.Click += new System.EventHandler(this.Flag_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(743, 551);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AnsverLabel
            // 
            this.AnsverLabel.BackColor = System.Drawing.Color.DarkCyan;
            this.AnsverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnsverLabel.ForeColor = System.Drawing.Color.Yellow;
            this.AnsverLabel.Location = new System.Drawing.Point(274, 282);
            this.AnsverLabel.Name = "AnsverLabel";
            this.AnsverLabel.Size = new System.Drawing.Size(173, 41);
            this.AnsverLabel.TabIndex = 20;
            this.AnsverLabel.Text = "label1";
            this.AnsverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(46, 60);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(81, 13);
            this.progressBar3.Step = 1;
            this.progressBar3.TabIndex = 2;
            this.progressBar3.Value = 1;
            // 
            // HelpBar
            // 
            this.HelpBar.BackColor = System.Drawing.Color.Blue;
            this.HelpBar.Controls.Add(this.label4);
            this.HelpBar.Controls.Add(this.label3);
            this.HelpBar.Controls.Add(this.label2);
            this.HelpBar.Controls.Add(this.label1);
            this.HelpBar.Controls.Add(this.progressBar4);
            this.HelpBar.Controls.Add(this.progressBar2);
            this.HelpBar.Controls.Add(this.progressBar1);
            this.HelpBar.Controls.Add(this.progressBar3);
            this.HelpBar.ForeColor = System.Drawing.Color.Yellow;
            this.HelpBar.Location = new System.Drawing.Point(401, 27);
            this.HelpBar.Name = "HelpBar";
            this.HelpBar.Size = new System.Drawing.Size(139, 111);
            this.HelpBar.TabIndex = 21;
            this.HelpBar.TabStop = false;
            this.HelpBar.Text = "Подсказка";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(46, 79);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(81, 13);
            this.progressBar4.Step = 1;
            this.progressBar4.TabIndex = 5;
            this.progressBar4.Value = 1;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(46, 41);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(81, 13);
            this.progressBar2.Step = 1;
            this.progressBar2.TabIndex = 4;
            this.progressBar2.Value = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(46, 23);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(81, 13);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Value = 1;
            // 
            // NumberlistView
            // 
            this.NumberlistView.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.NumberlistView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberlistView.FullRowSelect = true;
            this.NumberlistView.Location = new System.Drawing.Point(541, 74);
            this.NumberlistView.Margin = new System.Windows.Forms.Padding(10);
            this.NumberlistView.Name = "NumberlistView";
            this.NumberlistView.Size = new System.Drawing.Size(203, 485);
            this.NumberlistView.TabIndex = 22;
            this.NumberlistView.UseCompatibleStateImageBehavior = false;
            this.NumberlistView.View = System.Windows.Forms.View.Details;
            // 
            // TimerAnsver
            // 
            this.TimerAnsver.BackColor = System.Drawing.Color.AliceBlue;
            this.TimerAnsver.Location = new System.Drawing.Point(291, 37);
            this.TimerAnsver.Name = "TimerAnsver";
            this.TimerAnsver.Size = new System.Drawing.Size(69, 17);
            this.TimerAnsver.TabIndex = 24;
            this.TimerAnsver.Text = "60";
            this.TimerAnsver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeWin
            // 
            this.TimeWin.Interval = 1000;
            // 
            // LableWin
            // 
            this.LableWin.BackColor = System.Drawing.Color.AliceBlue;
            this.LableWin.Font = new System.Drawing.Font("Mistral", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LableWin.Location = new System.Drawing.Point(291, 228);
            this.LableWin.Name = "LableWin";
            this.LableWin.Size = new System.Drawing.Size(212, 126);
            this.LableWin.TabIndex = 25;
            this.LableWin.Text = "Вы";
            this.LableWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(740, 546);
            this.Controls.Add(this.LableWin);
            this.Controls.Add(this.TimerAnsver);
            this.Controls.Add(this.NumberlistView);
            this.Controls.Add(this.HelpBar);
            this.Controls.Add(this.AnsverLabel);
            this.Controls.Add(this.AnsverPictureBox);
            this.Controls.Add(this.CallLabel);
            this.Controls.Add(this.CallPictureBox);
            this.Controls.Add(this.HelpVariant);
            this.Controls.Add(this.Ansver_D);
            this.Controls.Add(this.Ansver_C);
            this.Controls.Add(this.Ansver_B);
            this.Controls.Add(this.Ansver_A);
            this.Controls.Add(this.QuestTable);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Flag);
            this.Controls.Add(this.ExitG);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Миллионер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exit_tolbar_Click);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.HelpVariant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnsverPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CallPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.HelpBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
      
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button ExitG;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem0;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem начатьИгруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem остановатьИгруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_tolbar;
        private System.Windows.Forms.ToolStripMenuItem CreatQvest;
        private System.Windows.Forms.ToolStripMenuItem Edit_Quest;
        private System.Windows.Forms.ToolStripMenuItem Dell_Question;
        private System.Windows.Forms.ToolStripMenuItem оИгреToolStripMenuItem;
        private System.Windows.Forms.Button Flag;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button FandF;
        private System.Windows.Forms.Button HelpCall;
        private System.Windows.Forms.Button HelpRoom;
        private System.Windows.Forms.Label QuestTable;
        private System.Windows.Forms.Button Ansver_A;
        private System.Windows.Forms.Button Ansver_B;
        private System.Windows.Forms.Button Ansver_C;
        private System.Windows.Forms.Button Ansver_D;
        private System.Windows.Forms.GroupBox HelpVariant;
        private System.Windows.Forms.PictureBox CallPictureBox;
        private System.Windows.Forms.Label CallLabel;
        private System.Windows.Forms.PictureBox AnsverPictureBox;
        private System.Windows.Forms.Label AnsverLabel;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.GroupBox HelpBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListView NumberlistView;
        private System.Windows.Forms.Timer TimeWindow;
        private System.Windows.Forms.Timer TimeColor;
        private System.Windows.Forms.Timer TimeTrueAnsver;
        private System.Windows.Forms.Timer TimeCallHelp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer TimeHelpRoom;
        private System.Windows.Forms.Label TimerAnsver;
        private System.Windows.Forms.Timer TimeAnsver;
        private System.Windows.Forms.Timer TimeWin;
        private System.Windows.Forms.Label LableWin;
        private System.Windows.Forms.Timer TimeTrueAnsverLose;
    }
}

