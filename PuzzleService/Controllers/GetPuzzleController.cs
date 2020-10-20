using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzleService.BLL;
using PuzzleService.BLL.Services;
using PuzzleService.Model;

namespace PuzzleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPuzzleController : ControllerBase
    {
        private readonly IPuzzle puzzle;
        public GetPuzzleController(IPuzzle puzzle)
        {
            this.puzzle = puzzle;
        }
        [HttpGet]
        public bool CreatePuzzle([FromBody] PuzzleReq request)
        {
            //Image temp = Image.FromFile(@"D:\My projects\Puzzle\PuzzleWF\Image\brain.jpg"); ;// берем картинку или Image.FromFile("D:\\123.png");
            Image img = puzzle.ConvertFromBase64ToImage(request.BImage);
            Bitmap[,] bmp = puzzle.GetPuzzle(img, request.WidthRect, request.HeightRect); //puzzle.GetPuzzle(temp, 100, 100);//cut image
            Bitmap[,] rndBmp = puzzle.MixPuzzle(bmp); //mix images

            return true;
        }
    }
}