using System;
using System.Collections.Generic;

namespace PuzzleService.Models
{
    public partial class PuzzleError
    {
        public int Id { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime? Created { get; set; }
    }
}
