using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzleService.BLL;
using PuzzleService.BLL.Services;
using PuzzleService.DAL;
using PuzzleService.Models;
using PuzzleService.ProxyClasses;

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
        public ActionResult<PuzzleResp> CreatePuzzle([FromBody] PuzzleReq request)//
        {
            //Image img = Image.FromFile(@"D:\My projects\Puzzle\PuzzleWF\Image\brain.jpg"); ;// берем картинку или Image.FromFile("D:\\123.png");
            try
            {
                string imgType;

                System.Drawing.Image img = puzzle.ConvertFromBase64ToImage(request.BImage, request.NameImage,out imgType); // concert image
                Bitmap[,] bmp = puzzle.GetPuzzle(img, 100, 100, request.NameImage, imgType);//cut imagepuzzle.GetPuzzle(img, request.WidthRect, request.HeightRect); //
                //List<string> lstImage = new List<string>();
                //for (int i = 0; i < bmp.GetLength(0); i++)
                //{
                //    for (int j = 0; j < bmp.GetLength(1); j++)
                //    {
                //        string imgPuz = puzzle.ConvertFromImageToBase64(bmp[i, j]);
                //        lstImage.Add(imgType + imgPuz);
                //    }
                //}

              //  rp.SavePuzzle(idImage, bmp, imgType);

                Bitmap[,] rndBmp = puzzle.MixPuzzle(bmp); //mix images
                List<string> lstImage = new List<string>();

                for (int i = 0; i < rndBmp.GetLength(0); i++)
                {
                    for (int j = 0; j < rndBmp.GetLength(1); j++)
                    {
                        string imgPuz = puzzle.ConvertFromImageToBase64(rndBmp[i, j]);
                        lstImage.Add(imgType + imgPuz);
                    }
                }

                PuzzleResp resp = new PuzzleResp() { Id = 1, ImageLst = lstImage, Name = request.NameImage, Column = bmp.GetLength(0), Row = bmp.GetLength(1) };
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return this.StatusCode((int)HttpStatusCode.Conflict);
            }

        }

        [HttpPost]
        public ActionResult<CheckPuzzResp> CheckPuzzle([FromBody] CheckPuzzReq req)
        {
            try
            {
                CheckPuzzResp resp = new CheckPuzzResp()
                {
                    CheckValue = puzzle.CheckPuzz(req.Id, req.Puzzle)
                };

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return this.StatusCode((int)HttpStatusCode.Conflict);
            }
        }
    }
}