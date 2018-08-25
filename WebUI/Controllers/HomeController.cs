using AB_Entity;
using AB_Logic;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        ChargeInfo_Logic chargeInfoLogic = new ChargeInfo_Logic();
        public ActionResult Index(int pageIndex=1,string where="")
        {
            int rowCount = 0;
            int pageSize = OperateHelper.GetPageSize;
            List<ChargeInfo> list = new List<ChargeInfo>(); //chargeInfoLogic.GetChargeInfoPageList(pageIndex, pageSize, where, " c.CreateTime ", out rowCount);
            PagedList<ChargeInfo> pageList = new PagedList<ChargeInfo>(list,pageIndex,pageSize,rowCount);
            if (Request.IsAjaxRequest())
                return PartialView("ChargePage",pageList);
            return View(pageList);
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ClearCache()
        {
            CacheHelper.RemoveAllCaches();
            return View("Index");
        }
    }
}