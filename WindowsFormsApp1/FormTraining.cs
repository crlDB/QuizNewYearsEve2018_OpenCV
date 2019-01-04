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
    public partial class FormTraining : Form
    {
        public FormTraining()
        {
            InitializeComponent();
        }

        private void FormTraining_Load(object sender, EventArgs e)
        {

        }

        private void FormTraining_FormClosing(object sender, FormClosingEventArgs e)
        {


        }


        public void SetPicture(int nbr, Image<Gray, byte> img)
        {
            switch (nbr)
            {
                case 1:
                    imgTrain1.Image = img;
                    break;
                case 2:
                    imgTrain2.Image = img;
                    break;
                case 3:
                    imgTrain3.Image = img;
                    break;
                case 4:
                    imgTrain4.Image = img;
                    break;
                case 5:
                    imgTrain5.Image = img;
                    break;
                case 6:
                    imgTrain6.Image = img;
                    break;
                case 7:
                    imgTrain7.Image = img;
                    break;
                case 8:
                    imgTrain8.Image = img;
                    break;
                case 9:
                    imgTrain9.Image = img;
                    break;
                case 10:
                    imgTrain10.Image = img;
                    break;




            }


        }

    }
}
