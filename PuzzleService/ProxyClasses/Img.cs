using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PuzzleService.ProxyClasses
{
    [DataContract]
    public class Img
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ImgName { get; set; }
    }
}
