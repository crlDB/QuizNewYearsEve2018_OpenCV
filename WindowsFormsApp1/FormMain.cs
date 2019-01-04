using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        private Quiz2018 _qz2018;


        public VideoCapture WebCam { get; set; }
        public EigenFaceRecognizer FaceRecognition { get; set; }
        public CascadeClassifier FaceDetection { get; set; }

        public Mat Frame { get; set; } // 
        public List<Image<Gray, byte>> Faces { get; set; }
        public List<int> Ids { get; set; }
        public List<string> Names { get; set; }
        public int ProcessImageWidth { get; set; } = 128; //128;
        public int ProcessImageHeight { get; set; } = 200;

        public int TimerCounter { get; set; } = 0;
        public int TimeLimit { get; set; } = 10;
        public int ScanCounter { get; set; } = 0;

        public string YMLPath { get; set; } = @"../../Algo/TrainingData.yml";

        public Timer Timer { get; set; }
        public bool FaceSquare { get; set; } = false;
        public bool EyeSquare { get; set; } = false;



        public FormMain()
        {
            InitializeComponent();

            _qz2018 = new Quiz2018();
            _qz2018.Init(this);

            cbTRFFaces.Items.AddRange(_qz2018.GetNames());
            cbTFFaces.Items.AddRange(_qz2018.GetNames());
            cbTFFaces.Items.Add("ALL");

            cbTGGroups.Items.AddRange(_qz2018.GetGroups());

            cbQNbr.Items.AddRange(_qz2018.GetQuestions());
            cbQGrp.Items.AddRange(_qz2018.GetGroups());



            FaceRecognition = new EigenFaceRecognizer(80, double.PositiveInfinity);
            FaceDetection = new CascadeClassifier(System.IO.Path.GetFullPath(@"../../Algo/haarcascade_frontalface_default.xml"));
            Frame = new Mat();
            Faces = new List<Image<Gray, byte>>();
            Ids = new List<int>();
            Names = new List<string>();

            //BeginWebcam();

        }

        private void BeginWebcam()
        {
            if (WebCam == null)
                WebCam = new VideoCapture();

            WebCam.ImageGrabbed += WebCam_ImageGrabbed;
            WebCam.Start();
            //tbOutput.AppendText($"Webcam Started ...{Environment.NewLine}");

        }

        private void WebCam_ImageGrabbed(object sender, EventArgs e)
        {
            WebCam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Bgr, byte>();

            if (imageFrame != null)
            {
                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = FaceDetection.DetectMultiScale(grayFrame, 1.3, 5);

                foreach (var face in faces)
                {
                    imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3);

                    try
                    {
                        var procImg = grayFrame.Copy(face).Resize(ProcessImageWidth, ProcessImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                        if (_qz2018.FrmTrain != null)
                            _qz2018.FrmTrain.SetPicture(1, procImg);



                        //imageBox1.Image = procImg;
                        var result = FaceRecognition.Predict(procImg);
                        imageFrame.Draw($"<{result.Label}>", face.Location, Emgu.CV.CvEnum.FontFace.HersheyTriplex, 1.0, new Bgr(Color.Red));
                    }
                    catch (Exception ex)
                    {
                    }
                }

                //imageWebCam.Image = imageFrame;
            }
        }

        private void btnBeginTraining_Click(object sender, EventArgs e)
        {
            //            Faces = new List<Image<Gray, byte>>();
            //            Ids = new List<int>();

            //if (tbID.Text != string.Empty)
            //{
            //    tbID.Enabled = false;
            //    btnBeginTraining.Enabled = false;

            //    Timer = new Timer();
            //    Timer.Interval = 100;
            //    Timer.Tick += Timer_Tick;
            //    Timer.Start();
            //}
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            WebCam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, byte>();

            if (TimerCounter < TimeLimit)
            {
                TimerCounter++;
                if (imageFrame != null)
                {
                    //imageBox1.Image = imageFrame;
                    var faces = FaceDetection.DetectMultiScale(imageFrame, 1.3, 5);
                    if (faces.Count() > 0)
                    {
                        var procImage = imageFrame.Copy(faces[0]).Resize(ProcessImageWidth, ProcessImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                        Faces.Add(procImage);
                        //Ids.Add(Convert.ToInt32(tbID.Text));
                        //Names.Add(tbName.Text);
                        ScanCounter++;
                        //tbOutput.AppendText($"{ScanCounter} successfull scabs taken .. {Environment.NewLine}");
                        //tbOutput.ScrollToCaret();

                    }
                }
            }
            else
            {
                // train faces !!!
                FaceRecognition.Train(Faces.ToArray(), Ids.ToArray());
                FaceRecognition.Write(YMLPath);



                //foreach (var face in Faces)
                //{


                //}

                Timer.Stop();
                TimerCounter = 0;
                //tbID.Enabled = true;
                //btnBeginTraining.Enabled = true;
                //tbOutput.AppendText($"Taining Complete {Environment.NewLine}");
                MessageBox.Show("Training completed");

            }
        }

        private void btnFaceSquareOFF_Click(object sender, EventArgs e)
        {

        }

        private void btnEyeSquareOff_Click(object sender, EventArgs e)
        {

        }

        private void btnPredictFace_Click(object sender, EventArgs e)
        {
            WebCam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, byte>();

            if (imageFrame != null)
            {
                var faces = FaceDetection.DetectMultiScale(imageFrame, 1.3, 5);

                if (faces.Count() != 0)
                {
                    foreach (var fc in faces)
                    {

                        var procImg = imageFrame.Copy(fc).Resize(ProcessImageWidth, ProcessImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                        var result = FaceRecognition.Predict(procImg);

                        if (result.Label.ToString() == "1")
                        {
                            //tbOutput.AppendText($"FACE {result.Label}  {System.Environment.NewLine}");
                            //tbOutput.ScrollToCaret();
                            //imageFrame.Draw("CARL", new Point(faces[0].X, faces[0].Y), 2);
                            //imageFrame.Draw("dd",)

                            //                    }
                        }
                    }

                }
                else
                {
                    //tbOutput.AppendText($"?????  {System.Environment.NewLine}");
                }
            }
            else
            {
                //tbOutput.AppendText($"?????  {System.Environment.NewLine}");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                int len = Faces.Count;
                int index = 0;
                for (int i = 0; i < len; i++)
                {
                    Faces[i].Save(System.IO.Path.GetFullPath($@"../../Faces/{Names[i]}_{Ids[i]}_{index++}.bmp"));
                }
            }
            catch (Exception)
            {
            }


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //Bitmap bitmap2 = (Bitmap)Bitmap.FromFile($@"../../Faces/CARL_1_0.bmp");

            //var r = new Image<Gray, bytes>()
            Faces = new List<Image<Gray, byte>>();

            var f = new Image<Gray, byte>(System.IO.Path.GetFullPath($@"../../Faces/CARL_1_0.bmp"));
            Faces.Add(f);
            f = new Image<Gray, byte>(System.IO.Path.GetFullPath($@"../../Faces/CARL_1_1.bmp"));
            Faces.Add(f);
            f = new Image<Gray, byte>(System.IO.Path.GetFullPath($@"../../Faces/CARL_1_2.bmp"));
            Faces.Add(f);


        }

        private void btnFormWebCam_Click(object sender, EventArgs e)
        {
            // open formwebcam
            _qz2018.FormWebCamOpen();
        }





        public void ButtonBackColor()
        {
            btnTRFStart.BackColor = DefaultBackColor;
            btnTFStart.BackColor = DefaultBackColor;
            btnTGStart.BackColor = DefaultBackColor;
            btnQStart.BackColor = DefaultBackColor;


            switch (_qz2018.Mode)
            {

                case EnMode.TRFStart:
                    btnTRFStart.BackColor = Color.LightGreen;
                    break;
                case EnMode.TFStart:
                    btnTFStart.BackColor = Color.LightGreen;
                    break;
                case EnMode.TGStart:
                    btnTGStart.BackColor = Color.LightGreen;
                    break;
                case EnMode.QStart:
                    btnQStart.BackColor = Color.LightGreen;
                    break;
                default:
                    break;
            }
        }

        public void UpdateScore(int grpNbr, int sc, int scTotal)
        {
            try
            {
                string score = (sc / 1000).ToString("N0");
                string scoreTotal = (scTotal / 1000).ToString("N0");

                switch (grpNbr)
                {
                    case 1:
                        Invoke(new Action(() =>
                        {
                            tbQGRP1_T1.Text = score;
                            tbQGRP1_TOT.Text = scoreTotal;
                        }));
                        break;
                    case 2:
                        Invoke(new Action(() =>
                        {
                            tbQGRP2_T1.Text = score;
                            tbQGRP2_TOT.Text = scoreTotal;
                        }));
                        break;
                    case 3:
                        Invoke(new Action(() =>
                        {
                            tbQGRP3_T1.Text = score;
                            tbQGRP3_TOT.Text = scoreTotal;
                        }));
                        break;
                    case 4:
                        Invoke(new Action(() =>
                        {
                            tbQGRP4_T1.Text = score;
                            tbQGRP4_TOT.Text = scoreTotal;
                        }));
                        break;
                    case 5:
                        Invoke(new Action(() =>
                        {
                            tbQGRP5_T1.Text = score;
                            tbQGRP5_TOT.Text = scoreTotal;
                        }));
                        break;
                    case 6:
                        Invoke(new Action(() =>
                        {
                            tbQGRP6_T1.Text = score;
                            tbQGRP6_TOT.Text = scoreTotal;
                        }));
                        break;
                }
            }
            catch (Exception)
            {
            }
        }


        private void btnTRFStart_Click(object sender, EventArgs e)
        {
            try
            {
                // selected ?
                if (cbTRFFaces.SelectedIndex < 0)
                {
                    MessageBox.Show("NO FACE SELECTED");
                    return;
                }

                // train face
                _qz2018.TrainFaceStart((string)cbTRFFaces.SelectedItem);
            }
            catch (Exception)
            {
            }
        }






        private void btnTRFStop_Click(object sender, EventArgs e)
        {
            // mode train - stop
            _qz2018.Mode = EnMode.None;
            ButtonBackColor();

        }
        private void btnTRFReset_Click(object sender, EventArgs e)
        {
            // mode train - stop
            _qz2018.Mode = EnMode.None;

        }
        private void btnTRFSave_Click(object sender, EventArgs e)
        {
            try
            {
                // selected ?
                if (cbTRFFaces.SelectedIndex < 0)
                {
                    MessageBox.Show("NO FACE SELECTED");
                    return;
                }

                // train face
                if (_qz2018.TrainFaceSave() == 0)
                {
                    MessageBox.Show("NO DATA");
                    return;
                }

            }
            catch (Exception)
            {
            }

        }
        private void btnTRFDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure ??",
                      "Delete", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                if (cbTRFFaces.SelectedIndex < 0)
                    MessageBox.Show("NO FACE SELECTED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void btnQStart_Click(object sender, EventArgs e)
        {
            try
            {

                // question selected ?
                if (cbQNbr.SelectedIndex < 0)
                {
                    MessageBox.Show("NO QUESTION SELECTED");
                    return;
                }

                // question selected ?
                if (cbQGrp.SelectedIndex < 0)
                {
                    MessageBox.Show("NO GROUP SELECTED");
                    return;
                }

                // start question
                _qz2018.QuestionStart((string)cbQNbr.SelectedItem, (string)cbQGrp.SelectedItem);

                cbQA1.Checked = _qz2018.TQuestion.QForceAnswerNbr[1];
                cbQA2.Checked = _qz2018.TQuestion.QForceAnswerNbr[2];
                cbQA3.Checked = _qz2018.TQuestion.QForceAnswerNbr[3];

            }
            catch (Exception ex)
            {
            }

        }

        private void btnQStop_Click(object sender, EventArgs e)
        {
            // mode question - start
            _qz2018.Mode = EnMode.None;
            ButtonBackColor();

        }




        private void btnTGStart_Click(object sender, EventArgs e)
        {
            // selected ?
            if (cbTGGroups.SelectedIndex < 0)
            {
                MessageBox.Show("NO GROUP SELECTED");
                return;
            }

            // test group
            _qz2018.TestGroupStart((string)cbTGGroups.SelectedItem);
        }

        private void btnTGStop_Click(object sender, EventArgs e)
        {
            _qz2018.Mode = EnMode.None;
            ButtonBackColor();
        }

        private void btnTFStart_Click(object sender, EventArgs e)
        {
            // selected ?
            if (cbTFFaces.SelectedIndex < 0)
            {
                MessageBox.Show("NO FACE SELECTED");
                return;
            }

            // train face
            _qz2018.TestFaceStart((string)cbTFFaces.SelectedItem);
        }

        private void btnTFStop_Click(object sender, EventArgs e)
        {
            _qz2018.Mode = EnMode.None;
            ButtonBackColor();
        }

        private void btnFormTrainFaceOpen_Click(object sender, EventArgs e)
        {
            // open formtrainfaces
            _qz2018.FormTrainOpen();

        }

        private void btnQBereken1_Click(object sender, EventArgs e)
        {
            //bereken stand
            _qz2018.BerekenStand();
        }

        private void btnQSET1_Click(object sender, EventArgs e)
        {
            SetScore(1, tbQGRP1_TOT.Text);
        }

        private void SetScore(int index, string score)
        {
            try
            {
                _qz2018.QZGroupArr[index].GTime = 0;
                _qz2018.QZGroupArr[index].GTotalTime = int.Parse(score) * 1000;
                UpdateScore(index, _qz2018.QZGroupArr[index].GTime, _qz2018.QZGroupArr[index].GTotalTime);
            }
            catch (Exception)
            {
            }



        }

        private void btnQSET2_Click(object sender, EventArgs e)
        {
            SetScore(2, tbQGRP2_TOT.Text);

        }

        private void btnQSET3_Click(object sender, EventArgs e)
        {
            SetScore(3, tbQGRP3_TOT.Text);

        }

        private void btnQSET4_Click(object sender, EventArgs e)
        {
            SetScore(4, tbQGRP4_TOT.Text);

        }

        private void btnQSET5_Click(object sender, EventArgs e)
        {
            SetScore(5, tbQGRP5_TOT.Text);

        }

        private void btnQSET6_Click(object sender, EventArgs e)
        {
            SetScore(6, tbQGRP5_TOT.Text);

        }

        private void cbQA1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _qz2018.TQuestion.QForceAnswerNbr[1] = cbQA1.Checked;
            }
            catch (Exception)
            {
            }
        }

        private void cbQA2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _qz2018.TQuestion.QForceAnswerNbr[2] = cbQA2.Checked;
            }
            catch (Exception)
            {
            }
        }

        private void cbQA3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _qz2018.TQuestion.QForceAnswerNbr[3] = cbQA3.Checked;
            }
            catch (Exception)
            {
            }
        }

        private void btnTrain1_Click(object sender, EventArgs e)
        {
            FormTrain1 frm = new FormTrain1();
            frm.FormInit(_qz2018);
            frm.Show();

        }
    }
}
