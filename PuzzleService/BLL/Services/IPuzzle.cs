using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleService.BLL.Services
{
    public interface IPuzzle
    {
        Bitmap[,] GetPuzzle(Image image, int hRect, int wRect);
        Bitmap[,] MixPuzzle(Bitmap[,] bitmaps);
        Image ConvertFromBase64ToImage(string bimage);
    }
}
