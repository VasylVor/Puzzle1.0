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
        public int SaveImage(string name, string image)
        {
            //using (var transaction = context.Database.BeginTransaction())
            //{
            try
            {
                // throw new Exception();
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
                context.Database.ExecuteSqlRaw("Exec dbo.SaveImages @Name, @Image, @id", paramLst.ToArray());
                context.SaveChanges();

                int a = Convert.ToInt32(id.Value);
                
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
                InnerException = innerException
            });

            context.SaveChanges();
        }

      //  public void 

    }
}
