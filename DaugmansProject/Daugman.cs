using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaugmansProject
{
    public class DaugmanResult
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int R { get; set; }

        // Info
        public int startX { get; set; }
        public int endX { get; set; }
        public int startY { get; set; }
        public int endY { get; set; }
    }
    public class Daugman
    {
        public static DaugmanResult FindIris(Bitmap bmp, int minR, int maxR, double angleStep, double xCutoff, double yCutoff)
        {
            const double TWO_PI = 2 * Math.PI;
            int startX = (int)(xCutoff * bmp.Width);
            int endX = bmp.Width - startX;
            int startY = (int)(yCutoff * bmp.Height);
            int endY = bmp.Height - startY;

            // Handle incorrect values
            startX = (startX < 0 || startX >= bmp.Width) ? bmp.Width / 2 : startX;
            startY = (startY < 0 || startY >= bmp.Height) ? bmp.Height / 2 : startY;
            endX = (endX < startX) ? startX : endX;
            endY = (endY < startY) ? startY : endY;
            angleStep = angleStep > TWO_PI ? Math.PI : angleStep;
            maxR = maxR < 1 ? 1 : maxR;
            minR = (minR < 0 || minR > maxR) ? maxR : minR;
            List<Color> allPixels = new List<Color>();
            for (int i = 0; i < bmp.Width - 1; ++i)
            {
                for (int j = 0; j < bmp.Height - 1; ++j)
                {
                    allPixels.Add(bmp.GetPixel(i, j));
                }
            }
            int avgIntensity = (int)GetAveragePixelIntensity(allPixels);
            // Iris detection
            double maxIntensityDifference = 0.0, currentIntensity = 0.0, prevIntensity = 0.0; 
            int retX = 0, retY = 0, retR = 0;
            List<Color> currentCirclePixels = new List<Color>();
            for (int i = startX; i <= endX; ++i)
            {
                for (int j = startY; j <= endY; ++j)
                {
                    bool circleInRegion = true;
                    for (int currentRadius = minR; currentRadius <= maxR; ++currentRadius)
                    {
                        for (double ang = 0.0; ang < TWO_PI; ang += angleStep)
                        {
                            int x = i + (int)(currentRadius * Math.Cos(ang));
                            int y = j + (int)(currentRadius * Math.Sin(ang));
                            // Ignore pixels outside of image
                            /*
                            if(x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
                            {
                                currentCirclePixels.Add(bmp.GetPixel(x, y));
                            }
                            else
                            {
                                currentCirclePixels.Add(Color.FromArgb(255, avgIntensity, avgIntensity, avgIntensity));
                            }
                            */
                            if (x >= startX && x <= endX && y >= startY && y <= endY)
                            {
                                currentCirclePixels.Add(bmp.GetPixel(x, y));
                            }
                            else
                            {
                                circleInRegion = false;
                                break;
                            }

                        }
                        if(!circleInRegion)
                        {
                            break;
                        }
                        currentIntensity = GetAveragePixelIntensity(currentCirclePixels);
                        double intensityDiff = currentRadius > minR ? Math.Abs(currentIntensity - prevIntensity) : 0.0; // We consider differences for the same pixel
                        if (maxIntensityDifference < intensityDiff)
                        {
                            maxIntensityDifference = intensityDiff;
                            retX = i;
                            retY = j;
                            retR = currentRadius;
                        }
                        prevIntensity = currentIntensity;
                        currentCirclePixels.Clear();
                    }
                }
            }

            return new DaugmanResult { X = retX, Y = retY, R = retR, startX = startX, endX = endX, startY = startY, endY = endY };
        }
        private static double GetAveragePixelIntensity(List<Color> pixels)
        {
            double ret = 0.0;
            foreach(Color c in pixels)
            {
                ret += ToGrayscale(c);
            }
            ret /= pixels.Count;
            return ret;
        }

        private static int ToGrayscale(Color c)
        {
            return (int)((c.R * 0.3) + (c.G * 0.59) + (c.B * 0.11));
        }
    }
}
