using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageEditorWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Graphics g = pictureBox1.DemonstratePropertyItem();
        }

        private static void DemonstratePropertyItem(PaintEventArgs e)
        {

            // Create two images.
            Image image1 = Image.FromFile("c:\\FakePhoto1.jpg");
            Image image2 = Image.FromFile("c:\\FakePhoto2.jpg");

            // Get a PropertyItem from image1.
            PropertyItem propItem = image1.GetPropertyItem(20624);

            // Change the ID of the PropertyItem.
            propItem.Id = 20625;

            // Set the PropertyItem for image2.
            image2.SetPropertyItem(propItem);

            // Draw the image.
            e.Graphics.DrawImage(image2, 20.0F, 20.0F);
        }
    }
}
