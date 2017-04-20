﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace NeccWxApi
{
    [Route("api/[controller]")]
    public class AdmitLineController : Controller
    {
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }

        [HttpGet("GetAllAdmitLine&lp={localProvince}")]
        [EnableCors("CorsSample")]
        public object GetAllAdmitLine(string localProvince)
        {
            try
            {
                var addr = Server.GetUserIp(Request.HttpContext);
                if (Server.IPHandle(addr) == 0)
                {
                    return new[] { "your ip can't using our api , please contact administrator" };
                }

                var re = AdmitLineServer.GetAllAdmitLine(localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
    }
}
