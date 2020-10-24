using Microsoft.EntityFrameworkCore;
using PuzzleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleService.DAL
{
    public class PuzzleRepository
    {
        private readonly PuzzleDBContext context;

        public PuzzleRepository(PuzzleDBContext context)
        {
            this.context = context;
        }
        public void SaveImage(string name, string image)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Image.Add(new Image()
                    {
                        Image1 = image,
                        Name = name
                    });
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
