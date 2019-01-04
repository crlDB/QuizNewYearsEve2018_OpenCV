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

    public class TrainFaces
    {

        public String FaceName { get; set; }
        public int FaceId { get; set; }
        public int TrainNbr { get; set; }
        public List<Image<Gray, byte>> TrainFace { get; set; }

        public int WaitCycle { get; set; }
    }

    public partial class Quiz2018
    {
        public int TRF_IMAGE_WIDTH { get; set; } = 80; //128;
        public int TRF_IMAGE_HEIGHT { get; set; } = 100;

        public TrainFaces TRFaces { get; set; }
        public FormTraining FrmTrain { get; set; }

        public void TrainFaceStart(string selectedFaceStr)
        {
            int selectedFace = -1;
            // get index
            try
            {
                selectedFace = int.Parse(selectedFaceStr.Split('_').Last());
            }
            catch (Exception)
            {
                return;
            }

            // mode train - start
            Mode = EnMode.TRFStart;
            FrmMain.ButtonBackColor();

            // get info
            TRFaces.FaceId = QZFaceArr[selectedFace].Id;
            TRFaces.FaceName = QZFaceArr[selectedFace].Name;
            TRFaces.TrainNbr = 0;
            TRFaces.TrainFace = new List<Image<Gray, byte>>();

            // open formwebcam
            FormWebCamOpen();
            // open form training 
            //FormTrainOpen();

        }

        public int TrainFaceSave()
        {
            // mode none
            Mode = EnMode.None;
            FrmMain.ButtonBackColor();

            DateTime now = DateTime.Now;

            int nbr = 0;
            foreach (var trFace in TRFaces.TrainFace)
            {
                try
                {
                    // save
                    trFace.Save(System.IO.Path.GetFullPath($@"../../Faces/{TRFaces.FaceName}_{TRFaces.FaceId}_{now.Hour}_{now.Minute}_{now.Second}_{++nbr}.bmp"));
                }
                catch (Exception)
                {
                }
            }

            return nbr;
        }


        public void FormTrainOpen()
        {
            if (FrmTrain == null)
            {
                FrmTrain = new FormTraining();
                FrmTrain.FormClosing += FrmTrainClose;
            }

            FrmTrain.Show();
            FrmTrain.BringToFront();
            //_frmTrain.WindowState = FormWindowState.Maximized;
        }

        private void FrmTrainClose(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            FrmTrain = null;
        }

        public void FormTrainShowTraining()
        {
            int index = 1;
            foreach (var face in TRFaces.TrainFace)
            {
                FrmTrain.SetPicture(index++, face);
            }
        }
        public void FormTrainShowTraining(int index, Image<Gray, byte> img)
        {
            FrmTrain.SetPicture(index, img);
        }

    }
}
