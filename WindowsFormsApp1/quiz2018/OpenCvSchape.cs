using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class OpenCvShape
    {
        private QuizSet _set;

        public int Bmin { get; set; } = 0;
        public int Bmax { get; set; } = 255;

        public int Gmin { get; set; } = 0;
        public int Gmax { get; set; } = 255;

        public int Rmin { get; set; } = 0;
        public int Rmax { get; set; } = 255;
        public int Smooth { get; set; }
        public double CannyThreshold1 { get; set; }
        public double CannyThreshold2 { get; set; }
        public bool CannyL2Gradient { get; set; }
        public int CannyApertureSize { get; set; }

        public int WaitCycle { get; set; }

        public OpenCvShape(QuizSet set)
        {
            _set = set;

            Bmin = _set.Shapes[0].InRange.Bmin;
            Bmax = _set.Shapes[0].InRange.Bmax;
            Gmin = _set.Shapes[0].InRange.Gmin;
            Gmax = _set.Shapes[0].InRange.Gmax;
            Rmin = _set.Shapes[0].InRange.Rmin;
            Rmax = _set.Shapes[0].InRange.Rmax;

            Smooth = _set.Shapes[0].SmoothGaussian.kernelSize;

            CannyThreshold1 = _set.Shapes[0].Canny.Threshold1;
            CannyThreshold2 = _set.Shapes[0].Canny.Threshold2;
            CannyL2Gradient = _set.Shapes[0].Canny.L2gradient;
            CannyApertureSize = _set.Shapes[0].Canny.ApertureSize;
        }

        public bool CheckShape(Image<Bgr, byte> imageClone, Image<Bgr, byte> imageFrame, int time)
        {
            try
            {

                #region smooth
                var imgSmoothed = imageClone.PyrDown().PyrUp();
                imgSmoothed._SmoothGaussian(Smooth);
                //ibWebCam.Image = imgSmoothed;
                #endregion

                #region Color filter
                var imgColorFiltered = imgSmoothed.InRange(new Bgr(Bmin, Gmin, Rmin), new Bgr(Bmax, Gmax, Rmax));
                imgColorFiltered = imgColorFiltered.PyrDown().PyrUp();
                imgColorFiltered._SmoothGaussian(Smooth); // 3
                #endregion

                #region opening
                // open > erosion and dilate
                Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(5, 5), new Point(-1, -1));
                var opening = imgColorFiltered.MorphologyEx(MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(1.0));
                //ibWebCam.Image = opening;

                #endregion

                #region objects
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(opening /*cannyEdges*/, contours, null, RetrType.External, ChainApproxMethod.ChainApproxTc89L1);
                CvInvoke.DrawContours(imageFrame, contours, -1, new MCvScalar(255, 0, 0), 2);


                int count = contours.Size;
                int gevonden = 0;
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                        double area = CvInvoke.ContourArea(approxContour, false);
                        //imageFrame.Draw($"{area}", new Point(contour[i].X * 5, contour[i].Y * 5), Emgu.CV.CvEnum.FontFace.HersheyTriplex, 2.0, new Bgr(Color.Wheat));

                        if (area > 1000)
                        {
                            imageFrame.Draw($"{time}",  new Point(contour[i].X * 5, contour[i].Y * 5), Emgu.CV.CvEnum.FontFace.HersheyTriplex, 2.0, new Bgr(Color.Wheat));
                            gevonden++;
                        }
                    }
                }


//                foreach (var p1 in contours.ToArrayOfArray())
//                {
//                    imageFrame.Draw($"{time}", new Point(p1[0].X * 5, p1[0].Y * 5), Emgu.CV.CvEnum.FontFace.HersheyTriplex, 2.0, new Bgr(Color.Wheat));

//                    foreach (var p2 in p1)
//                    {
//                        imageFrame.Draw(new Cross2DF(new PointF(p2.X * 5, p2.Y * 5), 8, 8), new Bgr(Color.Red), 4);
//                    }

//                }
                //CvInvoke.DrawContours(imageFrame, contours, -1, new MCvScalar(255, 0, 0), 2);
                //imageFrame.Draw($"{contours.Size}", new Point(50, 50), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.8, new Bgr(Color.Red));
                #endregion

                if (gevonden > 0)
                    return true;

                return false;
            }
            catch (Exception)
            {

            }

            return false;
        }


    }
}
