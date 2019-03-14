using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaugmansProject
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Image cleanCopy_ = null;
        //Load Image
        private void MenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox.Image = ImageUtils.LoadImage();
            cleanCopy_ = new Bitmap(pictureBox.Image);
        }
        private DaugmanResult FindIris(IProgress<int> progress)
        {
            
            Bitmap copy = new Bitmap(cleanCopy_);
            copy = ImageUtils.FilterProcessImage(double.Parse(standardDevTextBox.Text), copy);
            
            return Daugman.FindIris(copy,
                                    int.Parse(minRadiusTextBox.Text),
                                    int.Parse(maxRadiusTextBox.Text),
                                    double.Parse(angleStepTextBox.Text),
                                    double.Parse(xCutoffTextBox.Text),
                                    double.Parse(yCutoffTextBox.Text),
                                    progress);
            
        }
        private async void RunDaugmansButton_Click(object sender, EventArgs e)
        {
            if(pictureBox.Image != null)
            {
                var progress = new Progress<int>(v =>
                {
                    // This lambda is executed in context of UI thread,
                    // so it can safely update form controls
                    daugmansProgressBar.Value = v;
                    daugmansProgressBarLabel.Text = v + "%";
                });
                DaugmanResult result = await Task.Run(() => FindIris(progress));
                DrawLine(result.startX, 0, result.startX, pictureBox.Image.Height - 1);
                DrawLine(result.endX, 0, result.endX, pictureBox.Image.Height - 1);
                DrawLine(0, result.startY, pictureBox.Image.Width - 1, result.startY);
                DrawLine(0, result.endY, pictureBox.Image.Width - 1, result.endY);
                DrawCircle(result.X, result.Y, result.R);
            }
        }

        private void DrawCircle(int x, int y, int r)
        {
            Bitmap bmp = new Bitmap(pictureBox.Image);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Rectangle rect = new Rectangle(x - r, y - r, 2 * r, 2 * r);
                g.DrawEllipse(new Pen(Color.Red, 1), rect);
            }
            pictureBox.Image = bmp;
        }

        private void DrawLine(int x1, int y1, int x2, int y2)
        {
            Bitmap bmp = new Bitmap(pictureBox.Image);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawLine(new Pen(Color.Blue, 1), x1, y1, x2, y2);
            }
            pictureBox.Image = bmp;
        }

        private void CleanImageButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = new Bitmap(cleanCopy_);
        }

        private async void GaussianButton_Click(object sender, EventArgs e)
        {
            Bitmap result = await Task.Run(() => ImageUtils.FilterProcessImage(double.Parse(standardDevTextBox.Text), new Bitmap(pictureBox.Image)));
            pictureBox.Image = result;
        }
    }
}
