using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blindwork
{
    public class MemberModel
    {
        public int member_id { get; set; }
        public string cellphone { get; set; }
        public string email { get; set; }

        public static MemberModel Login(string cellphone, string plain_password)
        {
            return new MemberModel();
        }
    }
}