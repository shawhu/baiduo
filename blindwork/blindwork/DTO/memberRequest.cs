using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blindwork
{
    [Route("/member/signin")]
    public class LoginRequest : IReturn<MemberModel>
    {
        public string token { get; set; }
    }
}