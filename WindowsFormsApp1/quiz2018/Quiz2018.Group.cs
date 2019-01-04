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
  
    public class TGroup
    {
        public int TGroupNbr { get; set; }
    }


    public class QZGroup
    {
        public int GNbr { get; set; }
        public string GSymbol { get; set; }
        public int[] GFaceIds { get; set; }

        public int GTime { get; set; }
        public int GTotalTime { get; set; }

        public int QNbr { get; set; }

        public EigenFaceRecognizer FaceRecoEigen { get; set; }
        public FisherFaceRecognizer FaceRecoFisher { get; set; }
        public LBPHFaceRecognizer FaceRecoLBPHF { get; set; }


        public List<Image<Gray, byte>> TrainFace { get; set; }
        public List<int> TrainFaceId { get; set; }

        public int TmpFaceIndex { get; set; }
    }


    public partial class Quiz2018
    {
        public TGroup QZTGroup { get; set; }
        public QZGroup[] QZGroupArr { get; set; }


        public void CreateGroupsArr()
        {
            // create groups
            int maxId = QSet.Faces.Max(x => x.Group);
            QZGroupArr = new QZGroup[maxId + 1];

            int grpNbr = 0;
            int faceIndex = 0;
            foreach (var face in QSet.Faces)
            {
                grpNbr = face.Group;
                if (grpNbr > 0)
                {
                    // create group
                    if (QZGroupArr[grpNbr] == null)
                    {
                        QZGroupArr[grpNbr] = new QZGroup();
                        QZGroupArr[grpNbr].GNbr = grpNbr;
                        QZGroupArr[grpNbr].GSymbol = "";
                        QZGroupArr[grpNbr].TrainFace = new List<Image<Gray, byte>>();
                        QZGroupArr[grpNbr].TrainFaceId = new List<int>();
                        QZGroupArr[grpNbr].GFaceIds = new int[5];
                        QZGroupArr[grpNbr].TmpFaceIndex = 1;
                    }

                    // assign face
                    faceIndex = QZGroupArr[grpNbr].TmpFaceIndex;
                    QZGroupArr[grpNbr].GFaceIds[faceIndex] = face.Id;
                    QZGroupArr[grpNbr].GSymbol += face.Name.Substring(0, 2);
                    QZGroupArr[grpNbr].GSymbol += "_";

                    // next face in group
                    QZGroupArr[grpNbr].TmpFaceIndex++;
                }
            }
        }
        public void LoadTrainFacesGroups()
        {
            // reset groups
            foreach (var grp in QZGroupArr)
            {
                // check 
                if (grp == null)
                    continue;

                grp.TrainFace = new List<Image<Gray, byte>>();
                grp.TrainFaceId = new List<int>();
                grp.FaceRecoEigen = null;
                grp.FaceRecoFisher = null;
                grp.FaceRecoLBPHF = null;

            }


            // load images
            string dir = System.IO.Path.GetFullPath($@"../../Faces/");
            string[] fileEntries = Directory.GetFiles(dir);

            foreach (string fileName in fileEntries)
            {
                string file = Path.GetFileNameWithoutExtension(fileName);

                string[] faceParts = file.Split('_');
                string faceName = faceParts[0];
                int faceId = 0;
                try
                {
                    faceId = Convert.ToInt32(faceParts[1]);
                }
                catch (Exception)
                {
                    continue;
                }

                // search in groups
                foreach (var grp in QZGroupArr)
                {
                    // check 
                    if (grp == null)
                        continue;
                    if (grp.GFaceIds.Count() == 0)
                        continue;

                    foreach (var face in grp.GFaceIds)
                    {
                        if (face == 0)
                            continue;

                        if (faceName == QZFaceArr[face].Name)
                        {
                            grp.TrainFace.Add(new Image<Gray, byte>(fileName));
                            grp.TrainFaceId.Add(QZFaceArr[face].Id);
                        }
                    }
                }
            }


            // train groups
            foreach (var grp in QZGroupArr)
            {
                // check 
                if (grp == null)
                    continue;

                grp.FaceRecoEigen = new EigenFaceRecognizer(80, double.PositiveInfinity);
                if (grp.TrainFace.Count > 0)
                    grp.FaceRecoEigen.Train(grp.TrainFace.ToArray(), grp.TrainFaceId.ToArray());
            }
        }

        public void TestGroupStart(string selectedGroupStr)
        {
            int selectedGroup = -1;
            // get index
            try
            {
                selectedGroup = int.Parse(selectedGroupStr.Split('_').Last());
            }
            catch (Exception)
            {
                return;
            }

            // test group
            QZTGroup = new TGroup();
            QZTGroup.TGroupNbr = selectedGroup;

            // open formwebcam
            FormWebCamOpen();

            // test faces
            Mode = EnMode.TGStart;
            FrmMain.ButtonBackColor();
        }

        public void BerekenStand()
        {
            try
            {
                foreach (var grp in QZGroupArr)
                {
                    if (grp == null)
                        continue;

                    grp.GTotalTime += grp.GTime;
                    grp.GTime = 0;
                    FrmMain.UpdateScore(grp.GNbr, grp.GTime, grp.GTotalTime);
                }

            }
            catch (Exception)
            {
            }
        }
    }
}
