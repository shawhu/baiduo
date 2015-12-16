using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blindwork
{
    /// <summary>
    /// 登录
    /// </summary>

    [Route("/member/login")]
    public class LoginRequest : IReturn<MemberModel>
    {
        public string cellphone { get; set; }
        public string confirmation_code { get; set; }
    }

    //wechat 登录,暂时没用
    [Route("/member/wxlogin")]
    public class WXLoginRequest : IReturn<MemberModel>
    {
        public string wechatid { get; set; }
    }
}