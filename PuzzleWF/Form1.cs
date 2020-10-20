using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Image temp = Image.FromFile(@"D:\My projects\Puzzle\PuzzleWF\Image\brain.jpg"); ;// берем картинку или Image.FromFile("D:\\123.png");

            int count = GetCountRectangulars(temp, 200, 200);

            Bitmap[,] bmp = GetPuzzle(temp, 200, 200);

            // Bitmap[,] rndBmp = GetRandomValue(bmp);
            Bitmap[,] rndBmp = FisherYastes(bmp);

            pictureBox1.Image = rndBmp[0, 0];
            pictureBox2.Image = rndBmp[0, 1];
            pictureBox3.Image = rndBmp[0, 2];
            pictureBox4.Image = rndBmp[1, 0];
            pictureBox5.Image = rndBmp[1, 1];
            pictureBox6.Image = rndBmp[1, 2];


            bool checkImage = CheckImage(bmp, rndBmp);

            MessageBox.Show(checkImage.ToString());

            //Bitmap src = new Bitmap(temp, pictureBox1.Width, pictureBox1.Height);
            //// Задаем нужную область вырезания (отсчет с верхнего левого угла)
            //Rectangle rect = new Rectangle(new Point(0, 0), new Size(pictureBox1.Width / 2, pictureBox1.Height / 2));
            //// передаем в нашу функцию   
            //Bitmap CuttedImage = CutImage(src, rect);
            //// результат изображение передаем на форму 
            //pictureBox1.Image = CuttedImage;
        }

        private bool CheckImage(Bitmap[,] realImage, Bitmap[,] fishImage)
        {
            if (realImage.Length != fishImage.Length)
                return false;

            for (int i = 0; i < realImage.GetLength(0); i++)
            {
                for (int j = 0; j < realImage.GetLength(1); j++)
                {
                    MessageBox.Show(realImage[i, j].Equals(fishImage[i, j]).ToString());
                  //  MessageBox.Show((Image)fishImage[i, j].ToString());
                    if ((Image)realImage[i,j] != (Image)fishImage[i,j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private Bitmap[,] FisherYastes(Bitmap[,] bitmaps)
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

        private Bitmap[,] GetRandomValue(Bitmap[,] bitmaps)
        {
            Random rnd = new Random();
            //int i1 = rnd.Next(0, bitmaps.GetLength(0));
            //int i2 = rnd.Next(0, bitmaps.GetLength(1));
            
          //  int [,]arr = new int[bitmaps.GetLength(0), bitmaps.GetLength(1)];
            Bitmap[,] clone = new Bitmap[bitmaps.GetLength(0), bitmaps.GetLength(1)];

            for (int i = 0; i < bitmaps.GetLength(0); i++)
            {
                for (int j = 0; j < bitmaps.GetLength(1); j++)
                {
                    int r1 = rnd.Next(0, bitmaps.GetLength(0));
                    int r2 = rnd.Next(0, bitmaps.GetLength(1));
                    int[] randArray = new int[] { r1, r2 };
                    if (clone[0,0] == null)
                        clone[i, j] = bitmaps[r1, r2];
                    else
                    {
                        clone[i,j] = CheckRndValue(clone, bitmaps[r1, r2], randArray);
                        //for (int i1 = 0; i1 < bitmaps.GetLength(0); i1++)
                        //{
                        //    for (int j1 = 0; j1 < bitmaps.GetLength(1); j1++)
                        //    {
                        //        if (clone[i1, j1] != bitmaps[r1, r2])
                        //            clone[i1, j1] = bitmaps[r1, r2];
                        //    }
                        //}
                    }
                }

            }

            return clone;
        }

        private Bitmap CheckRndValue(Bitmap[,] imagesArray, Image image, int[] randArray)
        {
            Bitmap cloneImage = null;
            bool flag = false;
            for (int i = 0; i < imagesArray.GetLength(0); i++)
            {
                for (int j = 0; j < imagesArray.GetLength(1); j++)
                {
                    if(imagesArray[i,j] != image)
                    {
                        cloneImage = imagesArray[i, j];
                        //flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }

            if (flag)
            {
                Random rnd = new Random();
                int r1 = rnd.Next(0, imagesArray.GetLength(0));
                int r2 = rnd.Next(0, imagesArray.GetLength(1));
                //randArray = { r1, r2}.To;
                //if (randArray.)
                //{

                //}
                CheckRndValue(imagesArray, imagesArray[r1, r2], randArray);
            }
            else
                return cloneImage;

            return null;
        }

        public Bitmap CutImage(Bitmap src, Rectangle rect)
        {

            Bitmap bmp = new Bitmap(src.Width, src.Height); //создаем битмап

            Graphics g = Graphics.FromImage(bmp);

            g.DrawImage(src, 0, 0, rect, GraphicsUnit.Pixel); //перерисовываем с источника по координатам

            return bmp;
        }

        private int GetCountRectangulars(Image image, int hRect, int wRect)
        {
            int sImage = image.Height * image.Width;
            int sRect = hRect * wRect;
            int countRect = sImage / sRect;
            return countRect;
        }

        private Bitmap[,] GetPuzzle(Image image, int hRect,int wRect)
        {
            int width = image.Width / wRect;
            int height = image.Height / hRect;
            Bitmap[,] bmps = new Bitmap[ height,width];
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
    }
}
