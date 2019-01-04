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
    public class QZFace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Group { get; set; }
        public int Answer { get; set; }     // assign randomly
    }

    public class QZTestFaces
    {

        public string FaceName { get; set; }
        public int FaceId { get; set; }

        public List<Image<Gray, byte>> Faces { get; set; }
        public List<int> FaceIds { get; set; }
        public LBPHFaceRecognizer FaceRecognition { get; set; }
    }



    public partial class Quiz2018
    {
        public QZFace[] QZFaceArr { get; set; }

        public QZTestFaces TFaces { get; set; }

        public void TestFaceStart(string selectedFaceStr)
        {
            int selectedFace = -1;
            // get index
            try
            {
                selectedFace = int.Parse(selectedFaceStr.Split('_').Last());
            }
            catch (Exception)
            {
            }


            // get info
            TFaces = new QZTestFaces();
            try
            {
                TFaces.FaceId = QZFaceArr[selectedFace].Id;
                TFaces.FaceName = QZFaceArr[selectedFace].Name;
            }
            catch (Exception)
            {
                TFaces.FaceId = -1;
                TFaces.FaceName = "";
            }

            TFaces.Faces = new List<Image<Gray, byte>>();
            TFaces.FaceIds = new List<int>();

            // load images
            string dir = System.IO.Path.GetFullPath($@"../../Faces/");
            string[] fileEntries = Directory.GetFiles(dir);
            foreach (string fileName in fileEntries)
            {
                string file = Path.GetFileNameWithoutExtension(fileName);

                if (((TFaces.FaceId >= 0) && file.StartsWith(TFaces.FaceName)) || (TFaces.FaceId < 0))
                {
                    string[] faceParts = file.Split('_');
                    string faceName = faceParts[0];
                    int faceId = Convert.ToInt32(faceParts[1]);

                    TFaces.Faces.Add(new Image<Gray, byte>(fileName));
                    TFaces.FaceIds.Add(faceId);
                }
            }


            // train faces
            //TFaces.FaceRecognition = new EigenFaceRecognizer(80, double.PositiveInfinity);
            //TFaces.FaceRecognition = new EigenFaceRecognizer(0, 1.0);

            TFaces.FaceRecognition = new LBPHFaceRecognizer();
            //TFaces.FaceRecognition = new FisherFaceRecognizer();

            TFaces.FaceRecognition.Train(TFaces.Faces.ToArray(), TFaces.FaceIds.ToArray());

            // open formwebcam
            FormWebCamOpen();

            // test faces
            Mode = EnMode.TFStart;
            FrmMain.ButtonBackColor();

        }

        public void CreateFacesArr()
        {
            // create faces
            int maxId = QSet.Faces.Max(x => x.Id);
            QZFaceArr = new QZFace[maxId + 1];
            foreach (var face in QSet.Faces)
            {
                if (face == null)
                    continue;
                if (face.Id <= 0)
                    continue;

                QZFaceArr[face.Id] = new QZFace();
                QZFaceArr[face.Id].Id = face.Id;
                QZFaceArr[face.Id].Name = face.Name;
                QZFaceArr[face.Id].Answer = 0;          // wil generate randomly
                QZFaceArr[face.Id].Group = face.Group;
            }
        }

    }
}
