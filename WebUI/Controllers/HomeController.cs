using AB_Entity;
using AB_Logic;
using Commom;
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
            List<ChargeInfo> list =chargeInfoLogic.GetChargeInfoPageList(pageIndex, pageSize, where, " c.CreateTime ", out rowCount);
            PagedList<ChargeInfo> pageList = new PagedList<ChargeInfo>(list,pageIndex,pageSize,rowCount);
            if (Request.IsAjaxRequest())
                return PartialView("ChargePage",pageList);
            return View(pageList);
        }
        public ActionResult GetBillList(int Index = 1, int Size = 3)
        {
            int rowCount = 0;
            int pageSize = OperateHelper.GetPageSize;
            List<ChargeInfo> list = chargeInfoLogic.GetChargeInfoPageList(Index, pageSize, "", " c.CreateTime ", out rowCount);
             
            ResultCode result = new ResultCode();
            result.Items = list;
            result.Msg = rowCount.ToString();
            return Json(result);
        }

        [HttpPost]
        public ActionResult GetChargeType(int ParentId = 0)
        {
            var list = new SysDicType_Logic().GetDicTypesByPid(ParentId.ToString());
            return Json(list);
        }

        [HttpPost]
        public ActionResult AddChargeBill(ChargeInfo entity)
        {

            entity.CreateTime = DateTime.Now;
            new ChargeInfo_Logic().AddChargeInfo(entity);
            return Content("<script>alert('添加成功');location.href='/html/BillList.html'</script>");
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