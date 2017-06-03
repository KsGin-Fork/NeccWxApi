using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    /// <summary>
    /// 获得分数线API
    /// </summary>
    [Route("api/[controller]")]
    public class AdmitLineController : Controller
    {
        /// <summary>
        /// 获得分数线信息
        /// </summary>
        /// <returns>分数线</returns>
        [HttpGet("GetAllAdmitLine")]
        [EnableCors("CorsSample")]
        public object GetAllAdmitLine()
        {           
            try
            {
                var localProvince = HttpContext.Session.GetString("user_Province");

                if (localProvince == null)
                {
                    return new[]
                    {
                        new {msg = "not login"}
                    };
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
