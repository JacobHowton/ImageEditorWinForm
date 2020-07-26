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
        public Form1()
        {
            Console.Write("Draw");
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            this.Cursor = new Cursor(Cursor.Current.Handle);

            int xCoordinate = Cursor.Position.X;
            int yCoordinate = Cursor.Position.Y;

            pictureBox1.Image = pictureBox1.Image;

            ((Bitmap)pictureBox1.Image).SetPixel(10, 10, Color.FromArgb(255, 255, 0));

            Console.Write("Draw");

           /* pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int x, y;
            for (y = 0; y < 200; y++)
            {
                for (x = 0; x < 200; x++)
                {
                    ((Bitmap)pictureBox1.Image).SetPixel(x, y, Color.FromArgb(255, 255, 0));
                }
            }*/
        }
    }
}
