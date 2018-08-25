using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commom
{
    public  class ResultCode
    {
        public  int Code { get; set; }
        public  string Msg { get; set; }
        public  string Detail { get; set; }
        public  object Items { get; set; }
    }
}
