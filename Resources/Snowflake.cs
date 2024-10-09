using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowFlaCKes___Yup_Again.Resources
{
    internal class Snowflake
    {
        public double X;
        public double Y;
        public int Size;
        public double Speed;
        //public int RotateSpeed;
        //public int CurrentRotate;
        public PictureBox img;
        public Snowflake(double x, double y, int size, double spd, int rotateSpd, Form prnt, Image outimg)
        {
            X = x;
            Y = y;
            Speed = spd;
            //CurrentRotate = 0;
            Size = size;
            img = new PictureBox();
            img.BackgroundImage = outimg;
            img.Parent = prnt;
            img.Width = size;
            img.Height = size;
            img.BackgroundImageLayout = ImageLayout.Stretch;
            img.BackColor = Color.Transparent;
            img.Location = new Point((int)X, (int)Y);
            //RotateSpeed = rotateSpd;
        }

    }
}
