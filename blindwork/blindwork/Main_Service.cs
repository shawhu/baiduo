using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blindwork
{
    [EnableCors(allowedMethods: "GET, POST, PUT, DELETE, OPTIONS", allowedHeaders: "Accept,Content-Type,Authorization")]
    public class Main_Service:Service
    {
        public MemberModel Post(LoginRequest req)
        {
            return MemberModel.Login("123213", "adsfadsf");
        }
    }
}