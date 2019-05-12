using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            progress_ = new Progress<int>(v =>
            {
                // This lambda is executed in context of UI thread,
                // so it can safely update form controls
                daugmansProgressBar.Value = v;
                daugmansProgressBarLabel.Text = v + "%";
            });
        }
        private Image cleanCopy_ = null;
        private DaugmanResult lastResult_ = null;
        Progress<int> progress_ = null;
        //Load Image
        private void MenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox.Image = ImageUtils.LoadImage();
            cleanCopy_ = new Bitmap(pictureBox.Image);
        }
        private DaugmanResult FindIris(IProgress<int> progress)
        {
            
            Bitmap copy = new Bitmap(cleanCopy_);
            copy = ImageUtils.FilterProcessImage(double.Parse(standardDevTextBox.Text, CultureInfo.InvariantCulture), copy);
            
            return Daugman.FindIris(copy,
                                    int.Parse(minRadiusTextBox.Text, CultureInfo.InvariantCulture),
                                    int.Parse(maxRadiusTextBox.Text, CultureInfo.InvariantCulture),
                                    double.Parse(angleStepTextBox.Text, CultureInfo.InvariantCulture),
                                    double.Parse(xCutoffTextBox.Text, CultureInfo.InvariantCulture),
                                    double.Parse(yCutoffTextBox.Text, CultureInfo.InvariantCulture),
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
                lastResult_ = await Task.Run(() => FindIris(progress));
                DrawLine(lastResult_.startX, 0, lastResult_.startX, pictureBox.Image.Height - 1);
                DrawLine(lastResult_.endX, 0, lastResult_.endX, pictureBox.Image.Height - 1);
                DrawLine(0, lastResult_.startY, pictureBox.Image.Width - 1, lastResult_.startY);
                DrawLine(0, lastResult_.endY, pictureBox.Image.Width - 1, lastResult_.endY);
                DrawCircle(lastResult_.X, lastResult_.Y, lastResult_.R);
                GetBinaryVectorFromIris();
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
            Bitmap result = await Task.Run(() => ImageUtils.FilterProcessImage(double.Parse(standardDevTextBox.Text, CultureInfo.InvariantCulture), new Bitmap(pictureBox.Image)));
            pictureBox.Image = result;
        }

        private async void GetBinaryVectorFromIris()
        {
            if(cleanCopy_ != null && lastResult_ != null)
            {             
                string result = await Task.Run(() => Daugman.GetBinaryStringFromIris(new Bitmap(cleanCopy_), lastResult_));
            }
        }
    }
}
