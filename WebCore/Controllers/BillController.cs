using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_Logic;
using Commom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebCore.Models;

namespace WebCore.Controllers
{
    //[Produces("application/json")]
    [Route("api/Bill")]
    public class BillController : Controller
    {
        BillContext _context;
        IConfiguration _configuration;
        static string connstr;
        AB_Logic.ChargeInfo_Logic _Logic;
        public BillController(BillContext billcontext,IConfiguration configuration)
        {
            _configuration = configuration;
            connstr = configuration.GetConnectionString("DefaultConnection");
            _Logic = new AB_Logic.ChargeInfo_Logic(connstr);
            _context = billcontext;
        }
       

        [HttpPost]
        public IActionResult Post([FromBody]ChargeInfo charge)
        {
            charge.CreateTime = DateTime.Now;
            _context.ChargeInfo.Add(charge);
            int result = _context.SaveChanges();
            //int result = _Logic.AddChargeInfo(charge); 
            ResultCode resultc = new ResultCode();
            resultc.data = charge;
            resultc.msg = result>0? "ok":"no";
            resultc.code = result;
            return Ok(resultc);
        }
        [HttpGet]
        public IActionResult Get(int index=1,int size=10)
        {
            string where = "";
          //  _context.ChargeInfo.FromSql("Pr_GetChargeInfoPageList",);
            //_context.ChargeInfo .Where().Skip((index-1)*size).Take(size)
            int count = 0;
            var data= _Logic.GetChargeInfoPageList(index,size,where, " c.CreateTime desc", out count);
            ResultCode result = new ResultCode();
            result.data = data;
            
            //return Json(result);
            return Ok(result);
        }

    }
}