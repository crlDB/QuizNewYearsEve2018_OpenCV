using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormWebCamm : Form
    {
        private Quiz2018 _qz;

        public VideoCapture WebCam { get; set; }
        public Mat Frame { get; set; }
        public CascadeClassifier FaceDetection { get; set; }
        public bool Busy { get; private set; }




        public FormWebCamm()
        {
            InitializeComponent();
            // webcam
            Frame = new Mat();
            FaceDetection = new CascadeClassifier(System.IO.Path.GetFullPath(@"../../Algo/haarcascade_frontalface_default.xml"));
            WebcamStart();
        }

        private void FormWebCamm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                WebCam.Stop();
                WebCam.Dispose();
                WebCam = null;
            }
            catch (Exception)
            {
            }




        }




        public void Init(Quiz2018 qz)
        {
            _qz = qz;
        }

        private void WebcamStart()
        {
            if (WebCam == null)
            {
                //1920 x 1080
                //1600 x 900
                //1366 x 768
                //1280 x 720
                //1024 x 57

                WebCam = new VideoCapture(0 + Emgu.CV.CvEnum.CaptureType.DShow);
                WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FourCC, VideoWriter.Fourcc('M', 'J', 'P', 'G'));
                WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 1280);   //1920.0 // 1280
                WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 720);  //1080.0 // 720
                WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Settings, 1);
                //WebCam.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Backlight, 0);

            }

            WebCam.ImageGrabbed += WebCam_ImageGrabbed;
            //Application.Idle += Application_Idle;
            WebCam.Start();
        }

        private void Application_Idle(object sender, EventArgs e)
        {

        }





        private void WebCam_ImageGrabbed(object sender, EventArgs e)
        {
            //try
            //{
            //    lock (WebCam)
            //    {
            //        if (Busy)
            //            return;

            //        Busy = true;

            //    }
            //    //Thread.Sleep(40);
            //    Frame = WebCam.QueryFrame();

            //    if (Frame == null)
            //    {
            //        Busy = false;
            //        return;
            //    }   

            //    Image<Bgr, byte> jjj = new Image<Bgr, byte>(0, 0);
            //    CvInvoke.CvtColor(Frame, jjj, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            //    CvInvoke.Imshow("ee", jjj);
            //    var tt = _qz.TQuestion.ImageAnswerGood.Resize(1280, 720, Inter.Cubic);

            //    CvInvoke.Imshow("dd", tt);

            //    Image<Bgr, byte> output = new Image<Bgr, byte>(1280, 720);
            //    CvInvoke.AddWeighted(Frame, 0.5, tt, 0.5, 0, output);
            //    CvInvoke.Imshow("outputs", output);

            //    CvInvoke.WaitKey(50);




            //}
            //catch (Exception)
            //{
            //}

            //Busy = false;
            //return;

            lock (WebCam)
            {
                if (Busy)
                    return;

                Busy = true;

            }



            try
            {

                Thread.Sleep(40);
                Frame = WebCam.QueryFrame();

                if (Frame == null)
                {
                    Busy = false;
                    return;
                }

                var imageFrame = Frame.ToImage<Bgr, byte>();
                if (imageFrame == null)
                {
                    Busy = false;
                    return;
                }

                imageFrame._Flip(Emgu.CV.CvEnum.FlipType.Horizontal);

                // mode
                switch (_qz.Mode)
                {
                    case EnMode.None:
                        imageFrame = ShowScore2(imageFrame);
                        break;
                    case EnMode.TRFStart:
                        imageFrame = TrainFace(imageFrame);
                        break;
                    case EnMode.TFStart:
                        imageFrame = TestFace(imageFrame);
                        break;
                    case EnMode.TGStart:
                        imageFrame = TestGroup(imageFrame);
                        break;
                    case EnMode.QStart:
                        imageFrame = Question(imageFrame);
                        break;
                    default:
                        break;
                }

                // draw image
                try
                {
                    // show image
                    ibWebCam.Image = imageFrame.Resize(0.96, Inter.Cubic);
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
            Busy = false;
        }

        private Image<Bgr, byte> Question(Image<Bgr, byte> imageFrame)
        {
            try
            {
                if (imageFrame == null)
                    return null;

                // copy frame, for detection objects
                var imgCommit = imageFrame.Copy(); //.Resize(300, 300, Inter.Linear, true);
                imgCommit = imgCommit.Resize(300, 300, Inter.Linear, true);

                // time elapsed
                long timeElapsed = _qz.TQuestion.QStopWatch.ElapsedMilliseconds;
                _qz.TQuestion.QStopWatchTimeDiv = timeElapsed - _qz.TQuestion.QStopWatchTime;
                _qz.TQuestion.QStopWatchTime = timeElapsed;

                // draw 3 parts
                int w = imageFrame.Width / 3;
                int h = imageFrame.Height;

                //imageFrame._EqualizeHist();
                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = FaceDetection.DetectMultiScale(grayFrame, 1.3, 5);

                int index = 1;
                foreach (var face in faces)
                {
                    // face recognition - detect faces/answer
                    var result = QuestionFaceRecognition0(grayFrame, face);

                    // face recognition1 - detect quetion/answer
                    QuestionFaceRecognition1(imageFrame, w, face, result);
                }

                // cycle
                QuestionCycle(imageFrame, imgCommit, w, h);
            }
            catch (Exception)
            {
            }

            return imageFrame;
        }

        private void QuestionCycle(Image<Bgr, byte> imageFrame, Image<Bgr, byte> imgCommit, int w, int h)
        {
            switch (_qz.TQuestion.Step1)
            {
                // check question-type
                case 0:

                    if (_qz.TQuestion.QType == EnQType.ThreeQA)
                        _qz.TQuestion.Step1 = 1;
                    else if (_qz.TQuestion.QType == EnQType.MakeFormation)
                        _qz.TQuestion.Step1 = 100;
                    break;

                case 1:
                    // grouptime
                    QuestionGroupTime();
                    // question - commit
                    QuestionCommit(imageFrame, imgCommit);

                    // question/ answer - draw boxes
                    QuestionDrawBoxes(w, h, imageFrame);
                    // group draw totaltime
                    QuestionDrawGroupTime(w, h, imageFrame);

                    // question/answer1 - left box
                    QuestionDrawAnswerInBox(w, 1, imageFrame);
                    // question/answer2 - middle box
                    QuestionDrawAnswerInBox(w, 2, imageFrame);
                    // question/answer3 - -right box 
                    QuestionDrawAnswerInBox(w, 3, imageFrame);
                    break;

                case 10:
                    // grouptime
                    QuestionGroupTime();
                    // group draw totaltime
                    QuestionDrawGroupTime(w, h, imageFrame);
                    // question check answer
                    QuestionCheckAnswerType1();
                    break;

                case 20:
                    // grouptime
                    QuestionGroupTime();
                    // group draw totaltime
                    QuestionDrawGroupTime(w, h, imageFrame);

                    // answer NOK
                    CvInvoke.AddWeighted(imageFrame, 0.5, _qz.TQuestion.ImageAnswerWrong, 0.5, 0, imageFrame);


                    _qz.TQuestion.QAnswerNOKTime += (int)_qz.TQuestion.QStopWatchTimeDiv;
                    if (_qz.TQuestion.QAnswerNOKTime > 2000)
                    {
                        _qz.TQuestion.QObjectGiveAnswerTime = 0;
                        _qz.TQuestion.QAnswerNOKTime = 0;
                        _qz.TQuestion.Step1 = 0;
                    }
                    break;

                case 30:
                    // answer OK
                    CvInvoke.AddWeighted(imageFrame, 0.5, _qz.TQuestion.ImageAnswerGood, 0.5, 0, imageFrame);

                    // group draw totaltime
                    QuestionDrawGroupTime(w, h, imageFrame);

                    _qz.TQuestion.QAnswerOKTime += (int)_qz.TQuestion.QStopWatchTimeDiv;
                    if (_qz.TQuestion.QAnswerOKTime > 2000)
                    {
                        _qz.TQuestion.QAnswerOKTime = 0;
                        _qz.TQuestion.Step1 = 40;
                        _qz.Mode = EnMode.None;
                        _qz.FormMainUpdate();
                    }
                    break;

                case 40:
                    // end
                    break;

                case 100:
                    // create answer
                    QuestionCreateNewFormat();

                    _qz.TQuestion.Step1 = 110;
                    goto case 110;

                case 110:
                    // grouptime
                    QuestionGroupTime();
                    // question check anser
                    QuestionCheckAnswerType2();

                    // question/ answer - draw boxes
                    QuestionDrawBoxes(w, h, imageFrame);
                    // group draw totaltime
                    QuestionDrawGroupTime(w, h, imageFrame);

                    // question/answer1 - left box
                    QuestionDrawAnswerInBox(w, 1, imageFrame);
                    // question/answer2 - middle box
                    QuestionDrawAnswerInBox(w, 2, imageFrame);
                    // question/answer3 - right box 
                    QuestionDrawAnswerInBox(w, 3, imageFrame);
                    break;

                case 120:
                    _qz.TQuestion.QType2Counter++;

                    if (_qz.TQuestion.QType2Counter >= 5)
                    {
                        _qz.TQuestion.QAnswerOKTime = 0;
                        _qz.TQuestion.Step1 = 140;
                        _qz.Mode = EnMode.None;
                        _qz.FormMainUpdate();
                    }
                    _qz.TQuestion.Step1 = 130;
                    break;

                case 130:
                    // answer OK
                    CvInvoke.AddWeighted(imageFrame, 0.5, _qz.TQuestion.ImageAnswerGood, 0.5, 0, imageFrame);

                    _qz.TQuestion.QAnswerOKTime += (int)_qz.TQuestion.QStopWatchTimeDiv;
                    if (_qz.TQuestion.QAnswerOKTime > 2000)
                    {
                        _qz.TQuestion.QGivenAnswerNbr[1] = 0;
                        _qz.TQuestion.QGivenAnswerNbr[2] = 0;
                        _qz.TQuestion.QGivenAnswerNbr[3] = 0;
                        _qz.TQuestion.QGivenAnswerPrevNbr[1] = 0;
                        _qz.TQuestion.QGivenAnswerPrevNbr[2] = 0;
                        _qz.TQuestion.QGivenAnswerPrevNbr[3] = 0;

                        _qz.TQuestion.QAnswerOKTime = 0;
                        _qz.TQuestion.Step1 = 100;
                    }

                    break;

                case 140:
                    break;



                default:
                    _qz.TQuestion.Step1 = 0;

                    break;
            }
        }

        private void QuestionCreateNewFormat()
        {
            var faceString = new string[10];
            var grp = _qz.TQuestion.QGrpNbr;

            // answer for face1
            Random random = new Random();
            int rnbr1 = random.Next(1, 4);
            int rnbr2 = 0;
            int rnbr3 = 0;

            if (rnbr1 == 1)
            {
                if (random.Next(1, 3) == 1)
                {
                    rnbr2 = 2;
                    rnbr3 = 3;
                }
                else
                {
                    rnbr2 = 3;
                    rnbr3 = 2;
                }
            }
            else if (rnbr1 == 2)
            {
                if (random.Next(1, 3) == 1)
                {
                    rnbr2 = 1;
                    rnbr3 = 3;
                }
                else
                {
                    rnbr2 = 3;
                    rnbr3 = 1;
                }
            }
            else if (rnbr1 == 3)
            {
                if (random.Next(1, 3) == 1)
                {
                    rnbr2 = 1;
                    rnbr3 = 2;
                }
                else
                {
                    rnbr2 = 2;
                    rnbr3 = 1;
                }
            }


            // name formation
            faceString[1] = _qz.QZFaceArr[_qz.QZGroupArr[grp].GFaceIds[rnbr1]].Name;
            faceString[2] = _qz.QZFaceArr[_qz.QZGroupArr[grp].GFaceIds[rnbr2]].Name;
            faceString[3] = _qz.QZFaceArr[_qz.QZGroupArr[grp].GFaceIds[rnbr3]].Name;

            // question is the name of the peron
            _qz.QZQuestionArr[_qz.TQuestion.QNbr].QuestionArr[1] = faceString[1];
            _qz.QZQuestionArr[_qz.TQuestion.QNbr].QuestionArr[2] = faceString[2];
            _qz.QZQuestionArr[_qz.TQuestion.QNbr].QuestionArr[3] = faceString[3];
            // answer is the name of the person
            _qz.QZQuestionArr[_qz.TQuestion.QNbr].AnswerArr[1] = faceString[1];
            _qz.QZQuestionArr[_qz.TQuestion.QNbr].AnswerArr[2] = faceString[2];
            _qz.QZQuestionArr[_qz.TQuestion.QNbr].AnswerArr[3] = faceString[3];
        }

        private void QuestionCheckAnswerType1()
        {
            // check answer
            bool qa1 = QuestionCheckAnswer2(1) || _qz.TQuestion.QForceAnswerNbr[1];
            bool qa2 = QuestionCheckAnswer2(2) || _qz.TQuestion.QForceAnswerNbr[2];
            bool qa3 = QuestionCheckAnswer2(3) || _qz.TQuestion.QForceAnswerNbr[3];

            if (qa1 && qa2 && qa3)
                // answer OK
                _qz.TQuestion.Step1 = 30;
            else
                // answer NOK
                _qz.TQuestion.Step1 = 20;
        }

        private void QuestionCheckAnswerType2()
        {
            // check answer
            bool qa1 = QuestionCheckAnswer2(1) || _qz.TQuestion.QForceAnswerNbr[1];
            bool qa2 = QuestionCheckAnswer2(2) || _qz.TQuestion.QForceAnswerNbr[2];
            bool qa3 = QuestionCheckAnswer2(3) || _qz.TQuestion.QForceAnswerNbr[3];

            if (qa1 && qa2 && qa3)
                // answer OK
                _qz.TQuestion.Step1 = 120;
        }

        private void QuestionCommit(Image<Bgr, byte> imageFrame, Image<Bgr, byte> imgCommit)
        {
            // check answer is correct
            bool qCommit = _qz.QCommit.CheckShape(imgCommit, imageFrame, _qz.TQuestion.QObjectGiveAnswerTime);
            //qCommit = false;
            if (qCommit)
            {
                _qz.TQuestion.CommitON = true;
                _qz.TQuestion.CommitOffTime = 0;
            }
            else
            {
                _qz.TQuestion.CommitOffTime += (int)_qz.TQuestion.QStopWatchTimeDiv;
                if (_qz.TQuestion.CommitOffTime > 500)
                    _qz.TQuestion.CommitON = false;
            }

            if (_qz.TQuestion.CommitON)
            {
                _qz.TQuestion.QObjectGiveAnswerTime += (int)_qz.TQuestion.QStopWatchTimeDiv;

                if (_qz.TQuestion.QObjectGiveAnswerTime > 3000)
                {
                    _qz.TQuestion.CommitON = false;
                    _qz.TQuestion.Step1 = 10;
                }
            }
            else
            {
                _qz.TQuestion.QObjectGiveAnswerTime = 0;
            }
        }

        private FaceRecognizer.PredictionResult QuestionFaceRecognition0(Image<Gray, byte> grayFrame, Rectangle face)
        {
            var procImg = grayFrame.Copy(face).Resize(
                            _qz.TRF_IMAGE_WIDTH,
                            _qz.TRF_IMAGE_HEIGHT,
                            Emgu.CV.CvEnum.Inter.Cubic);

            var grpINdex = _qz.TQuestion.QGrpNbr;

            if (_qz.QZGroupArr[grpINdex].FaceRecoLBPHF == null)
                return new FaceRecognizer.PredictionResult();

            //var result = _qz.QZGroupArr[grpINdex].FaceRecoEigen.Predict(procImg);
            //var result = _qz.QZGroupArr[grpINdex].FaceRecoFisher.Predict(procImg);
            var result = _qz.QZGroupArr[grpINdex].FaceRecoLBPHF.Predict(procImg);
            return result;
        }

        private void QuestionFaceRecognition1(Image<Bgr, byte> imageFrame, int w, Rectangle face, FaceRecognizer.PredictionResult result)
        {
            try
            {
                if (result.Label != -1)
                {
                    int pos = 0;
                    // where located
                    if (face.Left < w)
                    {
                        if ((w - face.Left) < (w / 3))
                            pos = 2;
                        else
                            pos = 1;
                    }
                    else if (face.Left > (2 * w))
                        pos = 3;
                    else
                    {
                        if (((2 * w) - face.Left) < (w / 3))
                            pos = 3;
                        else
                            pos = 2;
                    }


                    // answer
                    int faceAnswerNbr = _qz.QZFaceArr[result.Label].Answer;
                    int x = 0;

                    switch (pos)
                    {
                        case 1:
                            // box1 (question1)
                            QuestionCheckAnswer(1, faceAnswerNbr);
                            x = 0 * w;
                            break;

                        case 2:
                            // box2 (question2)
                            QuestionCheckAnswer(2, faceAnswerNbr);
                            x = 1 * w;
                            break;

                        case 3:
                            // box3 (question3)
                            QuestionCheckAnswer(3, faceAnswerNbr);
                            x = 2 * w;
                            break;

                        default:
                            break;
                    }

                    // data for face
                    string fName = _qz.QZFaceArr[result.Label].Name;
                    int fAnswerNbr = _qz.QZFaceArr[result.Label].Answer;
                    string fAnswerStr = "";

                    if (_qz.TQuestion.QType == EnQType.ThreeQA)
                        fAnswerStr = _qz.QZQuestionArr[_qz.TQuestion.QNbr].AnswerArr[fAnswerNbr];
                    else if (_qz.TQuestion.QType == EnQType.MakeFormation)
                        fAnswerStr = fName;

                    imageFrame.Draw($"{fName}", face.Location, Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.8, new Bgr(Color.Red));
                    imageFrame.Draw($"{fAnswerStr}", new Point(face.Location.X, face.Location.Y - 30), Emgu.CV.CvEnum.FontFace.HersheySimplex, 1.0, new Bgr(Color.Red));
                    imageFrame.Draw(face, new Bgr(Color.BurlyWood), 1);
                }
                else
                {
                    imageFrame.Draw($"????", face.Location, Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.8, new Bgr(Color.Red));
                    imageFrame.Draw(face, new Bgr(Color.AliceBlue), 5);
                }
            }
            catch (Exception)
            {
            }
        }

        private void QuestionGroupTime()
        {

            _qz.QZGroupArr[_qz.TQuestion.QGrpNbr].GTime += (int)_qz.TQuestion.QStopWatchTimeDiv;
            _qz.FrmMain.UpdateScore(_qz.TQuestion.QGrpNbr, _qz.QZGroupArr[_qz.TQuestion.QGrpNbr].GTime, _qz.QZGroupArr[_qz.TQuestion.QGrpNbr].GTotalTime);
        }


        private void QuestionDrawBoxes(int w, int h, Image<Bgr, byte> imageFrame)
        {
            try
            {
                int index = 1;
                imageFrame.Draw(new Rectangle((index - 1) * w, 0, w, h), new Bgr(Color.Yellow), 2);
                imageFrame.Draw($"{_qz.QZQuestionArr[_qz.TQuestion.QNbr].QuestionArr[index]}", new Point((index - 1) * w, h - 100), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.8, new Bgr(Color.Yellow), 2);
                index = 2;
                imageFrame.Draw(new Rectangle((index - 1) * w, 0, w, h), new Bgr(Color.Yellow), 2);
                imageFrame.Draw($"{_qz.QZQuestionArr[_qz.TQuestion.QNbr].QuestionArr[index]}", new Point((index - 1) * w, h - 60), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.8, new Bgr(Color.Yellow), 2);
                index = 3;
                imageFrame.Draw(new Rectangle((index - 1) * w, 0, w, h), new Bgr(Color.Yellow), 2);
                imageFrame.Draw($"{_qz.QZQuestionArr[_qz.TQuestion.QNbr].QuestionArr[index]}", new Point((index - 1) * w, h - 30), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.8, new Bgr(Color.Yellow), 2);

            }
            catch (Exception)
            {
            }
        }

        private void QuestionDrawGroupTime(int w, int h, Image<Bgr, byte> imageFrame)
        {
            try
            {
                imageFrame.Draw($"{_qz.QZGroupArr[_qz.TQuestion.QGrpNbr].GTime / 1000}s.", new Point(10, h - 20), Emgu.CV.CvEnum.FontFace.HersheyTriplex, 2.0, new Bgr(Color.WhiteSmoke));
            }
            catch (Exception)
            {
            }
        }

        private void QuestionDrawAnswerInBox(int w, int index, Image<Bgr, byte> imageFrame)
        {
            try
            {
                int fceAnswerNbr = _qz.TQuestion.QGivenAnswerNbr[index];
                string fceAnswerStr = "";
                if (_qz.TQuestion.QType == EnQType.ThreeQA)
                    fceAnswerStr = _qz.QZQuestionArr[_qz.TQuestion.QNbr].AnswerArr[fceAnswerNbr];
                else if (_qz.TQuestion.QType == EnQType.MakeFormation)
                    fceAnswerStr = _qz.QZFaceArr[fceAnswerNbr].Name;


                imageFrame.Draw($"{fceAnswerStr}", new Point((index - 1) * w, 50), Emgu.CV.CvEnum.FontFace.HersheyPlain, 2.0, new Bgr(Color.Red), 3);
            }
            catch (Exception)
            {
            }
        }

        private void QuestionCheckAnswer(int index, int faceAnswerNbr)
        {
            try
            {
                // new answer for qa1
                if (faceAnswerNbr != _qz.TQuestion.QGivenAnswerPrevNbr[index])
                {
                    _qz.TQuestion.QGivenAnswerTimeOn[index] += (int)_qz.TQuestion.QStopWatchTimeDiv;
                    if (_qz.TQuestion.QGivenAnswerTimeOn[index] > 1000)
                    {
                        _qz.TQuestion.QGivenAnswerNbr[index] = faceAnswerNbr;
                        _qz.TQuestion.QGivenAnswerPrevNbr[index] = faceAnswerNbr;
                        _qz.TQuestion.QGivenAnswerTimeOn[index] = 0;
                    }
                }
                else
                {
                    _qz.TQuestion.QGivenAnswerTimeOn[index] = 0;
                }

            }
            catch (Exception)
            {
            }

        }

        private bool QuestionCheckAnswer2(int index)
        {
            try
            {
                int Q1givenAnswerNbr = _qz.TQuestion.QGivenAnswerNbr[index];

                string Q1givenAnswerStr = "";
                if (_qz.TQuestion.QType == EnQType.ThreeQA)
                    Q1givenAnswerStr = _qz.QZQuestionArr[_qz.TQuestion.QNbr].AnswerArr[Q1givenAnswerNbr];
                else if (_qz.TQuestion.QType == EnQType.MakeFormation)
                    Q1givenAnswerStr = _qz.QZFaceArr[Q1givenAnswerNbr].Name;

                //
                string Q1answerStr = _qz.QZQuestionArr[_qz.TQuestion.QNbr].AnswerArr[index];

                return (Q1givenAnswerStr == Q1answerStr);

            }
            catch (Exception)
            {
            }

            return false;
        }

        private Image<Bgr, byte> TestFace(Image<Bgr, byte> imageFrame)
        {
            try
            {

                if (imageFrame == null)
                    return null;

                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = FaceDetection.DetectMultiScale(grayFrame, 1.3, 5);

                foreach (var face in faces)
                {
                    var procImg = grayFrame.Copy(face).Resize(
                                    _qz.TRF_IMAGE_WIDTH,
                                    _qz.TRF_IMAGE_HEIGHT,
                                    Emgu.CV.CvEnum.Inter.Cubic);
                    var result = _qz.TFaces.FaceRecognition.Predict(procImg);

                    try
                    {
                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3);
                        imageFrame.Draw($"{_qz.QZFaceArr[result.Label].Name}", face.Location, Emgu.CV.CvEnum.FontFace.HersheyTriplex, 1.0, new Bgr(Color.Red));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }

            return imageFrame;

        }

        private Image<Bgr, byte> TestGroup(Image<Bgr, byte> imageFrame)
        {
            try
            {
                if (imageFrame == null)
                    return null;

                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = FaceDetection.DetectMultiScale(grayFrame, 1.2, 5);

                foreach (var face in faces)
                {
                    var procImg = grayFrame.Copy(face).Resize(
                                    _qz.TRF_IMAGE_WIDTH,
                                    _qz.TRF_IMAGE_HEIGHT,
                                    Emgu.CV.CvEnum.Inter.Cubic);
                    var result = _qz.QZGroupArr[_qz.QZTGroup.TGroupNbr].FaceRecoEigen.Predict(procImg);

                    try
                    {
                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3);
                        imageFrame.Draw($"{_qz.QZFaceArr[result.Label].Name}", face.Location, Emgu.CV.CvEnum.FontFace.HersheyTriplex, 1.0, new Bgr(Color.Red));

                        //                    if (result.Distance > 1.0)
                        //                        imageFrame.Draw($"{_qz.QSet.Faces[result.Label].Name}", face.Location, Emgu.CV.CvEnum.FontFace.HersheyTriplex, 1.0, new Bgr(Color.Red));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }

            return imageFrame;

        }

        private Mat ShowScore(Image<Bgr, byte> imageFrame)
        {
            try
            {


                //CvInvoke.Resize(imageFram, imageFrame, new Size(100, 100));


                List<QZScore> score = new List<QZScore>();

                foreach (var grp in _qz.QZGroupArr)
                {
                    // grp ?
                    if (grp == null)
                        continue;

                    // score
                    QZScore scr = new QZScore();
                    scr.GrpNbr = grp.GNbr;
                    scr.GrpSymbol = grp.GSymbol;
                    scr.Score = grp.GTime;
                    scr.ScoreTot = grp.GTotalTime;

                    score.Add(scr);
                }

                int y = 100;
                foreach (var grp in score.OrderBy(x => x.ScoreTot))
                {
                    imageFrame.Draw($"| G{grp.GrpNbr}", new Point(10, y), Emgu.CV.CvEnum.FontFace.HersheyPlain, 4.0, new Bgr(Color.Yellow), 3);
                    imageFrame.Draw($"| {grp.GrpSymbol}", new Point(150, y), Emgu.CV.CvEnum.FontFace.HersheyPlain, 4.0, new Bgr(Color.Yellow), 3);
                    imageFrame.Draw($"| {(grp.Score / 1000).ToString("N0")}", new Point(650, y), Emgu.CV.CvEnum.FontFace.HersheyPlain, 4.0, new Bgr(Color.Yellow), 3);
                    imageFrame.Draw($"| {(grp.ScoreTot / 1000).ToString("N0")}", new Point(950, y), Emgu.CV.CvEnum.FontFace.HersheyPlain, 4.0, new Bgr(Color.Yellow), 5);

                    y += 100;
                }

                Mat imageFram = new Mat(); //= new Image<Bgr, byte>(1280, 720);
                CvInvoke.Canny(imageFrame, imageFram, 100, 100);
                CvInvoke.Imshow("eee", imageFram);
                CvInvoke.WaitKey(1);

                return imageFram;
            }
            catch (Exception)
            {
            }

            return null;

        }

        private Image<Bgr, byte> ShowScore2(Image<Bgr, byte> imageFrame)
        {
            try
            {
                if (imageFrame == null)
                    return null;

                //Mat imageTo = new Mat();
                //CvInvoke.CvtColor(imageFrame, imageTo, ColorConversion.Bgr2Gray);
                //CvInvoke.CvtColor(imageFrame, imageTo, ColorConversion.Bgra2YuvYv12);
                //CvInvoke.CvtColor(imageFrame, imageTo, ColorConversion.Rgb2HsvFull);
                //Mat imageTo2 = new Mat();
                ///CvInvoke.Canny(imageTo, imageTo2, 80, 100);

                //Mat imageGray = new Mat();
                //CvInvoke.CvtColor(imageFrame, imageGray, ColorConversion.Bgr2Gray);

                //Mat imageBlur = new Mat();
                //CvInvoke.MedianBlur(imageGray, imageBlur, 5);

                //Mat imageEdge = new Mat();
                //CvInvoke.AdaptiveThreshold(imageBlur, imageEdge, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 5, 4);
                //CvInvoke.Imshow("edge", imageEdge);
                //CvInvoke.WaitKey(1);

                //Mat color = new Mat();
                //CvInvoke.BilateralFilter(imageFrame, color, 9, 300, 300);
                //CvInvoke.Imshow("or", imageFrame);
                //CvInvoke.WaitKey(1);
                //CvInvoke.Imshow("blur", color);
                //CvInvoke.WaitKey(1);

                //Mat cartoon = new Mat();
                //CvInvoke.BitwiseAnd(color, color, cartoon, imageEdge);
                //CvInvoke.Imshow("cartoon", cartoon);
                //CvInvoke.WaitKey(1);

                Mat blurred = new Mat();
                CvInvoke.MedianBlur(imageFrame, blurred, 5);
                //CvInvoke.Imshow("blur", blurred);
                //CvInvoke.WaitKey(1);

                Mat can = new Mat();
                CvInvoke.Canny(blurred, can, 80, 100);
                //CvInvoke.Imshow("can", can);
                //CvInvoke.WaitKey(1);

                imageFrame = can.ToImage<Bgr, byte>();

                List<QZScore> score = new List<QZScore>();

                foreach (var grp in _qz.QZGroupArr)
                {
                    // grp ?
                    if (grp == null)
                        continue;

                    // score
                    QZScore scr = new QZScore();
                    scr.GrpNbr = grp.GNbr;
                    scr.GrpSymbol = grp.GSymbol;
                    scr.Score = grp.GTime;
                    scr.ScoreTot = grp.GTotalTime;

                    score.Add(scr);
                }

                int y = 100;

                foreach (var grp in score.OrderBy(x => x.ScoreTot))
                {
                    if ((grp.Score == 0) && (grp.ScoreTot == 0))
                        continue;
                    imageFrame.Draw($"| G{grp.GrpNbr}", new Point(10, y), Emgu.CV.CvEnum.FontFace.HersheyPlain, 4.0, new Bgr(Color.Yellow), 3);
                    imageFrame.Draw($"| {grp.GrpSymbol}", new Point(150, y), Emgu.CV.CvEnum.FontFace.HersheyPlain, 4.0, new Bgr(Color.Yellow), 3);
                    imageFrame.Draw($"| {(grp.Score / 1000).ToString("N0")}", new Point(650, y), Emgu.CV.CvEnum.FontFace.HersheyPlain, 4.0, new Bgr(Color.Yellow), 3);
                    imageFrame.Draw($"| {(grp.ScoreTot / 1000).ToString("N0")}", new Point(950, y), Emgu.CV.CvEnum.FontFace.HersheyPlain, 4.0, new Bgr(Color.Yellow), 5);

                    y += 100;
                }

                return imageFrame;
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        private Image<Bgr, byte> TrainFace(Image<Bgr, byte> imageFrame)
        {
            try
            {
                if (imageFrame == null)
                    return null;

                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = FaceDetection.DetectMultiScale(grayFrame, 1.2, 5);

                if (faces.Count() == 1)
                {
                    imageFrame.Draw(faces[0], new Bgr(Color.BurlyWood), 3);

                    _qz.TRFaces.WaitCycle++;
                    if (_qz.TRFaces.WaitCycle < 20)
                        return imageFrame;

                    _qz.TRFaces.WaitCycle = 0;
                    _qz.TRFaces.TrainNbr++;

                    var trfImage = grayFrame.Copy(faces[0]).Resize(
                        _qz.TRF_IMAGE_WIDTH,
                        _qz.TRF_IMAGE_HEIGHT,
                        Emgu.CV.CvEnum.Inter.Cubic);

                    _qz.TRFaces.TrainFace.Add(trfImage);
                    //_qz.FrmTrain.SetPicture(_qz.TRFaces.TrainNbr, trfImage);
                }

                if (_qz.TRFaces.TrainNbr >= 3)
                {
                    _qz.Mode = EnMode.None;
                    _qz.FormMainUpdate();
                }

            }
            catch (Exception)
            {
            }

            return imageFrame;

        }

    }
}
