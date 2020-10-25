using Microsoft.Data.SqlClient;
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
            //using (var transaction = context.Database.BeginTransaction())
            //{
                try
                {
                throw new Exception();
                var paramLst = new List<SqlParameter>()
                {
                    new SqlParameter("@Image", image),
                    new SqlParameter("@Name", name),
                    new SqlParameter()
                    {
                        ParameterName = "@Id", DbType = System.Data.DbType.Int32,
                        Direction = System.Data.ParameterDirection.Output
                    }
                };
                context.Database.ExecuteSqlRaw("Exec dbo.SaveImages @Name, @Image, @id", paramLst.ToArray());
                context.SaveChanges();
                
                    //transaction.Commit();
                }
                catch (Exception e)
                {
                //transaction.Rollback();
                SaveError(e.Message, e.Source, e.StackTrace);
                }
            //}
        }

        public void SaveError(string message, string methodName,string stackTrace)
        {

            context.PuzzleError.Add(new PuzzleError()
            {
                Message = message,
                MethodName = methodName,
                StackTrace = stackTrace
            });

            context.SaveChanges();
        }


    }
}
