using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commom;
using AB_Entity;
using Common;
using System.Data;

namespace AB_Repository
{
    public class SysDicType_Repository
    {
        /// <summary>
        /// 获取所有的类型字典项
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Sys_DicTypes> GetDicTypesByPid(string parentId)
        {
            return this.GetAllDicTypes().Where(a => a.ParentId == parentId).ToList();
        }
        /// <summary>
        /// 获取相应字典及最底层层级
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="hierarchy"></param>
        /// <returns></returns>
        public List<Sys_DicTypes> GetDicTypesByPid(string parentId, out int hierarchy)
        {
            List<Sys_DicTypes> dicList = this.GetAllDicTypes();
            hierarchy = dicList.Max(a => a.Hierarchy);
            return dicList.Where(a => a.ParentId == parentId).ToList();
        }
        public List<Sys_DicTypes> GetAllDicTypes()
        {
            string key = OperateHelper.GetThisFullMethodName();
            object obj = CacheHelper.Get(key);
            if (obj == null)
            {
                List<Sys_DicTypes> dicTypes = new List<Sys_DicTypes>();
                string sql = OperateHelper.GetXmlSqlString(key);
                DataTable dt = SqlHelper.ExecuteDataTable(SqlHelper.GetConnSting(), CommandType.Text, sql);
                foreach (DataRow item in dt.Rows)
                {
                    Sys_DicTypes dicType = new Sys_DicTypes();
                    dicType.TypeId = item["TypeId"].ToString();
                    dicType.Sys_Dic_Name = item["Sys_Dic_Name"].ToString();
                    dicType.ParentId = item["ParentId"].ToString();
                    dicType.Hierarchy = Convert.ToInt32(item["Hierarchy"]);
                    dicType.IsChildren = Convert.ToBoolean(item["IsChildren"]);
                    dicTypes.Add(dicType);
                }
                CacheHelper.AddPermanent(key, dicTypes);
                obj = dicTypes;
            }
            return obj as List<Sys_DicTypes>;
        }
        public List<DicTypeTree> GetAllDicTypeTreeList()
        {
            List<DicTypeTree> dicTypeList = new List<DicTypeTree>();
            List<Sys_DicTypes> dicList = this.GetAllDicTypes();
           var list=  GetTree(dicTypeList,"0");
            return list;

        }
        private List<DicTypeTree> GetTree(List<DicTypeTree> dicTypeList, string typeId = "0")
        {
           
            foreach (var item in this.GetAllDicTypes().Where(a => a.ParentId ==typeId))
            {
                DicTypeTree dicTypeTree = new DicTypeTree();
                dicTypeTree.text = item.Sys_Dic_Name;
                var nodes = GetTree(new List<DicTypeTree>(), item.TypeId);
                dicTypeTree.nodes = nodes.Count()==0?null:nodes;
                var state=new Dictionary<string, bool>();
                state.Add("expanded", true);
                dicTypeTree.tags = new Tree() { id=item.TypeId};
                dicTypeTree.id = item.TypeId;
                dicTypeTree.State = state;
                dicTypeList.Add(dicTypeTree);
            }
            return dicTypeList;
        }
    }
}
