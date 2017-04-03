using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Entity
{
    [Serializable]
    public class ChargeInfo
    {
        public int Order { get; set;     }
        /// <summary>
        /// 主键
        /// </summary>
        public System.Guid AccountBookId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        public string CreateTime1 { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime ChargeTime { get; set; }
        public string ChargeTime1 { get; set; }
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
        public string TypeName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public Nullable<System.DateTime> AutchTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string AutchAuthor { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public string CreateAuthor { get; set; }
        public string TypeIdOther { get; set; }
    }
}
