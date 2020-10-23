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
        [HttpPost]
        public PuzzleResp CreatePuzzle([FromBody] PuzzleReq request)//
        {
            //Image img = Image.FromFile(@"D:\My projects\Puzzle\PuzzleWF\Image\brain.jpg"); ;// берем картинку или Image.FromFile("D:\\123.png");
            Image img = puzzle.ConvertFromBase64ToImage(request.BImage);
            Bitmap[,] bmp = puzzle.GetPuzzle(img, 100, 100);//cut imagepuzzle.GetPuzzle(img, request.WidthRect, request.HeightRect); //
            Bitmap[,] rndBmp = puzzle.MixPuzzle(bmp); //mix images
            List<string> lstImage = new List<string>();
            
            for (int i = 0; i < rndBmp.GetLength(0) - 1; i++)
                for (int j = 0; j < rndBmp.GetLength(1) - 1; j++)
                    lstImage.Add(rndBmp[i, j].ToString());

            PuzzleResp resp = new PuzzleResp() { Id = 1, ImageLst = lstImage, Name = request.NameImage};
            return resp;
        }
    }
}