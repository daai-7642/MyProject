using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebCore.Controllers
{
    public class DataController : Controller
    {
        IConfiguration _configuration;
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
    }
}