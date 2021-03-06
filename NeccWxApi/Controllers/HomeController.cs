﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    /// <summary>
    /// 主页
    /// </summary>
    [Route("Home")]
    public class HomeController : Controller
    {
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        [EnableCors("CorsSample")]
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }
        /// <summary>
        /// 获得用户IP
        /// </summary>
        /// <returns>IP</returns>
        [EnableCors("CorsSample")]
        [HttpGet("IP")]
        public string GetUserIp()
        {
            var ip = Server.GetUserIp(Request.HttpContext);

            return "Your IP is " + ip;
        }
    }
}