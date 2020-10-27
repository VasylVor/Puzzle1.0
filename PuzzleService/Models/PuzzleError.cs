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
<<<<<<< HEAD
        public string InnerException { get; set; }
=======
        public string InnerExceprion { get; set; }
>>>>>>> b0ff40a8ac217458aeb9e0dd175775dfc3853026
        public DateTime? Created { get; set; }
    }
}
