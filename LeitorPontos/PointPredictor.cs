using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LeitorPontos
{
    /// <summary>Class to predict curve points</summary>
    public static class PointPredictor
    {
        /// <summary>Maximum points to preview</summary>
        public static int MaxPreviewPoints = 100;

        /// <summary>Analyze points in relative coordinates to identify
        /// graph color and background color</summary>
        /// <param name="Points">Points to analyze</param>
        /// <param name="PickSize">Pick size in pixels</param>
        /// <param name="pBox">Picturebox holding the graph</param>
        public static Color GetGraphColor(List<PointF> Points, int PickSize, PictureBox pBox)
        {
            //Initializations
            Bitmap BmpGraf = (Bitmap)pBox.Image;
            if (BmpGraf == null) return Color.White;

            float[] relPickSize = new float[2];
            relPickSize[0] = (float)PickSize / (float)pBox.Width;
            relPickSize[1] = (float)PickSize / (float)pBox.Height;

            List<int>[] Histogram = new List<int>[3];
            for (int i = 0; i < 3; i++)
            {
                Histogram[i] = new List<int>();
                for (int j = 0; j < 256; j++) Histogram[i].Add(0);
            }

            double totalPixels = 0;
            foreach (PointF p in Points)
            {
                int x0 = (int)((p.X - relPickSize[0]) * BmpGraf.Width); x0--;
                int xf = (int)((p.X + relPickSize[0]) * BmpGraf.Width); xf++;
                int y0 = (int)((p.Y - relPickSize[1]) * BmpGraf.Height); y0--;
                int yf = (int)((p.Y + relPickSize[1]) * BmpGraf.Height); yf++;
                if (x0 < 0) x0 = 0;
                if (xf >= BmpGraf.Width) xf = BmpGraf.Width - 1;
                if (y0 < 0) y0 = 0;
                if (yf >= BmpGraf.Height) yf = BmpGraf.Height - 1;

                for (int x = x0; x < xf; x++)
                {
                    for (int y = y0; y < yf; y++)
                    {
                        Color pix = BmpGraf.GetPixel(x, y);
                        Histogram[0][pix.R]++;
                        Histogram[1][pix.G]++;
                        Histogram[2][pix.B]++;
                        totalPixels++;
                    }
                }
            }

            //Interpolation
            int Order = 6;
            double[] vals = new double[256];
            LinearAlgebra.Matrix M = new LinearAlgebra.Matrix(256, Order);
            for (int i = 0; i < 256; i++)
            {
                vals[i] = Histogram[0][i];

                double temp = 1;
                for (int j = 0; j < Order; j++)
                {
                    M[i, j] = temp;
                    temp *= i;
                }
            }

            //Assumes white background and calculates graph color
            for (int j = 237; j < 256; j++)
            {
                int min = Histogram[0][j];
                if (Histogram[1][j] < min) min = Histogram[1][j];
                if (Histogram[2][j] < min) min = Histogram[2][j];

                for (int i = 0; i < 3; i++) 
                    Histogram[i][j] -= min;
            }

            //Graph color mean
            float[] GraphColor = new float[3];
            for (int i = 0; i < 3; i++)
            {
                totalPixels = 0;
                for (int j = 0; j < 256; j++)
                {
                    totalPixels += Histogram[i][j];
                    GraphColor[i] += (float)j * (float)Histogram[i][j];
                }
                GraphColor[i] /= (float)totalPixels;
            }

            Color resp = Color.FromArgb((int)GraphColor[0], (int)GraphColor[1], (int)GraphColor[2]);

            return resp;
        }

        /// <summary>Tries to guess next curve points</summary>
        /// <param name="Points">Points to analyze, already in graph</param>
        /// <param name="PickSize">Pick size in pixels</param>
        /// <param name="pBox">Picturebox holding the graph</param>
        public static List<PointF> PreviewNextPoints(List<PointF> Points, int PickSize, PictureBox pBox)
        {
            List<PointF> Predicted = new List<PointF>();

            //Initializations
            Bitmap BmpGraf = (Bitmap)pBox.Image;
            if (BmpGraf == null) return Predicted;

            float[] bmpPickSize = new float[2];
            bmpPickSize[0] = (float)PickSize / (float)pBox.Width * (float)BmpGraf.Width;
            bmpPickSize[1] = (float)PickSize / (float)pBox.Height * (float)BmpGraf.Height;

            Color GraphColor = GetGraphColor(Points, PickSize, pBox);
            //gb.ForeColor = GraphColor;

            for (int x = 0; x < BmpGraf.Width; x += (int)bmpPickSize[0]*2)
            {
                for (int y = 0; y < BmpGraf.Height; y++)
                {
                    if (CalcDiffColor(BmpGraf.GetPixel(x, y), GraphColor) < 40)
                    {
                        PointF PointFound = new PointF();
                        PointFound.X = x / (float)BmpGraf.Width;
                        PointFound.Y = y / (float)BmpGraf.Height;
                        Predicted.Add(PointFound);
                        y = BmpGraf.Height;
                    }
                }
            }

            return Predicted;
        }


        /// <summary>Tries to guess next curve points</summary>
        /// <param name="Points">Points to analyze, already in graph</param>
        /// <param name="PickSize">Pick size in pixels</param>
        /// <param name="pBox">Picturebox holding the graph</param>
        public static List<PointF> OldPreviewNextPoints(List<PointF> Points, int PickSize, PictureBox pBox, GroupBox gb)
        {
            List<PointF> Predicted = new List<PointF>();

            //Initializations
            Bitmap BmpGraf = (Bitmap)pBox.Image;
            if (BmpGraf == null) return Predicted;

            float[] relPickSize = new float[2];
            relPickSize[0] = (float)PickSize / (float)pBox.Width;
            relPickSize[1] = (float)PickSize / (float)pBox.Height;

            Color GraphColor = GetGraphColor(Points, PickSize, pBox);
            //gb.ForeColor = GraphColor;

            bool NewPointFound = true;
            int numPtsPreviewed = 0;
            int Order = 3; int NPts = 4;
            while (NewPointFound && numPtsPreviewed < MaxPreviewPoints)
            {
                NewPointFound = false;

                //Creates estimation matrix
                double[] x = new double[NPts + numPtsPreviewed], y = new double[NPts + numPtsPreviewed];
                LinearAlgebra.Matrix M = new LinearAlgebra.Matrix(NPts + numPtsPreviewed, Order);

                //Estimated points
                for (int i = 0; i < numPtsPreviewed; i++)
                {
                    x[i] = Predicted[numPtsPreviewed - 1 - i].X;
                    y[i] = Predicted[numPtsPreviewed - 1 - i].Y;
                    float val = 1;
                    for (int j = 0; j < Order; j++)
                    {
                        M[i, j] = val;
                        val *= i;
                    }
                }

                //Existing points
                for (int i = 0; i < NPts; i++)
                {
                    x[i + numPtsPreviewed] = Points[Points.Count - 1 - i].X;
                    y[i + numPtsPreviewed] = Points[Points.Count - 1 - i].Y;
                    float val = 1;
                    for (int j = 0; j < Order; j++)
                    {
                        M[i + numPtsPreviewed, j] = val;
                        val *= i + numPtsPreviewed;
                    }
                }

                double[] cy = M.IdentifyParameters(y);
                double[] cx = M.IdentifyParameters(x);

                //Assuming next point is close to Next
                PointF Next = new PointF(PolyVal(cx, -0.15f), PolyVal(cy, -0.15f));

                //Try looking for point
                bool found;
                PointF Correction = LookFor(GraphColor, Next, BmpGraf, relPickSize, out found);
                
                //if (found)
                {
                    Predicted.Add(Correction);
                    numPtsPreviewed++;
                    NewPointFound = true;
                }
            }

            return Predicted;
        }

        /// <summary>Look for pixel with a given color in a given area</summary>
        /// <param name="GraphColor">Graph color</param>
        /// <param name="p">Center point</param>
        /// <param name="BmpGraf">Bitmap data</param>
        /// <param name="relPickSize">Relative pick size</param>
        /// <param name="Found">Found point?</param>
        private static PointF LookFor(Color GraphColor, PointF p, Bitmap BmpGraf, float[] relPickSize, out bool Found)
        {
            PointF PointFound = new PointF();
            Found = false;

            int x0 = (int)((p.X - relPickSize[0]) * BmpGraf.Width); x0--;
            int xf = (int)((p.X + relPickSize[0]) * BmpGraf.Width); xf++;
            int y0 = (int)((p.Y - relPickSize[1]) * BmpGraf.Height); y0--;
            int yf = (int)((p.Y + relPickSize[1]) * BmpGraf.Height); yf++;
            if (x0 < 0) x0 = 0;
            if (xf >= BmpGraf.Width) xf = BmpGraf.Width - 1;
            if (y0 < 0) y0 = 0;
            if (yf >= BmpGraf.Height) yf = BmpGraf.Height - 1;

            for (int x = x0; x < xf; x++)
            {
                for (int y = y0; y < yf; y++)
                {
                    if (CalcDiffColor(BmpGraf.GetPixel(x, y), GraphColor) < 30)
                    {
                        if (!Found || (Found && PointFound.X < x))
                        {
                            PointFound.X = x;
                            PointFound.Y = y;
                            Found = true;
                        }
                    }
                }
            }
            PointFound.X /= (float)BmpGraf.Width;
            PointFound.Y /= (float)BmpGraf.Height;

            return PointFound;
        }

        /// <summary>Color difference. 30 is noticeable</summary>
        /// <param name="a">First color</param>
        /// <param name="b">Second color</param>
        private static float CalcDiffColor(Color a, Color b)
        {
            float dif = 0;
            dif += Math.Abs(a.R - b.R);
            dif += Math.Abs(a.G - b.G);
            dif += Math.Abs(a.B - b.B);
            return dif;
        }

        /// <summary>Evaluates polynomial at point X</summary>
        /// <param name="coefs">Polynomial coefficients</param>
        /// <param name="x">X value</param>
        private static float PolyVal(double[] coefs, float x)
        {
            float resp = (float)coefs[0];
            float val = x;

            int n = coefs.Length;
            for (int i = 1; i < n; i++)
            {
                resp += (float)(val * coefs[i]);
                val *= x;
            }

            return resp;
        }


    }

 
}
