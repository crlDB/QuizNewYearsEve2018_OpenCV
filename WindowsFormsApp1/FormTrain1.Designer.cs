namespace WindowsFormsApp1
{
    partial class FormTrain1
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
            this.trackBarHmin = new System.Windows.Forms.TrackBar();
            this.tbHmin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHmax = new System.Windows.Forms.TextBox();
            this.trackBarHmax = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSmax = new System.Windows.Forms.TextBox();
            this.trackBarSmax = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSmin = new System.Windows.Forms.TextBox();
            this.trackBarSmin = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.tbVmax = new System.Windows.Forms.TextBox();
            this.trackBarVmax = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbVmin = new System.Windows.Forms.TextBox();
            this.trackBarVmin = new System.Windows.Forms.TrackBar();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.imageBox5 = new Emgu.CV.UI.ImageBox();
            this.imageBox6 = new Emgu.CV.UI.ImageBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGcTh1 = new System.Windows.Forms.TextBox();
            this.trackBarGCTH1 = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.tbGcTh2 = new System.Windows.Forms.TextBox();
            this.trackBarGCTH2 = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSmooth = new System.Windows.Forms.TextBox();
            this.trackBarSmooth = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCannyThreshold1 = new System.Windows.Forms.TextBox();
            this.trackBarCannyThreshold1 = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCannyThreshold2 = new System.Windows.Forms.TextBox();
            this.trackBarCannyThreshold2 = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCannyApertureSize = new System.Windows.Forms.TextBox();
            this.trackBarCannyApertureSize = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGCTH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGCTH2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCannyThreshold1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCannyThreshold2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCannyApertureSize)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarHmin
            // 
            this.trackBarHmin.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarHmin.Location = new System.Drawing.Point(114, 12);
            this.trackBarHmin.Maximum = 255;
            this.trackBarHmin.Name = "trackBarHmin";
            this.trackBarHmin.Size = new System.Drawing.Size(271, 56);
            this.trackBarHmin.TabIndex = 0;
            this.trackBarHmin.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // tbHmin
            // 
            this.tbHmin.Location = new System.Drawing.Point(8, 44);
            this.tbHmin.Name = "tbHmin";
            this.tbHmin.ReadOnly = true;
            this.tbHmin.Size = new System.Drawing.Size(100, 22);
            this.tbHmin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "B_Min";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "B_Max";
            // 
            // tbHmax
            // 
            this.tbHmax.Location = new System.Drawing.Point(8, 106);
            this.tbHmax.Name = "tbHmax";
            this.tbHmax.ReadOnly = true;
            this.tbHmax.Size = new System.Drawing.Size(100, 22);
            this.tbHmax.TabIndex = 5;
            // 
            // trackBarHmax
            // 
            this.trackBarHmax.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarHmax.Location = new System.Drawing.Point(114, 74);
            this.trackBarHmax.Maximum = 256;
            this.trackBarHmax.Minimum = 1;
            this.trackBarHmax.Name = "trackBarHmax";
            this.trackBarHmax.Size = new System.Drawing.Size(271, 56);
            this.trackBarHmax.TabIndex = 4;
            this.trackBarHmax.Value = 1;
            this.trackBarHmax.ValueChanged += new System.EventHandler(this.trackBarHmax_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "G_Max";
            // 
            // tbSmax
            // 
            this.tbSmax.Location = new System.Drawing.Point(8, 249);
            this.tbSmax.Name = "tbSmax";
            this.tbSmax.ReadOnly = true;
            this.tbSmax.Size = new System.Drawing.Size(100, 22);
            this.tbSmax.TabIndex = 11;
            // 
            // trackBarSmax
            // 
            this.trackBarSmax.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarSmax.Location = new System.Drawing.Point(114, 217);
            this.trackBarSmax.Maximum = 256;
            this.trackBarSmax.Minimum = 1;
            this.trackBarSmax.Name = "trackBarSmax";
            this.trackBarSmax.Size = new System.Drawing.Size(271, 56);
            this.trackBarSmax.TabIndex = 10;
            this.trackBarSmax.Value = 1;
            this.trackBarSmax.ValueChanged += new System.EventHandler(this.trackBarSmax_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "G_Min";
            // 
            // tbSmin
            // 
            this.tbSmin.Location = new System.Drawing.Point(8, 187);
            this.tbSmin.Name = "tbSmin";
            this.tbSmin.ReadOnly = true;
            this.tbSmin.Size = new System.Drawing.Size(100, 22);
            this.tbSmin.TabIndex = 8;
            // 
            // trackBarSmin
            // 
            this.trackBarSmin.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarSmin.Location = new System.Drawing.Point(114, 155);
            this.trackBarSmin.Maximum = 255;
            this.trackBarSmin.Name = "trackBarSmin";
            this.trackBarSmin.Size = new System.Drawing.Size(271, 56);
            this.trackBarSmin.TabIndex = 7;
            this.trackBarSmin.ValueChanged += new System.EventHandler(this.trackBarSmin_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 32);
            this.label5.TabIndex = 18;
            this.label5.Text = "R_Max";
            // 
            // tbVmax
            // 
            this.tbVmax.Location = new System.Drawing.Point(8, 390);
            this.tbVmax.Name = "tbVmax";
            this.tbVmax.ReadOnly = true;
            this.tbVmax.Size = new System.Drawing.Size(100, 22);
            this.tbVmax.TabIndex = 17;
            // 
            // trackBarVmax
            // 
            this.trackBarVmax.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarVmax.Location = new System.Drawing.Point(114, 358);
            this.trackBarVmax.Maximum = 256;
            this.trackBarVmax.Minimum = 1;
            this.trackBarVmax.Name = "trackBarVmax";
            this.trackBarVmax.Size = new System.Drawing.Size(271, 56);
            this.trackBarVmax.TabIndex = 16;
            this.trackBarVmax.Value = 1;
            this.trackBarVmax.ValueChanged += new System.EventHandler(this.trackBarVmax_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "R_Min";
            // 
            // tbVmin
            // 
            this.tbVmin.Location = new System.Drawing.Point(8, 328);
            this.tbVmin.Name = "tbVmin";
            this.tbVmin.ReadOnly = true;
            this.tbVmin.Size = new System.Drawing.Size(100, 22);
            this.tbVmin.TabIndex = 14;
            // 
            // trackBarVmin
            // 
            this.trackBarVmin.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarVmin.Location = new System.Drawing.Point(114, 296);
            this.trackBarVmin.Maximum = 255;
            this.trackBarVmin.Name = "trackBarVmin";
            this.trackBarVmin.Size = new System.Drawing.Size(271, 56);
            this.trackBarVmin.TabIndex = 13;
            this.trackBarVmin.ValueChanged += new System.EventHandler(this.trackBarVmin_ValueChanged);
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(391, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(450, 300);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(847, 12);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(450, 300);
            this.imageBox2.TabIndex = 19;
            this.imageBox2.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.Location = new System.Drawing.Point(1303, 12);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(450, 300);
            this.imageBox3.TabIndex = 20;
            this.imageBox3.TabStop = false;
            // 
            // imageBox4
            // 
            this.imageBox4.Location = new System.Drawing.Point(391, 318);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(450, 300);
            this.imageBox4.TabIndex = 21;
            this.imageBox4.TabStop = false;
            // 
            // imageBox5
            // 
            this.imageBox5.Location = new System.Drawing.Point(847, 318);
            this.imageBox5.Name = "imageBox5";
            this.imageBox5.Size = new System.Drawing.Size(450, 300);
            this.imageBox5.TabIndex = 22;
            this.imageBox5.TabStop = false;
            // 
            // imageBox6
            // 
            this.imageBox6.Location = new System.Drawing.Point(1303, 318);
            this.imageBox6.Name = "imageBox6";
            this.imageBox6.Size = new System.Drawing.Size(450, 300);
            this.imageBox6.TabIndex = 23;
            this.imageBox6.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 417);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 32);
            this.label7.TabIndex = 26;
            this.label7.Text = "GCTH";
            // 
            // tbGcTh1
            // 
            this.tbGcTh1.Location = new System.Drawing.Point(8, 452);
            this.tbGcTh1.Name = "tbGcTh1";
            this.tbGcTh1.ReadOnly = true;
            this.tbGcTh1.Size = new System.Drawing.Size(100, 22);
            this.tbGcTh1.TabIndex = 25;
            // 
            // trackBarGCTH1
            // 
            this.trackBarGCTH1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarGCTH1.Location = new System.Drawing.Point(114, 420);
            this.trackBarGCTH1.Maximum = 255;
            this.trackBarGCTH1.Name = "trackBarGCTH1";
            this.trackBarGCTH1.Size = new System.Drawing.Size(271, 56);
            this.trackBarGCTH1.TabIndex = 24;
            this.trackBarGCTH1.Value = 1;
            this.trackBarGCTH1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 479);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 32);
            this.label8.TabIndex = 29;
            this.label8.Text = "GCTH";
            // 
            // tbGcTh2
            // 
            this.tbGcTh2.Location = new System.Drawing.Point(8, 514);
            this.tbGcTh2.Name = "tbGcTh2";
            this.tbGcTh2.ReadOnly = true;
            this.tbGcTh2.Size = new System.Drawing.Size(100, 22);
            this.tbGcTh2.TabIndex = 28;
            // 
            // trackBarGCTH2
            // 
            this.trackBarGCTH2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarGCTH2.Location = new System.Drawing.Point(114, 482);
            this.trackBarGCTH2.Maximum = 255;
            this.trackBarGCTH2.Name = "trackBarGCTH2";
            this.trackBarGCTH2.Size = new System.Drawing.Size(271, 56);
            this.trackBarGCTH2.TabIndex = 27;
            this.trackBarGCTH2.Value = 1;
            this.trackBarGCTH2.ValueChanged += new System.EventHandler(this.trackBar20_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.DarkGray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 592);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 25);
            this.label9.TabIndex = 32;
            this.label9.Text = "smoothing";
            // 
            // tbSmooth
            // 
            this.tbSmooth.Location = new System.Drawing.Point(140, 594);
            this.tbSmooth.Name = "tbSmooth";
            this.tbSmooth.ReadOnly = true;
            this.tbSmooth.Size = new System.Drawing.Size(100, 22);
            this.tbSmooth.TabIndex = 31;
            // 
            // trackBarSmooth
            // 
            this.trackBarSmooth.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarSmooth.Location = new System.Drawing.Point(9, 562);
            this.trackBarSmooth.Minimum = 1;
            this.trackBarSmooth.Name = "trackBarSmooth";
            this.trackBarSmooth.Size = new System.Drawing.Size(271, 56);
            this.trackBarSmooth.TabIndex = 30;
            this.trackBarSmooth.Value = 1;
            this.trackBarSmooth.ValueChanged += new System.EventHandler(this.trackBarSmooth_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkGray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 654);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 25);
            this.label10.TabIndex = 35;
            this.label10.Text = "threshold1";
            // 
            // tbCannyThreshold1
            // 
            this.tbCannyThreshold1.Location = new System.Drawing.Point(139, 656);
            this.tbCannyThreshold1.Name = "tbCannyThreshold1";
            this.tbCannyThreshold1.ReadOnly = true;
            this.tbCannyThreshold1.Size = new System.Drawing.Size(100, 22);
            this.tbCannyThreshold1.TabIndex = 34;
            // 
            // trackBarCannyThreshold1
            // 
            this.trackBarCannyThreshold1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarCannyThreshold1.Location = new System.Drawing.Point(8, 624);
            this.trackBarCannyThreshold1.Maximum = 255;
            this.trackBarCannyThreshold1.Minimum = 1;
            this.trackBarCannyThreshold1.Name = "trackBarCannyThreshold1";
            this.trackBarCannyThreshold1.Size = new System.Drawing.Size(271, 56);
            this.trackBarCannyThreshold1.TabIndex = 33;
            this.trackBarCannyThreshold1.Value = 1;
            this.trackBarCannyThreshold1.ValueChanged += new System.EventHandler(this.trackBarCannyThreshold1_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkGray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 716);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 25);
            this.label11.TabIndex = 38;
            this.label11.Text = "threshold2";
            // 
            // tbCannyThreshold2
            // 
            this.tbCannyThreshold2.Location = new System.Drawing.Point(139, 718);
            this.tbCannyThreshold2.Name = "tbCannyThreshold2";
            this.tbCannyThreshold2.ReadOnly = true;
            this.tbCannyThreshold2.Size = new System.Drawing.Size(100, 22);
            this.tbCannyThreshold2.TabIndex = 37;
            // 
            // trackBarCannyThreshold2
            // 
            this.trackBarCannyThreshold2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarCannyThreshold2.Location = new System.Drawing.Point(8, 686);
            this.trackBarCannyThreshold2.Maximum = 255;
            this.trackBarCannyThreshold2.Minimum = 1;
            this.trackBarCannyThreshold2.Name = "trackBarCannyThreshold2";
            this.trackBarCannyThreshold2.Size = new System.Drawing.Size(271, 56);
            this.trackBarCannyThreshold2.TabIndex = 36;
            this.trackBarCannyThreshold2.Value = 1;
            this.trackBarCannyThreshold2.ValueChanged += new System.EventHandler(this.trackBarCannyThreshold2_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.DarkGray;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(26, 776);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 25);
            this.label12.TabIndex = 41;
            this.label12.Text = "Aperture";
            // 
            // tbCannyApertureSize
            // 
            this.tbCannyApertureSize.Location = new System.Drawing.Point(140, 778);
            this.tbCannyApertureSize.Name = "tbCannyApertureSize";
            this.tbCannyApertureSize.ReadOnly = true;
            this.tbCannyApertureSize.Size = new System.Drawing.Size(100, 22);
            this.tbCannyApertureSize.TabIndex = 40;
            // 
            // trackBarCannyApertureSize
            // 
            this.trackBarCannyApertureSize.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.trackBarCannyApertureSize.Location = new System.Drawing.Point(9, 746);
            this.trackBarCannyApertureSize.Maximum = 20;
            this.trackBarCannyApertureSize.Minimum = 1;
            this.trackBarCannyApertureSize.Name = "trackBarCannyApertureSize";
            this.trackBarCannyApertureSize.Size = new System.Drawing.Size(271, 56);
            this.trackBarCannyApertureSize.TabIndex = 39;
            this.trackBarCannyApertureSize.Value = 1;
            this.trackBarCannyApertureSize.ValueChanged += new System.EventHandler(this.trackBarCannyApertureSize_ValueChanged);
            // 
            // FormTrain1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1796, 854);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbCannyApertureSize);
            this.Controls.Add(this.trackBarCannyApertureSize);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbCannyThreshold2);
            this.Controls.Add(this.trackBarCannyThreshold2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbCannyThreshold1);
            this.Controls.Add(this.trackBarCannyThreshold1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbSmooth);
            this.Controls.Add(this.trackBarSmooth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbGcTh2);
            this.Controls.Add(this.trackBarGCTH2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbGcTh1);
            this.Controls.Add(this.trackBarGCTH1);
            this.Controls.Add(this.imageBox6);
            this.Controls.Add(this.imageBox5);
            this.Controls.Add(this.imageBox4);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbVmax);
            this.Controls.Add(this.trackBarVmax);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbVmin);
            this.Controls.Add(this.trackBarVmin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSmax);
            this.Controls.Add(this.trackBarSmax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSmin);
            this.Controls.Add(this.trackBarSmin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbHmax);
            this.Controls.Add(this.trackBarHmax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbHmin);
            this.Controls.Add(this.trackBarHmin);
            this.Name = "FormTrain1";
            this.Text = "FormTrain1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTrain1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGCTH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGCTH2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCannyThreshold1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCannyThreshold2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCannyApertureSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarHmin;
        private System.Windows.Forms.TextBox tbHmin;
        private System.Windows.Forms.Label Hmins;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHmax;
        private System.Windows.Forms.TrackBar trackBarHmax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSmax;
        private System.Windows.Forms.TrackBar trackBarSmax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSmin;
        private System.Windows.Forms.TrackBar trackBarSmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbVmax;
        private System.Windows.Forms.TrackBar trackBarVmax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbVmin;
        private System.Windows.Forms.TrackBar trackBarVmin;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private Emgu.CV.UI.ImageBox imageBox4;
        private Emgu.CV.UI.ImageBox imageBox5;
        private Emgu.CV.UI.ImageBox imageBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbGcTh1;
        private System.Windows.Forms.TrackBar trackBarGCTH1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbGcTh2;
        private System.Windows.Forms.TrackBar trackBarGCTH2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSmooth;
        private System.Windows.Forms.TrackBar trackBarSmooth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbCannyThreshold1;
        private System.Windows.Forms.TrackBar trackBarCannyThreshold1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbCannyThreshold2;
        private System.Windows.Forms.TrackBar trackBarCannyThreshold2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbCannyApertureSize;
        private System.Windows.Forms.TrackBar trackBarCannyApertureSize;
    }
}