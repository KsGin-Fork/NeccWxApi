﻿using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeccWxApi.Models;
using NeccWxApi.Servers;

namespace NeccWxApi.Controllers
{
    /// <summary>
    /// 用户操作API
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : Controller
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
        /// 登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录结果</returns>
        [EnableCors("CorsSample")]
        [HttpGet("Login&a={account}&p={password}")]
        public object Login(string account, string password)
        {
            try
            {
                var re = UserServer.Login(account, password);

//                var u = UserServer.GetUser(account);
//                HttpContext.Session.SetString("user_account" , account);
//                HttpContext.Session.SetString("login_status", "1");
//                HttpContext.Session.SetString("user_province" , ((UserInfo)u).province);
                
                //如果登陆成功  设置session
                if (re == "login successful")
                {
                    HttpContext.Session.SetString("user_account" , account);
                    HttpContext.Session.SetString("login_status", "1");
                }

                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="active">秘钥</param>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <param name="phoneNum">电话</param>
        /// <returns>注册结果</returns>
        [HttpGet("Register&c={active}&a={account}&p={password}&n={phoneNum}")]
        [EnableCors("CorsSample")]
        public object Register(string active, string account, string password, string phoneNum)
        {
            try
            {
                if (UserServer.AccountIsExist(account).Equals("account is exists"))
                {
                    return new { msg = "account is exists" };
                }

                if (UserServer.ActiveCodeState(active).Equals("key is invalid")
                    || UserServer.ActiveCodeState(active).Equals("key is not found"))
                {
                    return new { msg = "key is not found or invaild" };
                }

                var re = UserServer.Register(active, account, password, phoneNum);

                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user">请求正文</param>
        /// <returns>结果</returns>
        [HttpPut("pRegister")]
        [EnableCors("CorsSample")]
        public object Register([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return new { msg = "bad request" };
                }

                var account = user.Account;
                var active = user.ActiveCode;
                var password = user.Password;
                var phoneNum = user.PhoneNum;

                if (UserServer.AccountIsExist(account).Equals("account is exists"))
                {
                    return new { msg = "account is exists" };
                }

                if (UserServer.ActiveCodeState(active).Equals("key is invalid")
                    || UserServer.ActiveCodeState(active).Equals("key is not found"))
                {
                    return new { msg = "key is not found or invaild" };
                }

                var re = UserServer.Register(active, account, password, phoneNum);

                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }

        /// <summary>
        /// 判断账号是否存在
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>结果</returns>
        [HttpGet("AccountIsExist&a={account}")]
        [EnableCors("CorsSample")]
        public object AccountIsExist(string account)
        {
            try
            {
                var re = UserServer.AccountIsExist(account);
                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }

        /// <summary>
        /// 判断秘钥状态
        /// </summary>
        /// <param name="activeCode">秘钥</param>
        /// <returns>结果</returns>
        [HttpGet("ActiveCodeState&a={activeCode}")]
        [EnableCors("CorsSample")]
        public object ActiveCodeState(string activeCode)
        {
            try
            {
                var re = UserServer.ActiveCodeState(activeCode);
                return new { msg = re };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="newPassword">密码</param>
        /// <returns>修改结果</returns>
        [HttpGet("ModifyPassword&a={account}&np={newPassword}")]
        [EnableCors("CorsSample")]
        public object ModifyPassowrd(string account, string newPassword)
        {
            try
            {
                if (!UserServer.AccountIsExist(account).Equals("account is exists"))
                {
                    return new
                    {
                        msg = "account not found"

                    };
                }
                var re = UserServer.ModifyPassowrd(account, newPassword);
                return new
                {
                    msg = re
                };
            }
            catch (Exception e)
            {
                return new
                {
                    msg = e.Message
                };
            }
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="user">请求体</param>
        /// <returns>结果</returns>
        [HttpPatch("pModifyPassword")]
        [HttpPost("pModifyPassword")]
        [EnableCors("CorsSample")]
        public object ModifyPassword([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return new { msg = "request error" };
                }

                var account = user.Account;
                var newPassword = user.Password;

                if (!UserServer.AccountIsExist(account).Equals("account is exists"))
                {
                    return new
                    {
                        msg = "account not found"
                    };
                }
                var re = UserServer.ModifyPassowrd(account, newPassword);
                return new
                {
                    msg = re
                };
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }


        }

        /// <summary>
        /// 查看用户信息
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns>用户信息</returns>
        [EnableCors("CorsSample")]
        [HttpGet("GetUser&a={account}")]
        public object GetUser(string account)
        {
            try
            {
                if (!UserServer.AccountIsExist(account).Equals("account is exists"))
                {
                    return new { msg = "account not found" };
                }
                var re = UserServer.GetUser(account);
                return re;
            }
            catch (Exception e)
            {
                return new { msg = e.Message };
            }
        }
    }
}
