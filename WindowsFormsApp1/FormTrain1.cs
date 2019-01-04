using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Util;

namespace WindowsFormsApp1
{
    public partial class FormTrain1 : Form
    {
        private Quiz2018 _qz;

        public int Bmin { get; set; } = 0;
        public int Bmax { get; set; } = 255;

        public int Gmin { get; set; } = 0;
        public int Gmax { get; set; } = 255;

        public int Rmin { get; set; } = 0;
        public int Rmax { get; set; } = 255;

        public Mat CameraFeed { get; set; }
        public Mat HSV { get; set; }
        public Mat Threshold { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public VideoCapture Capture { get; set; }

        public Image<Bgr, byte> TEST1 { get; set; }

        public double GrayCannyTh { get; set; }
        public double GrayCircleTh { get; set; }


        public bool Busy { get; set; } = false;
        public int Smooth { get; private set; }
        public double CannyThreshold1 { get; private set; }
        public double CannyThreshold2 { get; private set; }
        public bool CannyL2Gradient { get; private set; }
        public int CannyApertureSize { get; private set; }

        public FormTrain1()
        {
            InitializeComponent();
        }

        private void FormTrain1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Capture.Stop();
                Capture.Dispose();
                Capture = null;
            }
            catch (Exception)
            {
            }
        }

