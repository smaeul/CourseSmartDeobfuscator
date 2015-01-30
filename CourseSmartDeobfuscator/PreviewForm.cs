using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourseSmartDeobfuscator
{
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();

            //imageFile = "";

            imageFile = "C:\\Users\\Samuel\\Downloads\\Textbook\\RawHex\\0A367814BCB3B119CFA3DA2290A2942D8FA12902D28608968C701F998B4B73.jpg";
            previewBox.Image = new Bitmap(imageFile);
            fixedPictureBox.Image = mapImage();
        }

        private string imageFile;
        private Point[] map;

        private Bitmap mapImage()
        {
            var originalBitmap = new Bitmap(imageFile);
            var newBitmap = new Bitmap(738, 972);
            var graphic = Graphics.FromImage(newBitmap);
            int x, y;

            x = 48;
            y = 640;

            for (var i = 0; i < 6; i++)
            {
                var destRect = new Rectangle(x - 32, y - 640, 96, 16);
                graphic.DrawImage(originalBitmap, destRect, x, y, 96, 16, GraphicsUnit.Pixel);
                Graphics.FromImage(previewBox.Image).FillRectangle(Brushes.Teal, x, y, 96, 16);
                x += 16; y += 16;
            }
            
            x = 368;
            y = 320;

            for (var i = 0; i < 6; i++)
            {
                var destRect = new Rectangle(x - 256, y-320, 192, 16);
                graphic.DrawImage(originalBitmap, destRect, x, y, 192, 16, GraphicsUnit.Pixel);
                Graphics.FromImage(previewBox.Image).FillRectangle(Brushes.Teal, x, y, 192, 16);
                x += 16; y += 16;
            }

            /* ROW TWO */
            
            x = 128;
            y = 416;

            for (var i = 0; i < 6; i++)
            {
                var destRect = new Rectangle(x - 128, y - 320, 112, 16);
                graphic.DrawImage(originalBitmap, destRect, x, y, 112, 16, GraphicsUnit.Pixel);
                Graphics.FromImage(previewBox.Image).FillRectangle(Brushes.Teal, x, y, 112, 16);
                x += 16; y += 16;
            }
            
            x = 464;
            y = 96;

            for (var i = 0; i < 13; i++)
            {
                var destRect = new Rectangle(x - 352, y, 96, 16);
                graphic.DrawImage(originalBitmap, destRect, x, y, 96, 16, GraphicsUnit.Pixel);
                Graphics.FromImage(previewBox.Image).FillRectangle(Brushes.Teal, x, y, 96, 16);
                x += 16; y += 16;
            }

            x = 656;
            y = 96;

            for (var i = 0; i < 13; i++)
            {
                var destRect = new Rectangle(x - 448, y, 96, 16);
                graphic.DrawImage(originalBitmap, destRect, x, y, 96, 16, GraphicsUnit.Pixel);
                Graphics.FromImage(previewBox.Image).FillRectangle(Brushes.Teal, x, y, 96, 16);
                x += 16; y += 16;
            }

            x = -80;
            y = 416;

            for (var i = 0; i < 3; i++)
            {
                var destRect = new Rectangle(x + 288, y - 320, 96, 16);
                graphic.DrawImage(originalBitmap, destRect, x, y, 96, 16, GraphicsUnit.Pixel);
                Graphics.FromImage(previewBox.Image).FillRectangle(Brushes.Teal, x, y, 96, 16);
                x += 16; y += 16;
            }

            x = 432;
            y = 416;

            for (var i = 0; i < 14; i++)
            {
                var destRect = new Rectangle(x - 128, y - 320, 128, 16);
                graphic.DrawImage(originalBitmap, destRect, x, y, 128, 16, GraphicsUnit.Pixel);
                Graphics.FromImage(previewBox.Image).FillRectangle(Brushes.Teal, x, y, 128, 16);
                x += 16; y += 16;
            }

            return newBitmap;
        }

        private void openImage(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "JPEG Images|*.jpg";
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                imageFile = dialog.FileName;
                previewBox.Image = new Bitmap(imageFile);
                fixedPictureBox.Image = mapImage();
            }
        }

        private void saveMap(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Text Documents|*.txt";
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                var writer = new System.IO.StreamWriter(dialog.FileName, false, Encoding.UTF8);
                writer.WriteLine("");
                writer.Close();
            }
        }
    }
}
