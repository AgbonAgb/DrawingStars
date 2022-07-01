using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
namespace DrawingStars
{
    public class Program
    {
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow", SetLastError = true)]
        private static extern IntPtr GetConsoleHandle();

        static void Main(string[] args)
        {

            // Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Please, enter number of votes");
            Console.WriteLine("");
            //Console.BackgroundColor = ConsoleColor.Yellow;// Color.Yellow;// ("Please, enter number of votes");
            int vote = int.Parse(Console.ReadLine());

            string img = MyPainting(vote);

            Console.Read();
        }

        public static string MyPainting(int vote)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Total Vote is " + vote.ToString());


            StringBuilder sb = new StringBuilder();
            float pp = 170f;
            for (int k = 1; k < 6; k++)
            {
                var handler = GetConsoleHandle();
                Graphics G = Graphics.FromHwnd(handler);// e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;
                //init 5 stars
                //PointF[] Star1 = Calculate5StarPoints(new PointF(pp, 100f), 50f, 20f);
                PointF[] Star = CalculateStarPoints(new PointF(pp, 170f), 60f, 30f);

                SolidBrush FillBrush = null;

                if (vote >= 0 && vote <= 20)
                {
                    if (k == 1)
                    {
                        FillBrush = new SolidBrush(Color.Yellow);
                    }
                    else
                    {
                        FillBrush = new SolidBrush(Color.White);
                    }


                }


                if (vote > 20 && vote <= 40)
                {
                    if (k <= 2)
                    {
                        FillBrush = new SolidBrush(Color.Yellow);
                    }
                    else
                    {
                        FillBrush = new SolidBrush(Color.White);
                    }
                }

                if (vote > 40 && vote <= 60)
                {
                    if (k <= 3)
                    {
                        FillBrush = new SolidBrush(Color.Yellow);
                    }
                    else
                    {
                        FillBrush = new SolidBrush(Color.White);
                    }

                }

                if (vote > 60 && vote <= 80)
                {
                    if (k <= 4)
                    {
                        FillBrush = new SolidBrush(Color.Yellow);
                    }
                    else
                    {
                        FillBrush = new SolidBrush(Color.White);
                    }
                }

                if (vote > 80 && vote <= 100)
                {

                    FillBrush = new SolidBrush(Color.Yellow);

                }


                //SolidBrush FillBrush = new SolidBrush(Color.Black);
                G.FillPolygon(FillBrush, Star);
                pp = pp + 100;

                sb.Append(G);
            }


            return sb.ToString();
        }

        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="Orig"> The origin is the middle of the star.</param>
        /// <param name="outerradius">Radius of the surrounding circle.</param>
        /// <param name="innerradius">Radius of the circle for the "inner" points</param>
        /// <returns>Array of 10 PointF structures</returns>
        private static PointF[] CalculateStarPoints(PointF Orig, float outerradius, float innerradius)
        {


            // conversions to radians
            double Ang36 = Math.PI / 5.0;   // 36Â° x PI/180
            double Ang72 = 2.0 * Ang36;     // 72Â° x PI/180
            // some sine and cosine values we need
            float Sin36 = (float)Math.Sin(Ang36);
            float Sin72 = (float)Math.Sin(Ang72);
            float Cos36 = (float)Math.Cos(Ang36);
            float Cos72 = (float)Math.Cos(Ang72);
            // Fill array with 10 origin points
            PointF[] pnts = { Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig };
            pnts[0].Y -= outerradius;  // top off the star, or on a clock this is 12:00 or 0:00 hours
            pnts[1].X += innerradius * Sin36; pnts[1].Y -= innerradius * Cos36; // 0:06 hours
            pnts[2].X += outerradius * Sin72; pnts[2].Y -= outerradius * Cos72; // 0:12 hours
            pnts[3].X += innerradius * Sin72; pnts[3].Y += innerradius * Cos72; // 0:18
            pnts[4].X += outerradius * Sin36; pnts[4].Y += outerradius * Cos36; // 0:24 
            // Phew! Glad I got that trig working.
            pnts[5].Y += innerradius;
            // I use the symmetry of the star figure here
            pnts[6].X += pnts[6].X - pnts[4].X; pnts[6].Y = pnts[4].Y;  // mirror point
            pnts[7].X += pnts[7].X - pnts[3].X; pnts[7].Y = pnts[3].Y;  // mirror point
            pnts[8].X += pnts[8].X - pnts[2].X; pnts[8].Y = pnts[2].Y;  // mirror point
            pnts[9].X += pnts[9].X - pnts[1].X; pnts[9].Y = pnts[1].Y;  // mirror point
            return pnts;
        }
    }
}
