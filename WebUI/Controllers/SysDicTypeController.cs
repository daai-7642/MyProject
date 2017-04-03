using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AB_Entity;
using AB_Logic;
namespace WebUI.Controllers
{
    public class SysDicTypeController : Controller
    {
        SysDicType_Logic sysDicTypeLogic = new SysDicType_Logic();
        public ActionResult Index()
        {
            ViewBag.dicList= System.Web.Helpers.Json.Encode(sysDicTypeLogic.GetAllDicTypeTreeList());
            return View();
        }
        // GET: SysDicType
        public ActionResult GetDicTypesHtmlByPid(string ParentId)
        {
            var data = sysDicTypeLogic.GetDicTypesByPid(ParentId);
            string typeId = "other";
            if(data!=null)
            {
                typeId = data.First().TypeId;
            }
            data.Add(new Sys_DicTypes() { Sys_Dic_Name = "其他", TypeId = typeId });
            return PartialView("RadioTemplete",data);
        }
          
    }
}