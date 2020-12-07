using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleService.BLL.Services
{
    public interface IPuzzle
    {
        Bitmap[,] GetPuzzle(Image image, int hRect, int wRect, string name, string type);
        Bitmap[,] MixPuzzle(Bitmap[,] bitmaps);
        Image ConvertFromBase64ToImage(string bimage, string name,out string imgType);
        string ConvertFromImageToBase64(Image bitMap);

        bool CheckPuzz(int id, List<string> puzzels);
    }
}
