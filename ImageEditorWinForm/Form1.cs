﻿using System;
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

        public Form1()
        {
            InitializeComponent();

            img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            drawWidth = trackBar1.Value;
            colorDraw = Color.White;

            pictureBox1.Image = img;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown && 0 + drawWidth / 2 < e.X && e.X < img.Width - drawWidth / 2 && 0 + drawWidth / 2 < e.Y && e.Y < img.Height - drawWidth / 2)
            {
                draw(e.X, e.Y, drawWidth);
                pictureBox1.Image = img;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
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
