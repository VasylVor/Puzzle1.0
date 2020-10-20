using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleService.BLL
{
    public class WorkWithImage
    {
        /// <summary>
        /// Ріже картинку на прямоугольники
        /// </summary>
        /// <param name="image"></param>
        /// <param name="hRect"></param>
        /// <param name="wRect"></param>
        /// <returns></returns>
        public static Bitmap[,] GetPuzzle(Image image, int hRect, int wRect)
        {
            int width = image.Width / wRect;
            int height = image.Height / hRect;
            Bitmap[,] bmps = new Bitmap[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    bmps[i, j] = new Bitmap(wRect, hRect);
                    Graphics g = Graphics.FromImage(bmps[i, j]);
                    g.DrawImage(image, new Rectangle(0, 0, wRect, hRect), new Rectangle(j * wRect, i * hRect, wRect, hRect), GraphicsUnit.Pixel);
                    g.Dispose();
                }

            return bmps;
        }

        /// <summary>
        /// Змішування пазлів(алгортм Фишера-Йетса)
        /// </summary>
        /// <param name="bitmaps"></param>
        /// <returns></returns>
        public static Bitmap[,] MixPuzzle(Bitmap[,] bitmaps)
        {
            Random rnd = new Random();
            Bitmap[,] clone = bitmaps;
            for (int i = bitmaps.GetLength(0) - 1; i >= 1; i--)
            {
                for (int j = bitmaps.GetLength(1) - 1; j >= 1; j--)
                {
                    int r1 = rnd.Next(0, i + 1);
                    int r2 = rnd.Next(0, j + 1);

                    var temp = bitmaps[r1, r2];
                    bitmaps[r1, r2] = bitmaps[i, j];
                    bitmaps[i, j] = temp;
                }
            }
            //if (clone == bitmaps)
            //    FisherYastes(bitmaps);

            return bitmaps;
        }

        public static Image ConvertImageFromBase64(string bimage)
        {
            var bytes = Convert.FromBase64String(bimage);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }
    }
}
