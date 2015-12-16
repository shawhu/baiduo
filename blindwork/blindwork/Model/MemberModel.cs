using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Authentication;
using System.Web;

namespace blindwork
{
    public class MemberModel
    {
        public int member_id { get; set; }
        public string cellphone { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }

        public static MemberModel Login(string cellphone, string plain_password)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_member where cellphone = @cellphone";
            var dt = dbo.GetDataTable(new SqlParameter("@cellphone", cellphone));
            
            foreach(DataRow dr in dt.Rows)
            {
                var mm = new MemberModel();
                mm.member_id = (int)dr["member_id"];
                mm.cellphone = dr["cellphone"].ToString();
                mm.fullname = dr["fullname"].ToString();
                mm.email = dr["email"].ToString();
                return mm;
            }
            throw new AuthenticationException("Login failed, cellphone not found");
        }
    }
}