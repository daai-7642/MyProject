using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Models
{ 
    public class ChargeInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public System.Guid AccountBookId { get; set; }
        /// <summary>
        /// 消费概要
        /// </summary>
        public string ChargeName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; } 
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime ChargeTime { get; set; }
       
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 相关人
        /// </summary>
        public string RelatedPeople { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string RemarkInfo { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string TypeId { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public string CreateAuthor { get; set; } 
    }
}
