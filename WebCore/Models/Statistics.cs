using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "value")]
        public decimal Money { get; set; }
    }
    public class UpMonthStatistics
    {
        [Key]
        [JsonProperty(PropertyName = "name")]
        public DateTime Date { get; set; }
        
        [JsonProperty(PropertyName = "value")]
        public decimal Money { get; set; }
    }
}
