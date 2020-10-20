using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzleService.BLL;
using PuzzleService.Model;

namespace PuzzleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPuzzleController : ControllerBase
    {
        [HttpGet]
        public bool OptamizationImage([FromBody] PuzzleReq request)
        {
            //Image temp = Image.FromFile(@"D:\My projects\Puzzle\PuzzleWF\Image\brain.jpg"); ;// берем картинку или Image.FromFile("D:\\123.png");
            Image img = WorkWithImage.ConvertImageFromBase64(request.BImage);

            //  int count = GetCountRectangulars(temp, 200, 200);

            Bitmap[,] bmp = WorkWithImage.GetPuzzle(img, request.WidthRect, request.HeightRect);//cut image

            // Bitmap[,] rndBmp = GetRandomValue(bmp);
            Bitmap[,] rndBmp = WorkWithImage.MixPuzzle(bmp); //mix images

            return true;
        }
    }
}