using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaugmansProject
{
    public class ImageUtils
    {
        public static Image loadImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff" +
                            "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image to edit.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return Image.FromFile(dialog.FileName);
                //return createNonIndexedImage(Image.FromFile(dialog.FileName));
            }
            return new Bitmap("");
        }
        //Images like .gif has indexed pixel format which throw an exception, this will convert image to non-indexed
        public static Bitmap createNonIndexedImage(Image src)
        {
            Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                gfx.DrawImage(src, 0, 0);
            }

            return newBmp;
        }
    }
}
