using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Entity
{
    /// <summary>
    /// 消费统计
    /// </summary>
    public  class ChargeStatistic
    {
        /// <summary>
        /// 排序id
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 所属类型
        /// </summary>
        public string ChargeType { get; set; }
        /// <summary>
        /// 统计金额
        /// </summary>
        public string StatisMoney { get; set; }
        /// <summary>
        /// 所统计的时间___string转换好用
        /// </summary>
        public string ChargeTime { get; set; }

    }

    public class ChargeStatistics
    {
        /// <summary>
        /// 日统计
        /// </summary>
        public List<ChargeStatistic> ChargeStatisticDay { get; set; }
        /// <summary>
        /// 周统计
        /// </summary>
        public List<ChargeStatistic> ChargeStatisticWeek { get; set; }
        /// <summary>
        /// 月统计
        /// </summary>
        public List<ChargeStatistic> ChargeStatisticMonth { get; set; }
        /// <summary>
        /// 季度统计
        /// </summary>
        public List<ChargeStatistic> ChargeStatisticSeason { get; set; }
    }

}
