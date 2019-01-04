using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum EnQType
    {
        ThreeQA = 1,
        OneQA = 2,
        MakeFormation = 3
    }

    public class QZScore
    {

        public int GrpNbr { get; set; }
        public string GrpSymbol { get; set; }

        public int Place { get; set; }
        public int Score { get; set; }
        public int ScoreTot { get; set; }
    }


    public class QZQuestion
    {
        public int QNbr { get; set; }
        public string Text1 { get; set; }
        public int Type { get; set; }
        public string[] QuestionArr { get; set; }
        public string[] AnswerArr { get; set; }
    }


    public class TestQuestion
    {
        public int QNbr { get; set; }
        public int QGrpNbr { get; set; }
        public EnQType QType { get; set; }

        public Stopwatch QStopWatch { get; set; }
        public long QStopWatchTime { get; set; }
        public long QStopWatchTimeDiv { get; set; }


        public bool[] QForceAnswerNbr { get; set; }
        public int[] QGivenAnswerNbr { get; set; }
        public int[] QGivenAnswerPrevNbr { get; set; }
        public int[] QGivenAnswerTimeOn { get; set; }



        public int QObjectGiveAnswerTime { get; set; }
        public int QAnswerNOKTime { get; set; }
        public int QAnswerOKTime { get; set; }

        public int QType2Counter { get; set; }


        public int Step1 { get; set; }

        public Image<Bgr, byte> ImageAnswerWrong { get; set; }
        public Image<Bgr, byte> ImageAnswerGood { get; set; }

        // 
        public bool CommitON { get; set; }
        public int CommitOnTime { get; set; }
        public int CommitOffTime { get; set; }
    }





    public partial class Quiz2018
    {
        public QZQuestion[] QZQuestionArr { get; set; }
        public TestQuestion TQuestion { get; set; }

        public OpenCvShape QCommit { get; set; }


        public void QuestionStart(string qNbr, string gNbr)
        {
            try
            {


                // question
                TQuestion = new TestQuestion();

                TQuestion.QGivenAnswerNbr = new int[10];
                TQuestion.QGivenAnswerPrevNbr = new int[10];
                TQuestion.QGivenAnswerTimeOn = new int[10];
                TQuestion.QForceAnswerNbr = new bool[10];

                TQuestion.QStopWatch = new Stopwatch();
                TQuestion.QStopWatch.Start();
                TQuestion.QStopWatchTime = TQuestion.QStopWatch.ElapsedMilliseconds;
                TQuestion.Step1 = 0;
                TQuestion.QObjectGiveAnswerTime = 0;
                TQuestion.ImageAnswerGood = new Image<Bgr, byte>(System.IO.Path.GetFullPath($@"../../Images/AnswerOK.png"));
                TQuestion.ImageAnswerGood = TQuestion.ImageAnswerGood.Resize(1280, 720, Emgu.CV.CvEnum.Inter.Cubic);
                TQuestion.ImageAnswerWrong = new Image<Bgr, byte>(System.IO.Path.GetFullPath($@"../../Images/AnswerNOK.png"));
                TQuestion.ImageAnswerWrong = TQuestion.ImageAnswerWrong.Resize(1280, 720, Emgu.CV.CvEnum.Inter.Cubic);

                QCommit = new OpenCvShape(QSet);

                int quesNbr = -1;
                try
                {
                    quesNbr = int.Parse(qNbr.Split('_')[1]);
                }
                catch (Exception)
                {
                }
                if (quesNbr <= 0)
                    return;
                TQuestion.QNbr = quesNbr;



                int groupNbr = -1;
                try
                {
                    groupNbr = int.Parse(gNbr.Split('_').Last());
                }
                catch (Exception)
                {
                }

                if (groupNbr <= 0)
                    return;
                TQuestion.QGrpNbr = groupNbr;

                // questiontype
                TQuestion.QType = (EnQType)QZQuestionArr[TQuestion.QNbr].Type;
                TQuestion.QType2Counter = 0;

                // load faces for group
                QuestionLoadFaces(groupNbr);

                // set answer to faces
                var face1Id = QZGroupArr[groupNbr].GFaceIds[1];
                var face2Id = QZGroupArr[groupNbr].GFaceIds[2];
                var face3Id = QZGroupArr[groupNbr].GFaceIds[3];


                // type1 ------------------------------------------------->
                if (TQuestion.QType == EnQType.ThreeQA)
                {
                    // answer for face1
                    Random random = new Random();
                    var rnbr1 = random.Next(1, 4);

                    // answer to face1
                    QZFaceArr[face1Id].Answer = rnbr1;

                    if (rnbr1 == 1)
                    {
                        var rnnbr2 = random.Next(1, 3);
                        if (rnnbr2 == 1)
                        {
                            QZFaceArr[face2Id].Answer = 2;
                            QZFaceArr[face3Id].Answer = 3;
                        }
                        else
                        {
                            QZFaceArr[face2Id].Answer = 3;
                            QZFaceArr[face3Id].Answer = 2;
                        }
                    }
                    else if (rnbr1 == 2)
                    {
                        var rnnbr2 = random.Next(1, 3);
                        if (rnnbr2 == 1)
                        {
                            QZFaceArr[face2Id].Answer = 1;
                            QZFaceArr[face3Id].Answer = 3;
                        }
                        else
                        {
                            QZFaceArr[face2Id].Answer = 3;
                            QZFaceArr[face3Id].Answer = 1;
                        }
                    }
                    else if (rnbr1 == 3)
                    {
                        var rnnbr2 = random.Next(1, 3);
                        if (rnnbr2 == 1)
                        {
                            QZFaceArr[face2Id].Answer = 1;
                            QZFaceArr[face3Id].Answer = 2;
                        }
                        else
                        {
                            QZFaceArr[face2Id].Answer = 2;
                            QZFaceArr[face3Id].Answer = 1;
                        }
                    }
                }
                // type2 ------------------------------------------------->
                else if (TQuestion.QType == EnQType.MakeFormation)
                {
                    QZFaceArr[face1Id].Answer = QZGroupArr[groupNbr].GFaceIds[1];
                    QZFaceArr[face2Id].Answer = QZGroupArr[groupNbr].GFaceIds[2];
                    QZFaceArr[face3Id].Answer = QZGroupArr[groupNbr].GFaceIds[3];
                }

                // open formwebcam
                FormWebCamOpen();

                // test question
                Mode = EnMode.QStart;
                FrmMain.ButtonBackColor();
            }
            catch (Exception ex)
            {

            }

        }

        public void CreateQuestionsArr()
        {
            // create faces
            int maxId = QSet.Questions.Max(x => x.Nbr);
            QZQuestionArr = new QZQuestion[maxId + 1];

            foreach (var qs in QSet.Questions)
            {
                if (qs == null)
                    continue;
                if (qs.Nbr <= 0)
                    continue;

                QZQuestionArr[qs.Nbr] = new QZQuestion();
                QZQuestionArr[qs.Nbr].QNbr = qs.Nbr;
                QZQuestionArr[qs.Nbr].Text1 = qs.Text1;
                QZQuestionArr[qs.Nbr].Type = qs.Type;
                QZQuestionArr[qs.Nbr].QuestionArr = new string[4];
                QZQuestionArr[qs.Nbr].QuestionArr[1] = qs.Question1;
                QZQuestionArr[qs.Nbr].QuestionArr[2] = qs.Question2;
                QZQuestionArr[qs.Nbr].QuestionArr[3] = qs.Question3;
                QZQuestionArr[qs.Nbr].AnswerArr = new string[4];
                QZQuestionArr[qs.Nbr].AnswerArr[1] = qs.Answer1;
                QZQuestionArr[qs.Nbr].AnswerArr[2] = qs.Answer2;
                QZQuestionArr[qs.Nbr].AnswerArr[3] = qs.Answer3;
            }
        }
        public void QuestionLoadFaces(int group)
        {
            try
            {

                QZGroupArr[group].TrainFace = new List<Image<Gray, byte>>();
                QZGroupArr[group].TrainFaceId = new List<int>();

                // load images
                string dir = System.IO.Path.GetFullPath($@"../../Faces/");
                string[] fileEntries = Directory.GetFiles(dir);
                foreach (string fileName in fileEntries)
                {
                    string file = Path.GetFileNameWithoutExtension(fileName);

                    string[] faceParts = file.Split('_');
                    string faceName = faceParts[0];
                    int faceId = Convert.ToInt32(faceParts[1]);

                    if (QZFaceArr[faceId].Group == group)
                    {
                        QZGroupArr[group].TrainFace.Add(new Image<Gray, byte>(fileName));
                        QZGroupArr[group].TrainFaceId.Add(faceId);
                    }
                }


                // train faces
                QZGroupArr[group].FaceRecoEigen = new EigenFaceRecognizer(80, double.PositiveInfinity);
                QZGroupArr[group].FaceRecoEigen.Train(QZGroupArr[group].TrainFace.ToArray(), QZGroupArr[group].TrainFaceId.ToArray());

                QZGroupArr[group].FaceRecoFisher = new FisherFaceRecognizer();
                QZGroupArr[group].FaceRecoFisher.Train(QZGroupArr[group].TrainFace.ToArray(), QZGroupArr[group].TrainFaceId.ToArray());

                QZGroupArr[group].FaceRecoLBPHF = new LBPHFaceRecognizer();
                QZGroupArr[group].FaceRecoLBPHF.Train(QZGroupArr[group].TrainFace.ToArray(), QZGroupArr[group].TrainFaceId.ToArray());




            }
            catch (Exception ex)
            {
            }

        }

        public string[] GetQuestions()
        {
            try
            {
                List<string> qNames = new List<string>();
                foreach (var qs in QZQuestionArr)
                {
                    if (qs == null)
                        continue;

                    qNames.Add($"Q_{qs.QNbr}_{qs.Text1}");
                }

                return qNames.ToArray();
            }
            catch (Exception)
            {
            }

            return null;


        }



    }
}
