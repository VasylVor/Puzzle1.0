using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PuzzleService.ProxyClasses
{
    [DataContract]
    public class PuzzleResp
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<string> ImageLst { get; set; }

        public HttpStatusCode Code { get; set; }
    }
}
