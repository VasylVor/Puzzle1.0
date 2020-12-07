using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PuzzleService.ProxyClasses
{
    [DataContract]
    public class CheckPuzzResp
    {
        [DataMember]
        public bool CheckValue { get; set; }
    }
}
