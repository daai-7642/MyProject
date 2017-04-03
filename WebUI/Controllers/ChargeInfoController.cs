using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AB_Entity;
using AB_Logic;
namespace WebUI.Controllers
{
    public class ChargeInfoController : Controller
    {
        // GET: ChargeInfo
        public ActionResult AddCharge()
        {
            return View(new SysDicType_Logic().GetDicTypesByPid("0"));
        }
        [HttpPost]
        public ActionResult AddCharge(ChargeInfo charge)
        {
            charge.CreateAuthor = User.Identity.Name;
            int result = new ChargeInfo_Logic().AddChargeInfo(charge);
            if (result > 0)
                return Content("<script>alert('添加成功');location.href='/Home/index'</script>");
            else
                return Content("<script>alert('添加失败')</script>");
        }
    }
}