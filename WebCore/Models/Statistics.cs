using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models
{
    public class WeekStatistics
    {
        [Key]
        public string name { get; set; }
        public string value { get; set; }
    }
}
