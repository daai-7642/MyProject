using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_Entity;
using AB_Logic;
using Commom;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class DataController : Controller
    {
        BillContext _context;
        IConfiguration _configuration;
        SysDicType_Logic logic = new SysDicType_Logic();
        static string connstr;
        AB_Logic.ChargeInfo_Logic chargeLogic;
        public DataController(IConfiguration configuration, BillContext billContext)
        {
            _context = billContext;
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

        public ActionResult GetWeekStatistics()
        {
            var data = _context.WeekStatistics.FromSql("EXECUTE Pr_Week_Statistics");
            var arr = from d in data select d.Name;
            ResultCode result = new ResultCode();
            result.data = new { titleArr = arr, dataList=data };
            result.msg = "获取统计";
            result.code = 200; 
            return Ok(result);
        } 
        public ActionResult GetUpMonth_Statistics()
        {
            var data = _context.UpMonthStatistics.FromSql("EXECUTE Pr_UpMonth_Statistics").ToList();
            string  upDay1 = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-01");
            string currDay1 = DateTime.Now.ToString("yyyy-MM-01");
            double num = (Convert.ToDateTime(currDay1) - Convert.ToDateTime(upDay1)).TotalDays;
            DateTime date = Convert.ToDateTime(upDay1);
            for (int i = 0; i < num; i++)
            {
                DateTime currDate = date.AddDays(i);
                UpMonthStatistics upModel = data.FirstOrDefault(a => a.Date == currDate);
                if ( upModel== null)
                {
                    data.Add(new UpMonthStatistics() {
                        Date = currDate,
                        
                    });
                } 
            }
            //foreach (var d in data)
            //{
            //    if(d.Date.ToString("yyyy-MM-dd"))
            //}
            object arr =  from d in data select d.Name;
            ResultCode result = new ResultCode();
            result.data = new { titleArr = arr, dataList = data };
            result.msg = "获取统计";
            result.code = 200;
            return Ok(result);
        }
    }
}