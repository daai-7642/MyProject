using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebCore.Models;

namespace WebCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Map")]
    public class MapController : Controller
    { 
        IConfiguration _configuration; 
        public MapController(  IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public IActionResult Get(string lat, string lng)
        {
            //string lat,string lng
            string ak = _configuration["AppSetting:ak"];
            string url = string.Format(_configuration["AppSetting:mapgeocoder"],lat,lng,ak);
            string result= HttpHelper.Get(url);
           Map map=  Newtonsoft.Json.JsonConvert.DeserializeObject<Map>(result);
            return Ok(map);
        }
    }
}