        public void FormInit(Quiz2018 qz)
        {
            try
            {
                _qz = qz;

                CameraFeed = new Mat();
                HSV = new Mat();

                Bmin = _qz.QSet.Shapes[0].InRange.Bmin;
                Bmax = _qz.QSet.Shapes[0].InRange.Bmax;
                Gmin = _qz.QSet.Shapes[0].InRange.Gmin;
                Gmax = _qz.QSet.Shapes[0].InRange.Gmax;
                Rmin = _qz.QSet.Shapes[0].InRange.Rmin;
                Rmax = _qz.QSet.Shapes[0].InRange.Rmax;

                trackBarHmin.Value = Bmin;
                trackBarHmax.Value = Bmax;
                trackBarSmin.Value = Gmin;
                trackBarSmax.Value = Gmax;
                trackBarVmin.Value = Rmin;
                trackBarVmax.Value = Rmax;

                trackBarGCTH1.Value = 3;
                trackBarGCTH2.Value = 43;

                Smooth = _qz.QSet.Shapes[0].SmoothGaussian.kernelSize;
                trackBarSmooth.Value = Smooth;

                CannyThreshold1 = _qz.QSet.Shapes[0].Canny.Threshold1;
                trackBarCannyThreshold1.Value = (int)CannyThreshold1;
                CannyThreshold2 = _qz.QSet.Shapes[0].Canny.Threshold2;
                trackBarCannyThreshold2.Value = (int)CannyThreshold2;
                CannyL2Gradient = _qz.QSet.Shapes[0].Canny.L2gradient;
                CannyApertureSize = _qz.QSet.Shapes[0].Canny.ApertureSize;
                trackBarCannyApertureSize.Value = CannyApertureSize;


                TEST1 = new Image<Bgr, byte>(System.IO.Path.GetFullPath($@"../../Images/circle.png"));


                //1920 x 1080
                //1600 x 900
                //1366 x 768
                //1280 x 720
                //1024 x 57

                Capture = new VideoCapture(0 + Emgu.CV.CvEnum.CaptureType.DShow);
                Capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FourCC, VideoWriter.Fourcc('M', 'J', 'P', 'G'));
                Capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 300);   //1920.0
                Capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 300);  //1080.0
                Capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Settings, 1);
                //Capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Backlight, 0);
                Capture.ImageGrabbed += Capture_ImageGrabbed;
                Capture.Start();

            }
            catch (Exception)
            {
            }
        }
        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            lock (Capture)
            {
                if (Busy)
                    return;
                Busy = true;
            }

            try
            {

                Capture.Retrieve(CameraFeed);
                var imageFrame = CameraFeed.ToImage<Bgr, byte>();

                #region smooth
                var imgSmoothed = imageFrame.PyrDown().PyrUp();
                imgSmoothed._SmoothGaussian(Smooth);
                imageBox2.Image = imgSmoothed;
                #endregion

                #region Color filter
                var imgColorFiltered = imgSmoothed.InRange(new Bgr(Bmin, Gmin, Rmin), new Bgr(Bmax, Gmax, Rmax));
                imgColorFiltered = imgColorFiltered.PyrDown().PyrUp();
                imgColorFiltered._SmoothGaussian(Smooth); // 3
                imageBox3.Image = imgColorFiltered;
                #endregion


                #region erosion, delete noise
                //var imageErode = imgColorFiltered.Erode(2);
                //imageBox4.Image = imageErode;
                #endregion

                #region
                //var imageDilate = imageErode.Dilate(5);
                //imageBox5.Image = imageDilate;
                #endregion

                #region opening
                // open > erosion and dilate
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
                var opening = imgColorFiltered.MorphologyEx(MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                imageBox4.Image = opening;
                #endregion

                #region closing
                // open > erosion and dilate
                //Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
                //var opening = imgColorFiltered.MorphologyEx(MorphOp.Close, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                //imageBox4.Image = opening;
                #endregion

                #region gradient
                // open > erosion and dilate
                //Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
                //var opening = imgColorFiltered.MorphologyEx(MorphOp.Gradient, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                //imageBox4.Image = opening;
                #endregion



                #region Canny and edge detection
                //UMat cannyEdges = new UMat();
                //CvInvoke.Canny(imageDilate, cannyEdges, CannyThreshold1, CannyThreshold2, CannyApertureSize, CannyL2Gradient);
                //imageBox6.Image = cannyEdges;
                #endregion


                #region objects
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(opening /*cannyEdges*/, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                int count = contours.Size;
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                        double area = CvInvoke.ContourArea(approxContour, false);
                        if (area > 300) 
                        {
                            CvInvoke.DrawContours(imageFrame, contour, -1, new MCvScalar(255, 0, 0), 2);
                            imageFrame.Draw($"{area}", new Point(50, 50), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.8, new Bgr(Color.Red));
                        }
                    }
                }
                #endregion
                imageBox1.Image = imageFrame;




                //var imgSmoothed = imageFrame.PyrDown().PyrUp();
                //imgSmoothed._SmoothGaussian(3);
                //imageBox2.Image = imgSmoothed;

                //var imgColorFiltered = imgSmoothed.InRange(new Bgr(Bmin, Gmin, Rmin), new Bgr(Bmax, Gmax, Rmax));
                //imgColorFiltered = imgColorFiltered.PyrDown().PyrUp();
                //imgColorFiltered._SmoothGaussian(3);
                //imageBox3.Image = imgColorFiltered;

                //Gray grayCannyThreshold = new Gray(GrayCannyTh);
                //Gray grayCircleThreshold = new Gray(GrayCircleTh);
                //Gray grayLinking = new Gray(80);

                //var imgCanny = imgColorFiltered.Canny(grayCannyThreshold.Intensity, grayLinking.Intensity);
                //imgColorFiltered.Canny(1.0, 2.0, 3, false);

                //var imgCircles = imageFrame.CopyBlank();
                //var imgLines = imageFrame.CopyBlank();
                //var imgPoly = imageFrame.CopyBlank();

                //double dblAccumRes = 1.0;
                //double dblMinDist = 1.0;
                //int intMinRadius = 50;
                //int intMaxRadius = 150;

                ////var circles = imgColorFiltered.HoughCircles(grayCannyThreshold, grayCircleThreshold, dblAccumRes, dblMinDist, intMinRadius, intMaxRadius)[0];
                ////foreach (var circ in circles)
                ////{
                ////    imgCircles.Draw(circ, new Bgr(Color.Red), 2);
                ////    imageFrame.Draw(circ, new Bgr(Color.Red), 2);
                ////}
                ////Contour<Point> contours = imgCanny.FindContours();
                ////List<RotatedRect> lstRectangles = new List<RotatedRect>();



                //Double dblRhoRes = 1.0;
                //Double dblThetaRes = 4.0 * (Math.PI / 180.0);
                //int intThreshold = 20;
                //Double dblMinLineWidth = 30.0;
                //Double dblMinGapBetweenLines = 10.0;

                //imgColorFiltered.Ho
                //LineSegment2D[] lines = imgCanny.Clone().HoughLinesBinary(dblRhoRes, dblThetaRes, intThreshold, dblMinLineWidth, dblMinGapBetweenLines)[0];

                //foreach (LineSegment2D line in lines)
                //{
                //    imgLines.Draw(line, new Bgr(Color.DarkGreen), 2);
                //    imageFrame.Draw(line, new Bgr(Color.DarkGreen), 2);
                //}
                //imageBox4.Image = imgLines;


                //VectorOfVectorOfPointF contours = new VectorOfVectorOfPointF();
                //Mat hierarchy = null;
                //CvInvoke.FindContours(imgCanny, contours, hierarchy, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainCode);

                ////Contour<Point> contours = imgCanny.FindContours();
                //List<MCvBox2D> lstRectangles = new List<MCvBox2D>();
                //List<Contour<Point>> lstPoluhons = new List<Contour<Point>>();

                //while (contours != null)
                //{
                //    Contour<Point> contour = contours.ApproxPoly(10.0);

                //    if (contour.Area > 250.0)
                //    {
                //        if (contour.Total == 4)
                //        {
                //            Point[] ptPoints = contour.ToArray();
                //            Boolean blnIsRectangle = true;

                //            LineSegment2D[] ls2dEdges = PointCollection.PolyLine(ptPoints, true);

                //            for (int i = 0; i < ls2dEdges.Length - 1; i++)
                //            {
                //                Double dblAngle = Math.Abs(ls2dEdges[(i + 1) % ls2dEdges.Length].GetExteriorAngleDegree(ls2dEdges[i]));
                //                if (dblAngle < 80.0 || dblAngle > 100.0)
                //                {
                //                    blnIsRectangle = false;
                //                }
                //            }

                //            if (blnIsRectangle)
                //                lstRectangles.Add(contour.GetMinAreaRect());


                //        }
                //    }



                //    contours = contours.HNext;
                //}



                //foreach (MCvBox2D rect in lstRectangles)
                //{
                //    imgTrisRectsPolys.Draw(rect, new Bgr(Color.Blue), 2);
                //    if (chbDrawTrianglesAndPolygansOnOriginalImage.Checked == true)
                //    {
                //        imgOriginal.Draw(rect, new Bgr(Color.Blue), 2);
                //    }
                //}




















                //CvInvoke.CvtColor(CameraFeed, HSV, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);


                //CvInvoke.InRange(HSV, new MCvScalar(Bmin, Gmin, Rmin), new MCvScalar(Bmax, Gmax, Rmax), Threshold);

                //CvInvoke.Mor




                //histogramBoxCapture. = CameraFeed;

                //var imageFrame = Frame.ToImage<Bgr, byte>();
            }
            catch (Exception ex)
            {
            }

            Busy = false;

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Bmin = trackBarHmin.Value;
            tbHmin.Text = Bmin.ToString();
        }

        private void trackBarHmax_ValueChanged(object sender, EventArgs e)
        {
            Bmax = trackBarHmax.Value;
            tbHmax.Text = Bmax.ToString();
        }

        private void trackBarSmin_ValueChanged(object sender, EventArgs e)
        {
            Gmin = trackBarSmin.Value;
            tbSmin.Text = Gmin.ToString();

        }

        private void trackBarSmax_ValueChanged(object sender, EventArgs e)
        {
            Gmax = trackBarSmax.Value;
            tbSmax.Text = Gmax.ToString();

        }

        private void trackBarVmin_ValueChanged(object sender, EventArgs e)
        {
            Rmin = trackBarVmin.Value;
            tbVmin.Text = Rmin.ToString();


        }

        private void trackBarVmax_ValueChanged(object sender, EventArgs e)
        {
            Rmax = trackBarVmax.Value;
            tbVmax.Text = Rmax.ToString();

        }

        private void trackBar1_ValueChanged_1(object sender, EventArgs e)
        {
            GrayCannyTh = trackBarGCTH1.Value;
            tbGcTh1.Text = GrayCannyTh.ToString();



        }

        private void trackBar20_ValueChanged(object sender, EventArgs e)
        {
            GrayCircleTh = trackBarGCTH2.Value;
            tbGcTh2.Text = GrayCircleTh.ToString();
        }

        private void trackBarSmooth_ValueChanged(object sender, EventArgs e)
        {
            Smooth = trackBarSmooth.Value;
            tbSmooth.Text = Smooth.ToString(); ;




        }

        private void trackBarCannyThreshold1_ValueChanged(object sender, EventArgs e)
        {
            CannyThreshold1 = trackBarCannyThreshold1.Value;
            tbCannyThreshold1.Text = CannyThreshold1.ToString(); ;

        }

        private void trackBarCannyThreshold2_ValueChanged(object sender, EventArgs e)
        {
            CannyThreshold2 = trackBarCannyThreshold2.Value;
            tbCannyThreshold2.Text = CannyThreshold2.ToString(); ;

        }

        private void trackBarCannyApertureSize_ValueChanged(object sender, EventArgs e)
        {
            CannyApertureSize = trackBarCannyApertureSize.Value;
            tbCannyApertureSize.Text = CannyApertureSize.ToString(); ;

        }

    }
}
