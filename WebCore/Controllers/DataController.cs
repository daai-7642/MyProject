using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_Entity;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebCore.Controllers
{
    public class DataController : Controller
    {
        IConfiguration _configuration;
        AB_Logic.SysDicType_Logic logic = new AB_Logic.SysDicType_Logic();
        public DataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return Json("错误");
        }
        public string GetIciba()
        {
            string url =string.Format(_configuration["AppSetting:jsciba"],DateTime.Now.ToString("yyyy-MM-dd"));
            string result = HttpHelper.Get(url); 
            return result;
        }
        /// <summary>
        /// 获取消费类型
        /// </summary>
        /// <returns></returns>
        public ActionResult GetChargeType()
        {
            List<AppTree> appTrees= new List<AB_Entity.AppTree>();
            var list= logic.GetTrees( "0");
            return Json("");
        }
        public string GetOne()
        {
            string url = "http://m.wufazhuce.com/article"; //string.Format(_configuration["AppSetting:oneapi"]);
            string result = HttpHelper.Get(url);
            return result;
        }
    }
}