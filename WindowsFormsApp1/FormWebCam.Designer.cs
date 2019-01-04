namespace WindowsFormsApp1
{
    partial class FormWebCamm
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
            this.ibWebCam = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibWebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // ibWebCam
            // 
            this.ibWebCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ibWebCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ibWebCam.Location = new System.Drawing.Point(0, 0);
            this.ibWebCam.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.ibWebCam.Name = "ibWebCam";
            this.ibWebCam.Size = new System.Drawing.Size(1902, 1033);
            this.ibWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ibWebCam.TabIndex = 2;
            this.ibWebCam.TabStop = false;
            // 
            // FormWebCamm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.ibWebCam);
            this.Name = "FormWebCamm";
            this.Text = "WebCamForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWebCamm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ibWebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibWebCam;
    }
}