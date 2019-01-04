using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   


    public partial class Quiz2018
    {
        public FormWebCamm FrmWebCam { get; set; }

        public void FormWebCamOpen()
        {
            if (FrmWebCam == null)
            {
                FrmWebCam = new FormWebCamm();
                FrmWebCam.Init(this);
                FrmWebCam.FormClosing += FrmWebCamClose;
            }

            FrmWebCam.Show();
            FrmWebCam.BringToFront();
        }

        private void FrmWebCamClose(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //FrmWebCam.WebcamStop();
            FrmWebCam = null;
        }







    }
}
