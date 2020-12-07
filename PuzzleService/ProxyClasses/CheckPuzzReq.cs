using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PuzzleService.ProxyClasses
{
    [DataContract]
    public class CheckPuzzReq
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public List<string> Puzzle { get; set; }
    }
}
