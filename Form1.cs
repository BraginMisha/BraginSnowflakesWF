using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnowFlaCKes___Yup_Again.Resources;

namespace SnowFlaCKes___Yup_Again
{
    public partial class Form1 : Form
    {
        List<Snowflake> snowflakes = new List<Snowflake>();
        Random random = new Random();
        Image outimg;
        public Form1()
        {
            InitializeComponent();
            TransparencyKey = Color.Transparent;
            AllowTransparency = true;
            outimg = Properties.Resources.snowflake;
            for (int count = 20; count > 0; count--)
            {
                snowflakes.Add(new Snowflake(random.Next(0, (int)Width + 10), //x-pos
                    random.Next(0, (int)Height + 10), //y-pos
                    random.Next(5, 11) * 2, //size
                    random.Next(200, 400) / 100d, //speed of snowflake
                    random.Next(1, 5), //rotateSpeed - можно дельнуть
                    this, outimg));
            }
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Snowflake sf in snowflakes)
            {
                //sf.CurrentRotate += sf.RotateSpeed;
                //if (sf.CurrentRotate > 360) sf.CurrentRotate -= 360;
                //RotateImage(sf.img.BackgroundImage, sf.CurrentRotate);
                sf.X -= sf.Speed / 1.4;
                sf.Y += sf.Speed / 1.4;
                sf.img.Location = new Point((int)sf.X, (int)sf.Y);
                if (sf.X < -sf.Size - 5 || sf.Y > Height + 5)
                {
                    int buf = random.Next(0, (int)Width + (int)Height);
                    if (buf <= Width)
                    {
                        sf.X = buf;
                        sf.Y = -(sf.Size + 5);
                    }
                    else
                    {
                        sf.X = (int)Width - sf.Size;
                        sf.Y = buf - (int)Width;
                    }
                }
            }
        }
        /*
        public static void RotateImage(Image img, float rotationAngle)
        {
            Graphics gfx = Graphics.FromImage(img);
            gfx.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.Clear(Color.Transparent);
            gfx.DrawImage(Properties.Resources.snowflake, new Point(0, 0));
            gfx.Dispose();
        }*/

    }
}
