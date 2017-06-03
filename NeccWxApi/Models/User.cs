namespace NeccWxApi.Models
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 用户电话号码
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 用户激活码
        /// </summary>
        public string ActiveCode { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }
    }


    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// 用户信息模型
    /// </summary>
    public class UserInformation
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string phoneNumber { get; set; }
        /// <summary>
        /// 省份（生源地）
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string userType { get; set; }
    }
}