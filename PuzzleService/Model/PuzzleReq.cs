using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PuzzleService.Model
{
    [DataContract]
    public class PuzzleReq
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BImage { get; set; }
        [DataMember]
        public string NameImage { get; set; }
        [DataMember]
        public int WidthRect { get; set; }
        [DataMember]
        public int HeightRect { get; set; }

    }
}
