namespace WindowsFormsApp1
{
    partial class FormMain
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
            this.btnFormWebCam = new System.Windows.Forms.Button();
            this.cbTRFFaces = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTRFReset = new System.Windows.Forms.Button();
            this.btnTRFStop = new System.Windows.Forms.Button();
            this.btnTRFDelete = new System.Windows.Forms.Button();
            this.btnTRFSave = new System.Windows.Forms.Button();
            this.btnTRFStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbQA3 = new System.Windows.Forms.CheckBox();
            this.cbQA2 = new System.Windows.Forms.CheckBox();
            this.cbQA1 = new System.Windows.Forms.CheckBox();
            this.btnQSET6 = new System.Windows.Forms.Button();
            this.btnQSET5 = new System.Windows.Forms.Button();
            this.btnQSET4 = new System.Windows.Forms.Button();
            this.btnQSET3 = new System.Windows.Forms.Button();
            this.btnQSET2 = new System.Windows.Forms.Button();
            this.btnQSET1 = new System.Windows.Forms.Button();
            this.btnQBereken1 = new System.Windows.Forms.Button();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.tbQGRP6_TOT = new System.Windows.Forms.TextBox();
            this.tbQGRP6_T1 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tbQGRP5_TOT = new System.Windows.Forms.TextBox();
            this.tbQGRP5_T1 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.tbQGRP4_TOT = new System.Windows.Forms.TextBox();
            this.tbQGRP4_T1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tbQGRP3_TOT = new System.Windows.Forms.TextBox();
            this.tbQGRP3_T1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbQGRP2_TOT = new System.Windows.Forms.TextBox();
            this.tbQGRP2_T1 = new System.Windows.Forms.TextBox();
            this.tbQGrp1 = new System.Windows.Forms.TextBox();
            this.tbQGRP1_TOT = new System.Windows.Forms.TextBox();
            this.tbQGRP1_T1 = new System.Windows.Forms.TextBox();
            this.cbQGrp = new System.Windows.Forms.ComboBox();
            this.btnQStop = new System.Windows.Forms.Button();
            this.btnQStart = new System.Windows.Forms.Button();
            this.cbQNbr = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTFStop = new System.Windows.Forms.Button();
            this.btnTFStart = new System.Windows.Forms.Button();
            this.cbTFFaces = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnTGStop = new System.Windows.Forms.Button();
            this.btnTGStart = new System.Windows.Forms.Button();
            this.cbTGGroups = new System.Windows.Forms.ComboBox();
            this.btnFormTrainFaceOpen = new System.Windows.Forms.Button();
            this.btnTrain1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFormWebCam
            // 
            this.btnFormWebCam.Location = new System.Drawing.Point(12, 628);
            this.btnFormWebCam.Name = "btnFormWebCam";
            this.btnFormWebCam.Size = new System.Drawing.Size(280, 41);
            this.btnFormWebCam.TabIndex = 13;
            this.btnFormWebCam.Text = "WEBCAM";
            this.btnFormWebCam.UseVisualStyleBackColor = true;
            this.btnFormWebCam.Click += new System.EventHandler(this.btnFormWebCam_Click);
            // 
            // cbTRFFaces
            // 
            this.cbTRFFaces.FormattingEnabled = true;
            this.cbTRFFaces.Location = new System.Drawing.Point(24, 32);
            this.cbTRFFaces.Name = "cbTRFFaces";
            this.cbTRFFaces.Size = new System.Drawing.Size(287, 24);
            this.cbTRFFaces.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTRFReset);
            this.groupBox1.Controls.Add(this.btnTRFStop);
            this.groupBox1.Controls.Add(this.btnTRFDelete);
            this.groupBox1.Controls.Add(this.btnTRFSave);
            this.groupBox1.Controls.Add(this.btnTRFStart);
            this.groupBox1.Controls.Add(this.cbTRFFaces);
            this.groupBox1.Location = new System.Drawing.Point(12, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 154);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TRAIN FACE";
            // 
            // btnTRFReset
            // 
            this.btnTRFReset.Location = new System.Drawing.Point(24, 99);
            this.btnTRFReset.Name = "btnTRFReset";
            this.btnTRFReset.Size = new System.Drawing.Size(75, 31);
            this.btnTRFReset.TabIndex = 21;
            this.btnTRFReset.Text = "reset";
            this.btnTRFReset.UseVisualStyleBackColor = false;
            this.btnTRFReset.Click += new System.EventHandler(this.btnTRFReset_Click);
            // 
            // btnTRFStop
            // 
            this.btnTRFStop.Location = new System.Drawing.Point(105, 62);
            this.btnTRFStop.Name = "btnTRFStop";
            this.btnTRFStop.Size = new System.Drawing.Size(75, 31);
            this.btnTRFStop.TabIndex = 20;
            this.btnTRFStop.Text = "stop";
            this.btnTRFStop.UseVisualStyleBackColor = false;
            this.btnTRFStop.Click += new System.EventHandler(this.btnTRFStop_Click);
            // 
            // btnTRFDelete
            // 
            this.btnTRFDelete.Location = new System.Drawing.Point(186, 99);
            this.btnTRFDelete.Name = "btnTRFDelete";
            this.btnTRFDelete.Size = new System.Drawing.Size(75, 31);
            this.btnTRFDelete.TabIndex = 18;
            this.btnTRFDelete.Text = "delete";
            this.btnTRFDelete.UseVisualStyleBackColor = false;
            this.btnTRFDelete.Click += new System.EventHandler(this.btnTRFDelete_Click);
            // 
            // btnTRFSave
            // 
            this.btnTRFSave.Location = new System.Drawing.Point(105, 99);
            this.btnTRFSave.Name = "btnTRFSave";
            this.btnTRFSave.Size = new System.Drawing.Size(75, 31);
            this.btnTRFSave.TabIndex = 17;
            this.btnTRFSave.Text = "save";
            this.btnTRFSave.UseVisualStyleBackColor = false;
            this.btnTRFSave.Click += new System.EventHandler(this.btnTRFSave_Click);
            // 
            // btnTRFStart
            // 
            this.btnTRFStart.Location = new System.Drawing.Point(24, 62);
            this.btnTRFStart.Name = "btnTRFStart";
            this.btnTRFStart.Size = new System.Drawing.Size(75, 31);
            this.btnTRFStart.TabIndex = 16;
            this.btnTRFStart.Text = "start";
            this.btnTRFStart.UseVisualStyleBackColor = false;
            this.btnTRFStart.Click += new System.EventHandler(this.btnTRFStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbQA3);
            this.groupBox2.Controls.Add(this.cbQA2);
            this.groupBox2.Controls.Add(this.cbQA1);
            this.groupBox2.Controls.Add(this.btnQSET6);
            this.groupBox2.Controls.Add(this.btnQSET5);
            this.groupBox2.Controls.Add(this.btnQSET4);
            this.groupBox2.Controls.Add(this.btnQSET3);
            this.groupBox2.Controls.Add(this.btnQSET2);
            this.groupBox2.Controls.Add(this.btnQSET1);
            this.groupBox2.Controls.Add(this.btnQBereken1);
            this.groupBox2.Controls.Add(this.textBox13);
            this.groupBox2.Controls.Add(this.tbQGRP6_TOT);
            this.groupBox2.Controls.Add(this.tbQGRP6_T1);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.tbQGRP5_TOT);
            this.groupBox2.Controls.Add(this.tbQGRP5_T1);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.tbQGRP4_TOT);
            this.groupBox2.Controls.Add(this.tbQGRP4_T1);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.tbQGRP3_TOT);
            this.groupBox2.Controls.Add(this.tbQGRP3_T1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.tbQGRP2_TOT);
            this.groupBox2.Controls.Add(this.tbQGRP2_T1);
            this.groupBox2.Controls.Add(this.tbQGrp1);
            this.groupBox2.Controls.Add(this.tbQGRP1_TOT);
            this.groupBox2.Controls.Add(this.tbQGRP1_T1);
            this.groupBox2.Controls.Add(this.cbQGrp);
            this.groupBox2.Controls.Add(this.btnQStop);
            this.groupBox2.Controls.Add(this.btnQStart);
            this.groupBox2.Controls.Add(this.cbQNbr);
            this.groupBox2.Location = new System.Drawing.Point(382, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 460);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QUESTION";
            // 
            // cbQA3
            // 
            this.cbQA3.AutoSize = true;
            this.cbQA3.Location = new System.Drawing.Point(301, 415);
            this.cbQA3.Name = "cbQA3";
            this.cbQA3.Size = new System.Drawing.Size(49, 21);
            this.cbQA3.TabIndex = 50;
            this.cbQA3.Text = "Q3";
            this.cbQA3.UseVisualStyleBackColor = true;
            this.cbQA3.CheckedChanged += new System.EventHandler(this.cbQA3_CheckedChanged);
            // 
            // cbQA2
            // 
            this.cbQA2.AutoSize = true;
            this.cbQA2.Location = new System.Drawing.Point(147, 415);
            this.cbQA2.Name = "cbQA2";
            this.cbQA2.Size = new System.Drawing.Size(49, 21);
            this.cbQA2.TabIndex = 49;
            this.cbQA2.Text = "Q2";
            this.cbQA2.UseVisualStyleBackColor = true;
            this.cbQA2.CheckedChanged += new System.EventHandler(this.cbQA2_CheckedChanged);
            // 
            // cbQA1
            // 
            this.cbQA1.AutoSize = true;
            this.cbQA1.Location = new System.Drawing.Point(24, 415);
            this.cbQA1.Name = "cbQA1";
            this.cbQA1.Size = new System.Drawing.Size(49, 21);
            this.cbQA1.TabIndex = 48;
            this.cbQA1.Text = "Q1";
            this.cbQA1.UseVisualStyleBackColor = true;
            this.cbQA1.CheckedChanged += new System.EventHandler(this.cbQA1_CheckedChanged);
            // 
            // btnQSET6
            // 
            this.btnQSET6.Location = new System.Drawing.Point(324, 308);
            this.btnQSET6.Name = "btnQSET6";
            this.btnQSET6.Size = new System.Drawing.Size(54, 31);
            this.btnQSET6.TabIndex = 47;
            this.btnQSET6.Text = "set";
            this.btnQSET6.UseVisualStyleBackColor = false;
            this.btnQSET6.Click += new System.EventHandler(this.btnQSET6_Click);
            // 
            // btnQSET5
            // 
            this.btnQSET5.Location = new System.Drawing.Point(324, 271);
            this.btnQSET5.Name = "btnQSET5";
            this.btnQSET5.Size = new System.Drawing.Size(54, 31);
            this.btnQSET5.TabIndex = 46;
            this.btnQSET5.Text = "set";
            this.btnQSET5.UseVisualStyleBackColor = false;
            this.btnQSET5.Click += new System.EventHandler(this.btnQSET5_Click);
            // 
            // btnQSET4
            // 
            this.btnQSET4.Location = new System.Drawing.Point(324, 234);
            this.btnQSET4.Name = "btnQSET4";
            this.btnQSET4.Size = new System.Drawing.Size(54, 31);
            this.btnQSET4.TabIndex = 45;
            this.btnQSET4.Text = "set";
            this.btnQSET4.UseVisualStyleBackColor = false;
            this.btnQSET4.Click += new System.EventHandler(this.btnQSET4_Click);
            // 
            // btnQSET3
            // 
            this.btnQSET3.Location = new System.Drawing.Point(324, 200);
            this.btnQSET3.Name = "btnQSET3";
            this.btnQSET3.Size = new System.Drawing.Size(54, 31);
            this.btnQSET3.TabIndex = 44;
            this.btnQSET3.Text = "set";
            this.btnQSET3.UseVisualStyleBackColor = false;
            this.btnQSET3.Click += new System.EventHandler(this.btnQSET3_Click);
            // 
            // btnQSET2
            // 
            this.btnQSET2.Location = new System.Drawing.Point(324, 168);
            this.btnQSET2.Name = "btnQSET2";
            this.btnQSET2.Size = new System.Drawing.Size(54, 31);
            this.btnQSET2.TabIndex = 43;
            this.btnQSET2.Text = "set";
            this.btnQSET2.UseVisualStyleBackColor = false;
            this.btnQSET2.Click += new System.EventHandler(this.btnQSET2_Click);
            // 
            // btnQSET1
            // 
            this.btnQSET1.Location = new System.Drawing.Point(324, 135);
            this.btnQSET1.Name = "btnQSET1";
            this.btnQSET1.Size = new System.Drawing.Size(54, 31);
            this.btnQSET1.TabIndex = 42;
            this.btnQSET1.Text = "set";
            this.btnQSET1.UseVisualStyleBackColor = false;
            this.btnQSET1.Click += new System.EventHandler(this.btnQSET1_Click);
            // 
            // btnQBereken1
            // 
            this.btnQBereken1.Location = new System.Drawing.Point(6, 353);
            this.btnQBereken1.Name = "btnQBereken1";
            this.btnQBereken1.Size = new System.Drawing.Size(372, 41);
            this.btnQBereken1.TabIndex = 41;
            this.btnQBereken1.Text = "BEREKEN STAND";
            this.btnQBereken1.UseVisualStyleBackColor = true;
            this.btnQBereken1.Click += new System.EventHandler(this.btnQBereken1_Click);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(6, 308);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(100, 22);
            this.textBox13.TabIndex = 40;
            this.textBox13.Text = "GRP6";
            // 
            // tbQGRP6_TOT
            // 
            this.tbQGRP6_TOT.Location = new System.Drawing.Point(218, 308);
            this.tbQGRP6_TOT.Name = "tbQGRP6_TOT";
            this.tbQGRP6_TOT.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP6_TOT.TabIndex = 39;
            // 
            // tbQGRP6_T1
            // 
            this.tbQGRP6_T1.Location = new System.Drawing.Point(112, 308);
            this.tbQGRP6_T1.Name = "tbQGRP6_T1";
            this.tbQGRP6_T1.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP6_T1.TabIndex = 38;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(6, 271);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(100, 22);
            this.textBox10.TabIndex = 37;
            this.textBox10.Text = "GRP5";
            // 
            // tbQGRP5_TOT
            // 
            this.tbQGRP5_TOT.Location = new System.Drawing.Point(218, 271);
            this.tbQGRP5_TOT.Name = "tbQGRP5_TOT";
            this.tbQGRP5_TOT.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP5_TOT.TabIndex = 36;
            // 
            // tbQGRP5_T1
            // 
            this.tbQGRP5_T1.Location = new System.Drawing.Point(112, 271);
            this.tbQGRP5_T1.Name = "tbQGRP5_T1";
            this.tbQGRP5_T1.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP5_T1.TabIndex = 35;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(6, 234);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 34;
            this.textBox7.Text = "GRP4";
            // 
            // tbQGRP4_TOT
            // 
            this.tbQGRP4_TOT.Location = new System.Drawing.Point(218, 234);
            this.tbQGRP4_TOT.Name = "tbQGRP4_TOT";
            this.tbQGRP4_TOT.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP4_TOT.TabIndex = 33;
            // 
            // tbQGRP4_T1
            // 
            this.tbQGRP4_T1.Location = new System.Drawing.Point(112, 234);
            this.tbQGRP4_T1.Name = "tbQGRP4_T1";
            this.tbQGRP4_T1.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP4_T1.TabIndex = 32;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 200);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 31;
            this.textBox4.Text = "GRP3";
            // 
            // tbQGRP3_TOT
            // 
            this.tbQGRP3_TOT.Location = new System.Drawing.Point(218, 200);
            this.tbQGRP3_TOT.Name = "tbQGRP3_TOT";
            this.tbQGRP3_TOT.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP3_TOT.TabIndex = 30;
            // 
            // tbQGRP3_T1
            // 
            this.tbQGRP3_T1.Location = new System.Drawing.Point(112, 200);
            this.tbQGRP3_T1.Name = "tbQGRP3_T1";
            this.tbQGRP3_T1.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP3_T1.TabIndex = 29;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 168);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 28;
            this.textBox1.Text = "GRP2";
            // 
            // tbQGRP2_TOT
            // 
            this.tbQGRP2_TOT.Location = new System.Drawing.Point(218, 168);
            this.tbQGRP2_TOT.Name = "tbQGRP2_TOT";
            this.tbQGRP2_TOT.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP2_TOT.TabIndex = 27;
            // 
            // tbQGRP2_T1
            // 
            this.tbQGRP2_T1.Location = new System.Drawing.Point(112, 168);
            this.tbQGRP2_T1.Name = "tbQGRP2_T1";
            this.tbQGRP2_T1.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP2_T1.TabIndex = 26;
            // 
            // tbQGrp1
            // 
            this.tbQGrp1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbQGrp1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbQGrp1.Location = new System.Drawing.Point(6, 135);
            this.tbQGrp1.Name = "tbQGrp1";
            this.tbQGrp1.ReadOnly = true;
            this.tbQGrp1.Size = new System.Drawing.Size(100, 22);
            this.tbQGrp1.TabIndex = 25;
            this.tbQGrp1.Text = "GRP1";
            // 
            // tbQGRP1_TOT
            // 
            this.tbQGRP1_TOT.Location = new System.Drawing.Point(218, 135);
            this.tbQGRP1_TOT.Name = "tbQGRP1_TOT";
            this.tbQGRP1_TOT.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP1_TOT.TabIndex = 24;
            // 
            // tbQGRP1_T1
            // 
            this.tbQGRP1_T1.Location = new System.Drawing.Point(112, 135);
            this.tbQGRP1_T1.Name = "tbQGRP1_T1";
            this.tbQGRP1_T1.Size = new System.Drawing.Size(100, 22);
            this.tbQGRP1_T1.TabIndex = 23;
            // 
            // cbQGrp
            // 
            this.cbQGrp.FormattingEnabled = true;
            this.cbQGrp.Location = new System.Drawing.Point(24, 62);
            this.cbQGrp.Name = "cbQGrp";
            this.cbQGrp.Size = new System.Drawing.Size(287, 24);
            this.cbQGrp.TabIndex = 22;
            // 
            // btnQStop
            // 
            this.btnQStop.Location = new System.Drawing.Point(105, 92);
            this.btnQStop.Name = "btnQStop";
            this.btnQStop.Size = new System.Drawing.Size(75, 31);
            this.btnQStop.TabIndex = 20;
            this.btnQStop.Text = "stop";
            this.btnQStop.UseVisualStyleBackColor = false;
            this.btnQStop.Click += new System.EventHandler(this.btnQStop_Click);
            // 
            // btnQStart
            // 
            this.btnQStart.Location = new System.Drawing.Point(24, 92);
            this.btnQStart.Name = "btnQStart";
            this.btnQStart.Size = new System.Drawing.Size(75, 31);
            this.btnQStart.TabIndex = 16;
            this.btnQStart.Text = "start";
            this.btnQStart.UseVisualStyleBackColor = false;
            this.btnQStart.Click += new System.EventHandler(this.btnQStart_Click);
            // 
            // cbQNbr
            // 
            this.cbQNbr.FormattingEnabled = true;
            this.cbQNbr.Location = new System.Drawing.Point(24, 32);
            this.cbQNbr.Name = "cbQNbr";
            this.cbQNbr.Size = new System.Drawing.Size(287, 24);
            this.cbQNbr.TabIndex = 14;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTFStop);
            this.groupBox4.Controls.Add(this.btnTFStart);
            this.groupBox4.Controls.Add(this.cbTFFaces);
            this.groupBox4.Location = new System.Drawing.Point(12, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(344, 154);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TEST FACE";
            // 
            // btnTFStop
            // 
            this.btnTFStop.Location = new System.Drawing.Point(105, 62);
            this.btnTFStop.Name = "btnTFStop";
            this.btnTFStop.Size = new System.Drawing.Size(75, 31);
            this.btnTFStop.TabIndex = 20;
            this.btnTFStop.Text = "stop";
            this.btnTFStop.UseVisualStyleBackColor = false;
            this.btnTFStop.Click += new System.EventHandler(this.btnTFStop_Click);
            // 
            // btnTFStart
            // 
            this.btnTFStart.Location = new System.Drawing.Point(24, 62);
            this.btnTFStart.Name = "btnTFStart";
            this.btnTFStart.Size = new System.Drawing.Size(75, 31);
            this.btnTFStart.TabIndex = 16;
            this.btnTFStart.Text = "start";
            this.btnTFStart.UseVisualStyleBackColor = false;
            this.btnTFStart.Click += new System.EventHandler(this.btnTFStart_Click);
            // 
            // cbTFFaces
            // 
            this.cbTFFaces.FormattingEnabled = true;
            this.cbTFFaces.Location = new System.Drawing.Point(24, 32);
            this.cbTFFaces.Name = "cbTFFaces";
            this.cbTFFaces.Size = new System.Drawing.Size(287, 24);
            this.cbTFFaces.TabIndex = 14;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnTGStop);
            this.groupBox5.Controls.Add(this.btnTGStart);
            this.groupBox5.Controls.Add(this.cbTGGroups);
            this.groupBox5.Location = new System.Drawing.Point(12, 451);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(344, 154);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TEST GROUP";
            // 
            // btnTGStop
            // 
            this.btnTGStop.Location = new System.Drawing.Point(105, 62);
            this.btnTGStop.Name = "btnTGStop";
            this.btnTGStop.Size = new System.Drawing.Size(75, 31);
            this.btnTGStop.TabIndex = 20;
            this.btnTGStop.Text = "stop";
            this.btnTGStop.UseVisualStyleBackColor = false;
            this.btnTGStop.Click += new System.EventHandler(this.btnTGStop_Click);
            // 
            // btnTGStart
            // 
            this.btnTGStart.Location = new System.Drawing.Point(24, 62);
            this.btnTGStart.Name = "btnTGStart";
            this.btnTGStart.Size = new System.Drawing.Size(75, 31);
            this.btnTGStart.TabIndex = 16;
            this.btnTGStart.Text = "start";
            this.btnTGStart.UseVisualStyleBackColor = false;
            this.btnTGStart.Click += new System.EventHandler(this.btnTGStart_Click);
            // 
            // cbTGGroups
            // 
            this.cbTGGroups.FormattingEnabled = true;
            this.cbTGGroups.Location = new System.Drawing.Point(24, 32);
            this.cbTGGroups.Name = "cbTGGroups";
            this.cbTGGroups.Size = new System.Drawing.Size(287, 24);
            this.cbTGGroups.TabIndex = 14;
            // 
            // btnFormTrainFaceOpen
            // 
            this.btnFormTrainFaceOpen.Location = new System.Drawing.Point(12, 675);
            this.btnFormTrainFaceOpen.Name = "btnFormTrainFaceOpen";
            this.btnFormTrainFaceOpen.Size = new System.Drawing.Size(137, 41);
            this.btnFormTrainFaceOpen.TabIndex = 24;
            this.btnFormTrainFaceOpen.Text = "TRAIN FACEs";
            this.btnFormTrainFaceOpen.UseVisualStyleBackColor = true;
            this.btnFormTrainFaceOpen.Click += new System.EventHandler(this.btnFormTrainFaceOpen_Click);
            // 
            // btnTrain1
            // 
            this.btnTrain1.Location = new System.Drawing.Point(155, 675);
            this.btnTrain1.Name = "btnTrain1";
            this.btnTrain1.Size = new System.Drawing.Size(137, 41);
            this.btnTrain1.TabIndex = 25;
            this.btnTrain1.Text = "TRAIN OBJECT\'s";
            this.btnTrain1.UseVisualStyleBackColor = true;
            this.btnTrain1.Click += new System.EventHandler(this.btnTrain1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 731);
            this.Controls.Add(this.btnTrain1);
            this.Controls.Add(this.btnFormTrainFaceOpen);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFormWebCam);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFormWebCam;
        private System.Windows.Forms.ComboBox cbTRFFaces;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTRFSave;
        private System.Windows.Forms.Button btnTRFStart;
        private System.Windows.Forms.Button btnTRFDelete;
        private System.Windows.Forms.Button btnTRFStop;
        private System.Windows.Forms.Button btnTRFReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbQGrp;
        private System.Windows.Forms.Button btnQStop;
        private System.Windows.Forms.Button btnQStart;
        private System.Windows.Forms.ComboBox cbQNbr;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTFStop;
        private System.Windows.Forms.Button btnTFStart;
        private System.Windows.Forms.ComboBox cbTFFaces;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnTGStop;
        private System.Windows.Forms.Button btnTGStart;
        private System.Windows.Forms.ComboBox cbTGGroups;
        private System.Windows.Forms.Button btnFormTrainFaceOpen;
        private System.Windows.Forms.TextBox tbQGrp1;
        private System.Windows.Forms.TextBox tbQGRP1_TOT;
        private System.Windows.Forms.TextBox tbQGRP1_T1;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox tbQGRP6_TOT;
        private System.Windows.Forms.TextBox tbQGRP6_T1;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox tbQGRP5_TOT;
        private System.Windows.Forms.TextBox tbQGRP5_T1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox tbQGRP4_TOT;
        private System.Windows.Forms.TextBox tbQGRP4_T1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox tbQGRP3_TOT;
        private System.Windows.Forms.TextBox tbQGRP3_T1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbQGRP2_TOT;
        private System.Windows.Forms.TextBox tbQGRP2_T1;
        private System.Windows.Forms.Button btnQBereken1;
        private System.Windows.Forms.Button btnQSET1;
        private System.Windows.Forms.Button btnQSET6;
        private System.Windows.Forms.Button btnQSET5;
        private System.Windows.Forms.Button btnQSET4;
        private System.Windows.Forms.Button btnQSET3;
        private System.Windows.Forms.Button btnQSET2;
        private System.Windows.Forms.CheckBox cbQA1;
        private System.Windows.Forms.CheckBox cbQA3;
        private System.Windows.Forms.CheckBox cbQA2;
        private System.Windows.Forms.Button btnTrain1;
    }
}

