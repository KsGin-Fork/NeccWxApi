using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    /// <summary>
    /// 专业查询API
    /// </summary>
    [Route("api/[controller]")]
    public class ProfessionController : Controller
    {
        /// <summary>
        /// 界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Get()
        {
            return View();
        }

        /// <summary>
        /// 查询专业信息
        /// </summary>
        /// <returns>专业信息</returns>
        [EnableCors("CorsSample")]
        [HttpGet("GetProfession&proName={proName}")]
        public object GetProfession(string proName)
        {
            try
            {
                
                var re = ProfessionServer.GetProfession(proName);

                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// 获得一等科类专业列表
        /// </summary>
        /// <returns>科类列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("GetProfessionFieldList&fieldName={fieldName}")]
        public IEnumerable<object> GetProfessionFieldList(string fieldName)
        {
            try
            {
                
                var re = ProfessionServer.GetProfessionFieldList(fieldName);

                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// 获得二等科类专业列表
        /// </summary>
        /// <returns>科类列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("GetProfessionDisciplineList&disName={disName}")]
        public IEnumerable<object> GetProfessionDisciplineList(string disName)
        {
            try
            {
                
                var re = ProfessionServer.GetProfessionDisciplineList(disName);

                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// 获得一等科类专业列表
        /// </summary>
        /// <returns>科类列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("FieldList")]
        public IEnumerable<object> FieldList()
        {
            try
            {
                
                var re = ProfessionServer.FieldList();

                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// 获得二等科类专业列表
        /// </summary>
        /// <returns>科类列表</returns>
        [EnableCors("CorsSample")]
        [HttpGet("DisciplineList")]
        public IEnumerable<object> DisciplineList()
        {
            try
            {
                
                var re = ProfessionServer.DisciplineList();

                return re;
            }
            catch (Exception e)
            {
                return new[] {e.Message};
            }
        }

        /// <summary>
        /// 获得专业类别与专业对照表
        /// </summary>
        /// <returns>专业类别与类别所有专业</returns>
        [EnableCors("CorsSample")]
        [HttpGet("GetProfessionList")]
        public Dictionary<object, IEnumerable<object>> GetProfessionList()
        {
            try
            {
                var re = ProfessionServer.GetProfessionList();

                return re;
            }
            catch (Exception e)
            {
                return new Dictionary<object, IEnumerable<object>>
                {
                    {
                        new {result = "wrong"}, new[] {e.Message}
                    }
                };
            }
        }
    }
}
