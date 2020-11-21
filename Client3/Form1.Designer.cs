namespace WindowsApplication2
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
            this.btLogout = new System.Windows.Forms.Button();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sitExamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enlargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btLogin = new System.Windows.Forms.Button();
            this.lbStatusInfo = new System.Windows.Forms.Label();
            this.lxQuestions = new System.Windows.Forms.ListBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.gbAnswers = new System.Windows.Forms.GroupBox();
            this.cbD = new System.Windows.Forms.CheckBox();
            this.cbC = new System.Windows.Forms.CheckBox();
            this.cbB = new System.Windows.Forms.CheckBox();
            this.cbA = new System.Windows.Forms.CheckBox();
            this.tbD = new System.Windows.Forms.TextBox();
            this.tbC = new System.Windows.Forms.TextBox();
            this.tbB = new System.Windows.Forms.TextBox();
            this.tbA = new System.Windows.Forms.TextBox();
            this.lbQuestion = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.btNext = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.lbQuestions = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.tbQuestion = new System.Windows.Forms.RichTextBox();
            this.tbByUser = new System.Windows.Forms.TextBox();
            this.tbByTest = new System.Windows.Forms.TextBox();
            this.lbByUserName = new System.Windows.Forms.Label();
            this.lbByTestName = new System.Windows.Forms.Label();
            this.btQuery = new System.Windows.Forms.Button();
            this.cbByUser = new System.Windows.Forms.CheckBox();
            this.cbByTest = new System.Windows.Forms.CheckBox();
            this.btPrevious = new System.Windows.Forms.Button();
            this.btRecord = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btHide = new System.Windows.Forms.Button();
            this.btSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbAnswers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogout
            // 
            this.btLogout.Location = new System.Drawing.Point(96, 376);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(75, 23);
            this.btLogout.TabIndex = 0;
            this.btLogout.Text = "Log Out";
            this.btLogout.UseVisualStyleBackColor = true;
            this.btLogout.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgView
            // 
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(467, 41);
            this.dgView.Name = "dgView";
            this.dgView.Size = new System.Drawing.Size(258, 127);
            this.dgView.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.authorToolStripMenuItem,
            this.readerToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mainToolStripMenuItem.Text = "Start";
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logInToolStripMenuItem.Text = "Log In";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Enabled = false;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTestToolStripMenuItem,
            this.viewResultsToolStripMenuItem,
            this.editTestToolStripMenuItem});
            this.authorToolStripMenuItem.Enabled = false;
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            this.authorToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.authorToolStripMenuItem.Text = "Author";
            // 
            // newTestToolStripMenuItem
            // 
            this.newTestToolStripMenuItem.Name = "newTestToolStripMenuItem";
            this.newTestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newTestToolStripMenuItem.Text = "New exam";
            this.newTestToolStripMenuItem.Click += new System.EventHandler(this.newTestToolStripMenuItem_Click);
            // 
            // viewResultsToolStripMenuItem
            // 
            this.viewResultsToolStripMenuItem.Name = "viewResultsToolStripMenuItem";
            this.viewResultsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewResultsToolStripMenuItem.Text = "View results";
            this.viewResultsToolStripMenuItem.Click += new System.EventHandler(this.viewResultsToolStripMenuItem_Click);
            // 
            // editTestToolStripMenuItem
            // 
            this.editTestToolStripMenuItem.Name = "editTestToolStripMenuItem";
            this.editTestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editTestToolStripMenuItem.Text = "Edit exam";
            this.editTestToolStripMenuItem.Visible = false;
            // 
            // readerToolStripMenuItem
            // 
            this.readerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sitExamToolStripMenuItem});
            this.readerToolStripMenuItem.Name = "readerToolStripMenuItem";
            this.readerToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.readerToolStripMenuItem.Text = "Reader";
            // 
            // sitExamToolStripMenuItem
            // 
            this.sitExamToolStripMenuItem.Name = "sitExamToolStripMenuItem";
            this.sitExamToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sitExamToolStripMenuItem.Text = "Sit exam";
            this.sitExamToolStripMenuItem.Click += new System.EventHandler(this.sitExamToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enlargeToolStripMenuItem,
            this.smallToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            // 
            // enlargeToolStripMenuItem
            // 
            this.enlargeToolStripMenuItem.Name = "enlargeToolStripMenuItem";
            this.enlargeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.enlargeToolStripMenuItem.Text = "Enlarge";
            this.enlargeToolStripMenuItem.Click += new System.EventHandler(this.enlargeToolStripMenuItem_Click);
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.smallToolStripMenuItem.Text = "Small";
            this.smallToolStripMenuItem.Click += new System.EventHandler(this.smallToolStripMenuItem_Click);
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(18, 376);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(72, 23);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "Log In";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // lbStatusInfo
            // 
            this.lbStatusInfo.AutoSize = true;
            this.lbStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatusInfo.Location = new System.Drawing.Point(15, 350);
            this.lbStatusInfo.Name = "lbStatusInfo";
            this.lbStatusInfo.Size = new System.Drawing.Size(92, 16);
            this.lbStatusInfo.TabIndex = 4;
            this.lbStatusInfo.Text = "Not Logged In";
            // 
            // lxQuestions
            // 
            this.lxQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lxQuestions.FormattingEnabled = true;
            this.lxQuestions.Location = new System.Drawing.Point(269, 53);
            this.lxQuestions.Name = "lxQuestions";
            this.lxQuestions.Size = new System.Drawing.Size(169, 147);
            this.lxQuestions.TabIndex = 5;
            this.lxQuestions.Visible = false;
            this.lxQuestions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lxQuestions_MouseDoubleClick);
            this.lxQuestions.SelectedIndexChanged += new System.EventHandler(this.lxQuestions_SelectedIndexChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(45, 38);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(206, 20);
            this.tbTitle.TabIndex = 6;
            this.tbTitle.Visible = false;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(12, 41);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(27, 13);
            this.lbTitle.TabIndex = 7;
            this.lbTitle.Text = "Title";
            this.lbTitle.Visible = false;
            // 
            // gbAnswers
            // 
            this.gbAnswers.Controls.Add(this.cbD);
            this.gbAnswers.Controls.Add(this.cbC);
            this.gbAnswers.Controls.Add(this.cbB);
            this.gbAnswers.Controls.Add(this.cbA);
            this.gbAnswers.Controls.Add(this.tbD);
            this.gbAnswers.Controls.Add(this.tbC);
            this.gbAnswers.Controls.Add(this.tbB);
            this.gbAnswers.Controls.Add(this.tbA);
            this.gbAnswers.Location = new System.Drawing.Point(17, 114);
            this.gbAnswers.Name = "gbAnswers";
            this.gbAnswers.Size = new System.Drawing.Size(234, 185);
            this.gbAnswers.TabIndex = 9;
            this.gbAnswers.TabStop = false;
            this.gbAnswers.Text = "Answers";
            // 
            // cbD
            // 
            this.cbD.AutoSize = true;
            this.cbD.Location = new System.Drawing.Point(18, 157);
            this.cbD.Name = "cbD";
            this.cbD.Size = new System.Drawing.Size(15, 14);
            this.cbD.TabIndex = 19;
            this.cbD.UseVisualStyleBackColor = true;
            this.cbD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbD_MouseClick);
            // 
            // cbC
            // 
            this.cbC.AutoSize = true;
            this.cbC.Location = new System.Drawing.Point(18, 120);
            this.cbC.Name = "cbC";
            this.cbC.Size = new System.Drawing.Size(15, 14);
            this.cbC.TabIndex = 18;
            this.cbC.UseVisualStyleBackColor = true;
            this.cbC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbC_MouseClick);
            // 
            // cbB
            // 
            this.cbB.AutoSize = true;
            this.cbB.Location = new System.Drawing.Point(18, 79);
            this.cbB.Name = "cbB";
            this.cbB.Size = new System.Drawing.Size(15, 14);
            this.cbB.TabIndex = 17;
            this.cbB.UseVisualStyleBackColor = true;
            this.cbB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbB_MouseClick);
            // 
            // cbA
            // 
            this.cbA.AutoSize = true;
            this.cbA.Location = new System.Drawing.Point(18, 40);
            this.cbA.Name = "cbA";
            this.cbA.Size = new System.Drawing.Size(15, 14);
            this.cbA.TabIndex = 16;
            this.cbA.UseVisualStyleBackColor = true;
            this.cbA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbA_MouseClick);
            // 
            // tbD
            // 
            this.tbD.Location = new System.Drawing.Point(47, 154);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(175, 20);
            this.tbD.TabIndex = 15;
            // 
            // tbC
            // 
            this.tbC.Location = new System.Drawing.Point(47, 117);
            this.tbC.Name = "tbC";
            this.tbC.Size = new System.Drawing.Size(175, 20);
            this.tbC.TabIndex = 14;
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(47, 76);
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(175, 20);
            this.tbB.TabIndex = 13;
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(47, 34);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(175, 20);
            this.tbA.TabIndex = 12;
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Location = new System.Drawing.Point(9, 85);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(49, 13);
            this.lbQuestion.TabIndex = 10;
            this.lbQuestion.Text = "Question";
            this.lbQuestion.Visible = false;
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(56, 85);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(13, 13);
            this.lbNumber.TabIndex = 11;
            this.lbNumber.Text = "1";
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(111, 314);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(43, 23);
            this.btNext.TabIndex = 12;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Visible = false;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(177, 376);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(79, 23);
            this.btSend.TabIndex = 13;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Visible = false;
            this.btSend.Click += new System.EventHandler(this.btOver_Click);
            // 
            // lbQuestions
            // 
            this.lbQuestions.AutoSize = true;
            this.lbQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbQuestions.Location = new System.Drawing.Point(300, 34);
            this.lbQuestions.Name = "lbQuestions";
            this.lbQuestions.Size = new System.Drawing.Size(68, 16);
            this.lbQuestions.TabIndex = 14;
            this.lbQuestions.Text = "Questions";
            this.lbQuestions.Visible = false;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(4, 314);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(46, 23);
            this.btDelete.TabIndex = 15;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Visible = false;
            // 
            // tbQuestion
            // 
            this.tbQuestion.Location = new System.Drawing.Point(75, 82);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(176, 35);
            this.tbQuestion.TabIndex = 16;
            this.tbQuestion.Text = "";
            this.tbQuestion.Visible = false;
            // 
            // tbByUser
            // 
            this.tbByUser.Location = new System.Drawing.Point(519, 174);
            this.tbByUser.Name = "tbByUser";
            this.tbByUser.Size = new System.Drawing.Size(134, 20);
            this.tbByUser.TabIndex = 17;
            // 
            // tbByTest
            // 
            this.tbByTest.Location = new System.Drawing.Point(519, 207);
            this.tbByTest.Name = "tbByTest";
            this.tbByTest.Size = new System.Drawing.Size(134, 20);
            this.tbByTest.TabIndex = 18;
            this.tbByTest.Visible = false;
            // 
            // lbByUserName
            // 
            this.lbByUserName.AutoSize = true;
            this.lbByUserName.Location = new System.Drawing.Point(469, 177);
            this.lbByUserName.Name = "lbByUserName";
            this.lbByUserName.Size = new System.Drawing.Size(44, 13);
            this.lbByUserName.TabIndex = 19;
            this.lbByUserName.Text = "By User";
            // 
            // lbByTestName
            // 
            this.lbByTestName.AutoSize = true;
            this.lbByTestName.Location = new System.Drawing.Point(469, 210);
            this.lbByTestName.Name = "lbByTestName";
            this.lbByTestName.Size = new System.Drawing.Size(43, 13);
            this.lbByTestName.TabIndex = 20;
            this.lbByTestName.Text = "By Test";
            this.lbByTestName.Visible = false;
            // 
            // btQuery
            // 
            this.btQuery.Location = new System.Drawing.Point(594, 234);
            this.btQuery.Name = "btQuery";
            this.btQuery.Size = new System.Drawing.Size(59, 23);
            this.btQuery.TabIndex = 21;
            this.btQuery.Text = "Search";
            this.btQuery.UseVisualStyleBackColor = true;
            this.btQuery.Click += new System.EventHandler(this.btQuery_Click);
            // 
            // cbByUser
            // 
            this.cbByUser.AutoSize = true;
            this.cbByUser.Location = new System.Drawing.Point(659, 177);
            this.cbByUser.Name = "cbByUser";
            this.cbByUser.Size = new System.Drawing.Size(15, 14);
            this.cbByUser.TabIndex = 22;
            this.cbByUser.UseVisualStyleBackColor = true;
            this.cbByUser.Visible = false;
            // 
            // cbByTest
            // 
            this.cbByTest.AutoSize = true;
            this.cbByTest.Location = new System.Drawing.Point(659, 213);
            this.cbByTest.Name = "cbByTest";
            this.cbByTest.Size = new System.Drawing.Size(15, 14);
            this.cbByTest.TabIndex = 23;
            this.cbByTest.UseVisualStyleBackColor = true;
            this.cbByTest.Visible = false;
            // 
            // btPrevious
            // 
            this.btPrevious.Location = new System.Drawing.Point(64, 314);
            this.btPrevious.Name = "btPrevious";
            this.btPrevious.Size = new System.Drawing.Size(41, 23);
            this.btPrevious.TabIndex = 24;
            this.btPrevious.Text = "Prev";
            this.btPrevious.UseVisualStyleBackColor = true;
            this.btPrevious.Click += new System.EventHandler(this.btPrevious_Click);
            // 
            // btRecord
            // 
            this.btRecord.Location = new System.Drawing.Point(224, 314);
            this.btRecord.Name = "btRecord";
            this.btRecord.Size = new System.Drawing.Size(43, 23);
            this.btRecord.TabIndex = 25;
            this.btRecord.Text = "Save";
            this.btRecord.UseVisualStyleBackColor = true;
            this.btRecord.Click += new System.EventHandler(this.btRecord_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(172, 314);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(46, 23);
            this.btClear.TabIndex = 26;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Visible = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btHide
            // 
            this.btHide.Location = new System.Drawing.Point(519, 234);
            this.btHide.Name = "btHide";
            this.btHide.Size = new System.Drawing.Size(58, 23);
            this.btHide.TabIndex = 27;
            this.btHide.Text = "Hide";
            this.btHide.UseVisualStyleBackColor = true;
            this.btHide.Visible = false;
            this.btHide.Click += new System.EventHandler(this.btHide_Click);
            // 
            // btSelect
            // 
            this.btSelect.Location = new System.Drawing.Point(375, 208);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(63, 23);
            this.btSelect.TabIndex = 28;
            this.btSelect.Text = "Select";
            this.btSelect.UseVisualStyleBackColor = true;
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.btSelect);
            this.Controls.Add(this.btHide);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btRecord);
            this.Controls.Add(this.btPrevious);
            this.Controls.Add(this.cbByTest);
            this.Controls.Add(this.cbByUser);
            this.Controls.Add(this.btQuery);
            this.Controls.Add(this.lbByTestName);
            this.Controls.Add(this.lbByUserName);
            this.Controls.Add(this.tbByTest);
            this.Controls.Add(this.tbByUser);
            this.Controls.Add(this.tbQuestion);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.lbQuestions);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.gbAnswers);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lxQuestions);
            this.Controls.Add(this.lbStatusInfo);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.dgView);
            this.Controls.Add(this.btLogout);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "OleDB-Remoting Tests by Todor Arnaudov";
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbAnswers.ResumeLayout(false);
            this.gbAnswers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.Label lbStatusInfo;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sitExamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ListBox lxQuestions;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox gbAnswers;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.TextBox tbC;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.Label lbQuestion;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.CheckBox cbD;
        private System.Windows.Forms.CheckBox cbC;
        private System.Windows.Forms.CheckBox cbB;
        private System.Windows.Forms.CheckBox cbA;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label lbQuestions;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.RichTextBox tbQuestion;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enlargeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
        private System.Windows.Forms.TextBox tbByUser;
        private System.Windows.Forms.TextBox tbByTest;
        private System.Windows.Forms.Label lbByUserName;
        private System.Windows.Forms.Label lbByTestName;
        private System.Windows.Forms.Button btQuery;
        private System.Windows.Forms.CheckBox cbByUser;
        private System.Windows.Forms.CheckBox cbByTest;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btPrevious;
        private System.Windows.Forms.Button btRecord;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btHide;
        private System.Windows.Forms.Button btSelect;
    }
}

