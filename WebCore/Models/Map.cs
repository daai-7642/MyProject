using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models
{
    public class Map
    {
        public int status { get; set; }
        public result result { get; set; }
    }
    public class result
    {
        public string formatted_address { get; set; }
        public location location { get; set; }
    }
    public class location
    {
        /// <summary>
        /// 经度
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string lnt { get; set; }
    }
}
