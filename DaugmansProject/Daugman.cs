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
        public static DaugmanResult FindIris(Bitmap bmp, int minR, int maxR, double angleStep, double xCutoff, double yCutoff, IProgress<int> progress)
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
            int avgIntensity = (int)ImageUtils.GetAveragePixelIntensity(allPixels);
            // Iris detection
            double maxIntensityDifference = 0.0, currentIntensity = 0.0, prevIntensity = 0.0;
            int retX = 0, retY = 0, retR = 0;
            long totalPixelCount = (endX - startX + 1) * (endY - startY + 1);
            long progressCount = 0;
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
                        if (!circleInRegion)
                        {
                            break;
                        }
                        currentIntensity = ImageUtils.GetAveragePixelIntensity(currentCirclePixels);
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
                    if (progress != null)
                    {
                        progress.Report((int)((++progressCount / (double)totalPixelCount) * 100));
                    }
                }
            }

            return new DaugmanResult { X = retX, Y = retY, R = retR, startX = startX, endX = endX, startY = startY, endY = endY };
        }
        private static List<List<int>> UnravelImage(Bitmap bm, DaugmanResult dr)
        {
            List<List<int>> pixelValues = new List<List<int>>();
            for (double alpha = 0.0; alpha < Math.PI * 2; alpha += 0.01)
            {
                pixelValues.Add(new List<int>());
                int currIdx = pixelValues.Count - 1;
                for (int r = 1; r <= dr.R; r += 1)
                {
                    int x = (int)(r * Math.Cos(alpha)) + dr.X;
                    int y = (int)(r * Math.Sin(alpha)) + dr.Y;

                    pixelValues[currIdx].Add(ImageUtils.ToGrayscaleInt(bm.GetPixel(x, y)));
                }
            }
            
            return pixelValues;
        }
        public static string GetBinaryStringFromIris(Bitmap bm, DaugmanResult dr)
        {
            string ret = "";
            List<double> blocks = new List<double>();
            List<List<int>> pixelValues = UnravelImage(bm, dr);
            const int BLOCK_SIZE = 8;
            //int NUM_BLOCKS_X = bm.Width / BLOCK_SIZE;
            //int NUM_BLOCKS_Y = bm.Height / BLOCK_SIZE;
            int blockStartX = 0, blockStartY = 0;
            int blockEndX = BLOCK_SIZE, blockEndY = BLOCK_SIZE;
            List<double> prevValues = new List<double>();

            while (blockEndX < pixelValues.Count && blockEndY < pixelValues[0].Count)
            {
                List<double> values = new List<double>();
                for (int x = blockStartX; x < blockEndX; ++x)
                {
                    for (int y = blockStartY; y < blockEndY; ++y)
                    {
                        values.Add(DaugmanOperator(pixelValues, x, y));
                    }
                }
                blockStartX += BLOCK_SIZE;
                blockEndX += BLOCK_SIZE;
                blockStartY += BLOCK_SIZE;
                blockEndY += BLOCK_SIZE;
                if(prevValues.Count > 0)
                {
                    double prevMean = prevValues.Mean();
                    double prevStd = prevValues.StandardDeviation();
                    double currMean = values.Mean();
                    double currStd = values.StandardDeviation();
                    if(prevMean < currMean)
                    {
                        ret += "1";
                    }
                    else
                    {
                        ret += "0";
                    }
                    if (prevStd < currStd)
                    {
                        ret += "1";
                    }
                    else
                    {
                        ret += "0";
                    }                  
                }

                prevValues = values;
            }            
            
            return ret;
        }

        public static int DaugmanOperator(List<List<int>> pixelValues, int x, int y)
        {
            int ret = 0;
            // 3x3 block
            int pow = 0;
            for(int i = -1; i < 2; ++i)
            {
                for (int j = -1; j < 2; ++j)
                {
                    int xIdx = x + i;
                    int yIdx = y + j;
                    if(xIdx != x && yIdx != y)
                    {
                        if (xIdx > 0 && xIdx < pixelValues.Count && yIdx > 0 && yIdx < pixelValues[xIdx].Count
                        && pixelValues[xIdx][yIdx] > pixelValues[x][y])
                        {
                            ret += (int)Math.Pow(2, pow);
                        }
                        // Else 0
                        ++pow;
                    }                 
                }
            }        
            return ret;
        }
        
    }
}
