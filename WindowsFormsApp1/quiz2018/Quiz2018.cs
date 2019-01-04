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
    public enum EnMode
    {
        None,               // no mode

        TRFStart,           // train face
        TFStart,            // test face
        TGStart,            // test group
        QStart,             // question 
    }


    public partial class Quiz2018
    {
        private const string FILE_SETTINGS = "FaceRego.json";
        public QuizSet QSet { get; set; }

      






        public EnMode Mode { get; set; }



        public Quiz2018()
        {
            // read setting
            ReadSetting();
            // faces - create array
            CreateFacesArr();
            // groups - create array
            CreateGroupsArr();
            // questions - create array
            CreateQuestionsArr();

            // groups - load trained faces
            LoadTrainFacesGroups();

            // training faces 
            TRFaces = new TrainFaces();
            TRFaces.TrainFace = new List<Image<Gray, byte>>();
           

        }

        public void Init(FormMain frmMain)
        {
            FrmMain = frmMain;
        }

        public void ReadSetting()
        {
            try
            {
                using (StreamReader r = new StreamReader(System.IO.Path.GetFullPath($@"../../{FILE_SETTINGS}")))
                {
                    string json = r.ReadToEnd();
                    QSet = JsonConvert.DeserializeObject<QuizSet>(json);
                }
            }
            catch (Exception)
            {
            }
        }

        public string[] GetNames()
        {
            try
            {
                List<string> names = new List<string>();
                foreach (var face in QZFaceArr)
                {
                    if (face == null)
                        continue;
                    names.Add($"{face.Name}_{face.Id}");
                }

                return names.ToArray();

            }
            catch (Exception)
            {
            }

            return null;
        }

        public string[] GetGroups()
        {
            try
            {
                List<string> grpNames = new List<string>();
                foreach (var grp in QZGroupArr)
                {
                    if (grp == null)
                        continue;

                    grpNames.Add($"GRP_{grp.GNbr}");
                }

            

                return grpNames.ToArray();
            }
            catch (Exception)
            {
            }

            return null;


        }
    }
}
