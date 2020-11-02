using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PuzzleService.BLL.Services;
using PuzzleService.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleService.DAL
{
    public class PuzzleRepository
    {
        private readonly PuzzleDBContext context;
        private readonly IPuzzle puz;

        public PuzzleRepository(PuzzleDBContext context, IPuzzle puzzle)
        {
            this.context = context;
            this.puz = puzzle;
        }
        public int SaveImage(string name, string image)
        {
            //using (var transaction = context.Database.BeginTransaction())
            //{
            try
            {
                var paramLst = new List<SqlParameter>()
                {
                    new SqlParameter("@Image", image),
                    new SqlParameter("@Name", name)                    
                };

                var id = new SqlParameter()
                {
                    ParameterName = "@Id",
                    DbType = System.Data.DbType.Int32,
                    Direction = System.Data.ParameterDirection.Output
                };

                paramLst.Add(id);
                context.Database.ExecuteSqlRaw("Exec dbo.SaveImages @Name, @Image, @id out", paramLst.ToArray());
               // context.SaveChanges();

                return Convert.ToInt32(id.Value);
                //transaction.Commit();
            }
            catch (Exception e)
            {
                //transaction.Rollback();
                SaveError(e.Message, e.Source, e.StackTrace, e.InnerException?.ToString());
                return 0;
            }
            //}
        }

        public void SaveError(string message, string methodName,string stackTrace, string innerException)
        {

            context.PuzzleError.Add(new PuzzleError()
            {
                Message = message,
                MethodName = methodName,
                StackTrace = stackTrace,
                InnerExceprion = innerException
            });

            context.SaveChanges();
        }

        public void SavePuzzle(int idImage, Bitmap[,] puzzle, string imgType)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < puzzle.GetLength(0); i++)
                        for (int j = 0; j < puzzle.GetLength(1); j++)
                        {
                            var paramLst = new List<SqlParameter>()
                            {
                                new SqlParameter("@IdImage", idImage),
                                new SqlParameter("@Puzzle", imgType + puz.ConvertFromImageToBase64(puzzle[i,j]))
                            };
                            context.Database.ExecuteSqlRaw("Exec dbo.SavePuzzle @IdImage, @Puzzle ", paramLst.ToArray());
                        }

                    
                    

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    SaveError(e.Message, e.Source, e.StackTrace, e.InnerException?.ToString());
                    transaction.Rollback();
                }
            }
        }
    }
}
