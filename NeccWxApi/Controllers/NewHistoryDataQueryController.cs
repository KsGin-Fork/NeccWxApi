using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Models;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    /// <summary>
    /// 新历史数据查询API
    /// </summary>
    [Route("api/[controller]")]
    public class NewHistoryDataQueryController : Controller
    {
        /// <summary>
        /// 精确查询
        /// </summary>
        /// <param name="qunpm">查询参数</param>
        /// <returns></returns>
        [HttpPatch("QueryUniversity")]
        [HttpPost("QueryUniversity")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryUniversity([FromBody]QUniNameParModel qunpm)
        {
            try
            {
                var account = HttpContext.Session.GetString("user_Account");
                var localProvince = HttpContext.Session.GetString("user_Province");

                if (account == null || localProvince == null)
                {
                    return new[]
                    {
                        new {msg = "not login"}
                    };
                }

                if (Server.AccountHandle(account) == 0)
                {
                    return new[]
                    {
                        new {msg = "times exceeded"}
                    };
                }
                
                var re = NewHistoryDataQueryServer.QueryUniversity(qunpm , localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 精确查询专业
        /// </summary>
        /// <param name="qpnpm">查询参数</param>
        /// <returns>查询结果</returns>
        [HttpPatch("QueryProfession")]
        [HttpPost("QueryProfession")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryProfession([FromBody] QProNameParModel qpnpm)
        {
            try
            {
                var account = HttpContext.Session.GetString("user_Account");
                var localProvince = HttpContext.Session.GetString("user_Province");

                if (account == null || localProvince == null)
                {
                    return new[]
                    {
                        new {msg = "not login"}
                    };
                }

                if (Server.AccountHandle(account) == 0)
                {
                    return new[]
                    {
                        new {msg = "times exceeded"}
                    };
                }

                var re = NewHistoryDataQueryServer.QueryProfession(qpnpm , localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 分数查询
        /// </summary>
        /// <param name="qspm">查询参数头</param>
        /// <returns>查询结果</returns>
        [HttpPatch("QueryScore")]
        [HttpPost("QueryScore")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryScore([FromBody] QScoreParModel qspm)
        {
            try
            {
                var account = HttpContext.Session.GetString("user_Account");
                var localProvince = HttpContext.Session.GetString("user_Province");

                if (account == null || localProvince == null)
                {
                    return new[]
                    {
                        new {msg = "not login"}
                    };
                }

                if (Server.AccountHandle(account) == 0)
                {
                    return new[]
                    {
                        new {msg = "times exceeded"}
                    };
                }

                var re = NewHistoryDataQueryServer.QueryScore(qspm , localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 位次查询
        /// </summary>
        /// <param name="qppm">查询参数头</param>
        /// <returns>查询结果</returns>
        [HttpPatch("QueryPNum")]
        [HttpPost("QueryPNum")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> QueryPNum([FromBody] QPNumParModel qppm)
        {
            try
            {
                var account = HttpContext.Session.GetString("user_Account");
                var localProvince = HttpContext.Session.GetString("user_Province");

                if (account == null || localProvince == null)
                {
                    return new[]
                    {
                        new {msg = "not login"}
                    };
                }

                if (Server.AccountHandle(account) == 0)
                {
                    return new[]
                    {
                        new {msg = "times exceeded"}
                    };
                }

                var re = NewHistoryDataQueryServer.QueryPNum(qppm , localProvince);

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 所有的院校所在地
        /// </summary>
        /// <returns>所有的院校所在地</returns>
        [HttpGet("AllUniLocal")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> AllUniLocal()
        {
            try
            {
                var account = HttpContext.Session.GetString("user_Account");

                if (account == null)
                {
                    return new[]
                    {
                        new {msg = "not login"}
                    };
                }

                if (Server.AccountHandle(account) == 0)
                {
                    return new[]
                    {
                        new {msg = "times exceeded"}
                    };
                }

                var re = NewHistoryDataQueryServer.AllUniLocal();

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 所有的院校类型
        /// </summary>
        /// <returns>所有的院校类型</returns>
        [HttpGet("AllUniType")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> AllUniType()
        {
            try
            {
                var account = HttpContext.Session.GetString("user_Account");

                if (account == null)
                {
                    return new[]
                    {
                        new {msg = "not login"}
                    };
                }

                if (Server.AccountHandle(account) == 0)
                {
                    return new[]
                    {
                        new {msg = "times exceeded"}
                    };
                }

                var re = NewHistoryDataQueryServer.AllUniType();

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }

        /// <summary>
        /// 所有的批次
        /// </summary>
        /// <returns>所有的批次</returns>
        [HttpGet("AllUniBatch")]
        [EnableCors("CorsSample")]
        public IEnumerable<object> AllUniBatch()
        {
            try
            {
                var account = HttpContext.Session.GetString("user_Account");

                if (account == null)
                {
                    return new[]
                    {
                        new {msg = "not login"}
                    };
                }

                if (Server.AccountHandle(account) == 0)
                {
                    return new[]
                    {
                        new {msg = "times exceeded"}
                    };
                }
                var re = NewHistoryDataQueryServer.AllUniBatch();

                return re;
            }
            catch (Exception e)
            {
                return new[] { e.Message };
            }
        }
    }
}