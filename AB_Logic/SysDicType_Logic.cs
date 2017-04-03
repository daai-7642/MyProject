using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AB_Entity;
using AB_Repository;
namespace AB_Logic
{
    public class SysDicType_Logic
    {
        SysDicType_Repository dicTypeRepository = new SysDicType_Repository();

        /// <summary>
        /// 获取所有的类型字典项
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Sys_DicTypes> GetDicTypesByPid(string parentId)
        {
            return dicTypeRepository.GetDicTypesByPid(parentId);
        }
        public List<Sys_DicTypes> GetDicTypesByPid(string parentId, out int hierarchy)
        {
            return dicTypeRepository.GetDicTypesByPid(parentId, out hierarchy);
        }
        public List<Sys_DicTypes> GetAllDicTypes()
        {
            return dicTypeRepository.GetAllDicTypes();
        }
        public List<DicTypeTree> GetAllDicTypeTreeList()
        {
            return dicTypeRepository.GetAllDicTypeTreeList();
        }
    }
}
