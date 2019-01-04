using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class QuizSet
    {
        public List<SetFace> Faces { get; set; }
        public List<SetQuestion> Questions { get; set; }
        public List<SetShape> Shapes { get; set; }
    }

    public class SetFace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Group { get; set; }
    }

    public class SetQuestion
    {
        public int Nbr { get; set; }
        public string Text1 { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public int Type { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }


    }

    public class SetShape
    {
        public SetFindShape FindShape { get; set; }
        public SetInRange InRange { get; set; }
        public SetSmooth SmoothGaussian { get; set; }
        public SetCanny Canny { get; set; }
        public SetApproxPolyDP ApproxPolyDP { get; set; }
        public SetContourArea ContourArea { get; set; }
    }


    public class SetFindShape
    {
        public double AreaMin { get; set; }     // minimum size of area
        public int Size { get; set; }   // 3=triangle, 4=rectangle, 5=polygon1, ...
        public double AngleMin { get; set; } // min angle between lines
        public double AngleMax { get; set; } // max angle between lines
    }
    public class SetInRange
    {
        public int Bmin { get; set; }   // blue
        public int Bmax { get; set; }

        public int Gmin { get; set; }   // green
        public int Gmax { get; set; }

        public int Rmin { get; set; }   // red
        public int Rmax { get; set; }

    }
    public class SetSmooth
    {
        public int kernelSize { get; set; }
    }
    public class SetCanny
    {
        public double Threshold1 { get; set; }
        public double Threshold2 { get; set; }

        public int ApertureSize { get; set; }
        public bool L2gradient { get; set; }
    }
    public class SetApproxPolyDP
    {
        public double Epsilon { get; set; }
        public bool Closed { get; set; }

    }

    public class SetContourArea
    {
        public bool Oriented { get; set; }

    }


}
