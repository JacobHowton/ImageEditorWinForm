using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditorWinForm
{
    public partial class Form1 : Form
    {

        public Bitmap img;
        private bool mouseIsDown;
        public int drawWidth;
        public Color colorDraw;

        public enum DrawMode {pen, square};
        public DrawMode drawMode;

        public struct pt
        {
            public int x;
            public int y;
        };

        public pt pt1;
        public pt pt2;


        public Form1()
        {
            InitializeComponent();

            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            drawWidth = trackBar1.Value;
            colorDraw = Color.White;
            drawMode = DrawMode.square;

            pictureBox1.Image = img;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown && 0 + drawWidth / 2 < e.X && e.X < img.Width - drawWidth / 2 && 0 + drawWidth / 2 < e.Y && e.Y < img.Height - drawWidth / 2)
            {
                if (drawMode == DrawMode.pen)
                {
                    draw(e.X, e.Y, drawWidth);
                }

                pictureBox1.Image = img;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawMode == DrawMode.square)
            {
                pt1.x = e.X;
                pt1.y = e.Y;
            }

            mouseIsDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawMode == DrawMode.square)
            {
                pt2.x = e.X;
                pt2.y = e.Y;

                drawSquare(drawWidth);

                pictureBox1.Image = img;
            }
            mouseIsDown = false;
        }

        private void draw(int x, int y, int drawWidth)
        {
            for (int width = 0; width < drawWidth; width ++)
            {
                for (int height = 0; height < drawWidth; height ++)
                {
                    int imgx = x - drawWidth / 2 + width;
                    int imgy = y - drawWidth / 2 + height;

                    if (img.GetPixel(imgx,imgy) != colorDraw)
                        img.SetPixel(imgx, imgy, colorDraw);
                }
            }
            
        }


        private void drawSquare(int drawWidth)
        {
            int x1 = Math.Min(pt1.x, pt2.x);
            int x2 = Math.Max(pt1.x, pt2.x);
            int y1 = Math.Min(pt1.y, pt2.y);
            int y2 = Math.Max(pt1.y, pt2.y);

            for (int x = x1; x < x2; x ++)
            {
                draw(x, y1, drawWidth);
            }

            for (int x = x1; x < x2; x++)
            {
                draw(x, y2, drawWidth);
            }

            for (int y = y1; y < y2; y++)
            {
                draw(x1, y, drawWidth);
            }

            for (int y = y1; y < y2; y++)
            {
                draw(x2, y, drawWidth);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            drawWidth = trackBar1.Value;
        }

        private void pbColorWheel_MouseClick(object sender, MouseEventArgs e)
        {
            int x = pbColorWheel.Image.Width * e.X / pbColorWheel.Width;
            int y = pbColorWheel.Image.Height * e.Y / pbColorWheel.Height;

            colorDraw = ((Bitmap)pbColorWheel.Image).GetPixel(x, y);
        }
    }
}
