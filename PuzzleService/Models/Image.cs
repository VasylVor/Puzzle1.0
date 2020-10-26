using System;
using System.Collections.Generic;

namespace PuzzleService.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image1 { get; set; }
        public DateTime? Created { get; set; }
    }
}
