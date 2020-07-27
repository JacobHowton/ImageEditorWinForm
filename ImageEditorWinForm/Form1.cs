using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
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

        public enum DrawMode { pen, square, circle, fill };
        public DrawMode drawMode;

        public struct pt
        {
            public int x;
            public int y;

            public pt(int xnew, int ynew)
            {
                this.x = xnew;
                this.y = ynew;
            }
        };

        public pt pt1;
        public pt pt2;


        public Form1()
        {
            InitializeComponent();

            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            drawWidth = trackBar1.Value;
            colorDraw = Color.White;
            drawMode = DrawMode.pen;

            using (Graphics gfx = Graphics.FromImage(img))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(200, 200, 200)))
            {
                gfx.FillRectangle(brush, 0, 0, img.Width, img.Height);
            }


            pictureBox1.Image = img;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown && 0 + drawWidth / 2 < e.X && e.X < img.Width - drawWidth / 2 && 0 + drawWidth / 2 < e.Y && e.Y < img.Height - drawWidth / 2)
            {
                if (drawMode == DrawMode.pen)
                {
                    draw(e.X, e.Y);
                }

                pictureBox1.Image = img;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawMode == DrawMode.square || drawMode == DrawMode.circle)
            {
                pt1.x = e.X;
                pt1.y = e.Y;
            }

            else if (drawMode == DrawMode.pen)
            {
                draw(e.X, e.Y);
            }

            pictureBox1.Image = img;

            mouseIsDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawMode == DrawMode.square || drawMode == DrawMode.circle)
            {
                pt2.x = e.X;
                pt2.y = e.Y;

                if (drawMode == DrawMode.square)
                {
                    drawSquare();
                }


                pictureBox1.Image = img;
            }
            mouseIsDown = false;
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawMode == DrawMode.fill)
            {
                fill(e.X, e.Y);
            }
        }

        private void draw(int x, int y)
        {

            unsafe
            {
                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(img.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int width = 0; width < drawWidth; width++)
                {
                    int imgy = y - drawWidth / 2 + width;

                    byte* currentLine = ptrFirstPixel + (imgy * bitmapData.Stride);

                    for (int height = 0; height < drawWidth; height ++)
                    {
                        int imgx = x - drawWidth / 2 + height;
                        currentLine[imgx * bytesPerPixel] = (byte)colorDraw.B;
                        currentLine[imgx * bytesPerPixel + 1] = (byte)colorDraw.G;
                        currentLine[imgx * bytesPerPixel + 2] = (byte)colorDraw.R;
                    }
                }

                img.UnlockBits(bitmapData);
            }

            pictureBox1.Image = img;

        }


        private void drawSquare()
        {
            int x1 = Math.Min(pt1.x, pt2.x);
            int x2 = Math.Max(pt1.x, pt2.x);
            int y1 = Math.Min(pt1.y, pt2.y);
            int y2 = Math.Max(pt1.y, pt2.y);

            for (int x = x1; x <= x2; x += drawWidth)
            {
                draw(x, y1);
            }

            for (int x = x2; x >= x1; x -= drawWidth)
            {
                draw(x, y2);
            }

            for (int y = y2; y >= y1; y -= drawWidth)
            {
                draw(x1, y);
            }

            for (int y = y1; y <= y2; y += drawWidth)
            {
                draw(x2, y);
            }
        }

        private void drawCircle(Bitmap processedBitmap)
        {
            MessageBox.Show("ok");
            unsafe
            {
                BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        // calculate new pixel value
                        currentLine[x] = (byte)0;
                        currentLine[x + 1] = (byte)0;
                        currentLine[x + 2] = (byte)0;
                    }
                }
                processedBitmap.UnlockBits(bitmapData);
                pictureBox1.Image = processedBitmap;
            }
        }

        private void fill(int x, int y)
        {
            Queue<pt> points = new Queue<pt>();

            pt centerPoint;
            centerPoint.x = x;
            centerPoint.y = y;

            if (img.GetPixel(x, y) != colorDraw)
            {
                points.Enqueue(centerPoint);

                Color fillingColor = img.GetPixel(x, y);

                while (points.Count > 0)
                {
                    pt currentPoint = points.Dequeue();

                    img.SetPixel(currentPoint.x, currentPoint.y, colorDraw);

                    if (img.GetPixel(currentPoint.x + 1, currentPoint.y) == fillingColor)
                    {
                        points.Enqueue(new pt(currentPoint.x + 1, currentPoint.y));
                    }

                    if (img.GetPixel(currentPoint.x - 1, currentPoint.y) == fillingColor)
                    {
                        points.Enqueue(new pt(currentPoint.x - 1, currentPoint.y));
                    }

                    if (img.GetPixel(currentPoint.x, currentPoint.y + 1) == fillingColor)
                    {
                        points.Enqueue(new pt(currentPoint.x, currentPoint.y + 1));
                    }

                    if (img.GetPixel(currentPoint.x, currentPoint.y - 1) == fillingColor)
                    {
                        points.Enqueue(new pt(currentPoint.x, currentPoint.y - 1));
                    }

                    pictureBox1.Image = img;

                }

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

        private void btn_pen_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.pen;
        }

        private void btn_square_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.square;
        }

        private void btn_circle_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.circle;
            drawCircle(img);

        }

        private void btn_fill_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.fill;
        }
    }
}