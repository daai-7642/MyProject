using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB_Entity
{
    public class Sys_DicTypes
    {
        public int Sys_DicId { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Sys_Dic_Name { get; set; }
        /// <summary>
        /// 类型id
        /// </summary>
        public string TypeId { get; set; }
        /// <summary>
        /// 类型父级
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 所属层级
        /// </summary>
        public int Hierarchy { get; set; }
        /// <summary>
        /// 是否有子
        /// </summary>
        public bool IsChildren { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime AutchTime { get; set; }
    }
}
