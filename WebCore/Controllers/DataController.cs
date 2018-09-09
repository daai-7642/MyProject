using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_Entity;
using AB_Logic;
using Commom;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebCore.Controllers
{
    public class DataController : Controller
    {
        IConfiguration _configuration;
        SysDicType_Logic logic = new SysDicType_Logic();
        static string connstr;
        AB_Logic.ChargeInfo_Logic chargeLogic;
        public DataController(IConfiguration configuration)
        {
            _configuration = configuration;
            connstr = configuration.GetConnectionString("DefaultConnection");
            chargeLogic = new AB_Logic.ChargeInfo_Logic(connstr);
        }
        public IActionResult Index()
        {
            return Json("错误");
        }
        public string GetIciba()
        {
            string url = string.Format(_configuration["AppSetting:jsciba"], DateTime.Now.ToString("yyyy-MM-dd"));
            string result = HttpHelper.Get(url);
            return result;
        }
        /// <summary>
        /// 获取消费类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetChargeType()
        {
            List<AppTree> appTrees = new List<AB_Entity.AppTree>();
            var list = logic.GetTrees("0");
            return Json("");
        }
        public string GetOne()
        {
            string url = "http://m.wufazhuce.com/article"; //string.Format(_configuration["AppSetting:oneapi"]);
            string result = HttpHelper.Get(url);
            return result;
        }
        [HttpPost]
        public ActionResult DeleteBill(string id)
        {
            ResultCode resultc = new ResultCode();
            Guid gid ;
            Guid.TryParse(id,out gid);
            if (gid == Guid.Empty)
            {
                resultc.msg ="id无效";
                resultc.code = 0;
                return Ok(resultc); 
            }
            int result = chargeLogic.DeleteChargeInfo(gid);
            

            resultc.msg = result > 0 ? "ok" : "no";
            resultc.code = result;
            return Ok(resultc);
        }
       
    }
}