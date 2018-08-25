using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AB_Logic;
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
        public BillController(BillContext billcontext)
        {
            _context = billcontext;
        }
        AB_Logic.ChargeInfo_Logic _Logic = new AB_Logic.ChargeInfo_Logic();

        [HttpPost]
        public IActionResult Post([FromBody]ChargeInfo charge)
        {
            charge.CreateTime = DateTime.Now;
            _context.ChargeInfo.Add(charge);
            int result = _context.SaveChanges();
            //int result = _Logic.AddChargeInfo(charge); 
            return CreatedAtRoute("bill", charge);
        }
        [HttpGet]
        public IActionResult Get(int index,int size,string where)
        {
          //  _context.ChargeInfo.FromSql("Pr_GetChargeInfoPageList",);
            //_context.ChargeInfo .Where().Skip((index-1)*size).Take(size)
            int count = 0;
            var data= new ChargeInfo_Logic().GetChargeInfoPageList(index,size,where, " c.CreateTime ", out count);
           
            return Ok(new {count=count,arr=data});
        }

    }
}