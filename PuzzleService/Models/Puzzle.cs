using System;
using System.Collections.Generic;

namespace PuzzleService.Models
{
    public partial class Puzzle
    {
        public Puzzle()
        {
            InverseIdImageNavigation = new HashSet<Puzzle>();
        }

        public int Id { get; set; }
        public int? IdImage { get; set; }
        public string Puzzle1 { get; set; }
        public DateTime? Created { get; set; }

        public virtual Puzzle IdImageNavigation { get; set; }
        public virtual ICollection<Puzzle> InverseIdImageNavigation { get; set; }
    }
}
