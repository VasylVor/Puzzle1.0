﻿using PuzzleService.BLL.Services;
using PuzzleService.DAL;
using PuzzleService.Models;
using PuzzleService.ProxyClasses;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleService.BLL
{
    public class Puzzle : IPuzzle
    {
        public PuzzleRepository Repository { get { return new PuzzleRepository(new PuzzleDBContext()); } }
        /// <summary>
        /// Ріже картинку на прямоугольники
        /// </summary>
        /// <param name="image"></param>
        /// <param name="hRect"></param>
        /// <param name="wRect"></param>
        /// <returns></returns>
        public  Bitmap[,] GetPuzzle(System.Drawing.Image image, int hRect, int wRect, string name, string type)
        {
            int width = image.Width / wRect;
            int height = image.Height / hRect;
            Bitmap[,] bmps = new Bitmap[height, width];
            //PuzzleRepository rp = new PuzzleRepository(new PuzzleDBContext());
           
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    bmps[i, j] = new Bitmap(wRect, hRect);
                    Graphics g = Graphics.FromImage(bmps[i, j]);
                    g.DrawImage(image, new Rectangle(0, 0, wRect, hRect), new Rectangle(j * wRect, i * hRect, wRect, hRect), GraphicsUnit.Pixel);
                    g.Dispose();
                    Repository.SaveImage(name,type + ConvertFromImageToBase64(bmps[i, j]));
                }

            return bmps;
        }

        /// <summary>
        /// Змішування пазлів(алгортм Фишера-Йетса)
        /// </summary>
        /// <param name="bitmaps"></param>
        /// <returns></returns>
        public  Bitmap[,] MixPuzzle(Bitmap[,] bitmaps)
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

        public System.Drawing.Image ConvertFromBase64ToImage(string bimage,string name, out string imgType)
        {
          //  PuzzleRepository rp = new PuzzleRepository(new PuzzleDBContext());
            int idImage = Repository.SaveImage(name, bimage); // save image


            int index = bimage.IndexOf(',') + 1;
            int a = bimage.Length - 1;

            imgType = bimage.Remove(index, bimage.Length - index);

            var bytes = Convert.FromBase64String(bimage.Remove(0, index));

            System.Drawing.Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = System.Drawing.Image.FromStream(ms);
            }

            return image;
        }

        public string ConvertFromImageToBase64(System.Drawing.Image bitMap)
        {
            MemoryStream ms = new MemoryStream();
            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
           
            string img = Convert.ToBase64String(byteImage);
            return img;
        }

        public bool CheckPuzz(int id, List<string> puzzels)
        {
          //  PuzzleRepository rp = new PuzzleRepository(new PuzzleDBContext());
            List<string> truePuzzle = Repository.GetPuzzle(id);

            for (int i = 0; i < puzzels.Count(); i++)
            {
                if (puzzels[i] != truePuzzle[i])
                {
                    return false;
                }
            }

            return true;
        }

        public List<Img> GetImgLst()
        {
            return Repository.GetImgLst();
        }

        public Img GetImgById(int id)
        {
            return Repository.GetImgById(id);
        }
    }
}
