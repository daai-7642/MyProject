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
        // GET: SysDicType
        public ActionResult GetDicTypesHtmlByPid(string ParentId)
        {
            var data = new SysDicType_Logic().GetDicTypesByPid(ParentId);
            return PartialView("RadioTemplete",data);
        }
    }
}