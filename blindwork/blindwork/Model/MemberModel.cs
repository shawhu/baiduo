using System;
using System.Collections.Generic;
using System.Configuration;
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
        public string fullname { get; set; }
        public string cellphone { get; set; }
        public string confirmation_code { get; set; }
        public string email { get; set; }
        public string signup_type { get; set; }
        public double datetime { get; set; }
        public string token { get; set; }
        public string wechat_id { get; set; }

        internal MemberModel() { }

        /// <summary>
        /// 根据key去获得用户，key=cellphone or member or email
        /// </summary>
        /// <param name="key"></param>
        internal MemberModel(string key)
        {
            SqlDataObject dbo = new SqlDataObject();
            string sqlmember_id = " or member_id = @member_id";
            DataTable dt;
            if (key.Length > 9)
                sqlmember_id = "";
            dbo.SqlComm = "select * from t_member where cellphone = @cellphone"+sqlmember_id+" or email = @email";
            if (key.Length > 9)
            {
                dt = dbo.GetDataTable(new SqlParameter("@cellphone", key), new SqlParameter("@member_id", key), new SqlParameter("@email", key));
            }
            else
            {
                dt = dbo.GetDataTable(new SqlParameter("@cellphone", key), new SqlParameter("@email", key));
            }
            //
            //
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.member_id = (int)dr["member_id"];
                    this.fullname = dr["fullname"].ToString();
                    this.cellphone = dr["cellphone"].ToString();
                    this.confirmation_code = dr["confirmation_code"].ToString();
                    this.email = dr["email"].ToString();
                    this.signup_type = dr["signup_type"].ToString();
                    this.datetime = Common.DateTime2Double((DateTime)dr["datetime"]);
                    this.token = dr["token"].ToString();
                    this.wechat_id = dr["wechat_id"].ToString();
                }
            }
        }
        /// <summary>
        /// 根据member_id获得member对象
        /// </summary>
        /// <param name="member_id"></param>
        internal MemberModel(int member_id)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_member where member_id = @member_id";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@member_id", member_id));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.member_id = (int)dr["member_id"];
                    this.fullname = dr["fullname"].ToString();
                    this.cellphone = dr["cellphone"].ToString();
                    this.confirmation_code = dr["confirmation_code"].ToString();
                    this.email = dr["email"].ToString();
                    this.token = dr["token"].ToString();
                    this.datetime = Common.DateTime2Double((DateTime)dr["datetime"]);
                    this.signup_type = dr["signup_type"].ToString();
                    this.wechat_id = dr["wechat_id"].ToString();
                }
            }
        }


        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="cellphone"></param>
        /// <param name="email"></param>
        /// <param name="confirmation_code"></param>
        /// <returns></returns>
        private static bool CreateMember(string cellphone, string confirmation_code)
        {
            DataTable dt;
            DataRow dr;
            SqlDataObject dbo = new SqlDataObject();
            
                dbo.SqlComm = "select * from t_member where cellphone = "+cellphone;
                dt = dbo.GetDataTable();
                if (dt.Rows.Count == 0)
                {
                    dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr = dt.Rows[0];
                }
                dr["cellphone"] = cellphone;
                dr["confirmation_code"] = confirmation_code;
                dr["signup_type"] = "cellphone";
                dbo.Update(dt);
            
            return true;
        }
        /// <summary>
        /// 内部内存档member
        /// </summary>
        /// <returns></returns>
        private bool save()
        {
            if (this.member_id == 0)
                return false;
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_member where member_id = "+member_id;
            DataTable dt = dbo.GetDataTable();
            foreach (DataRow dr in dt.Rows)
            {
                dr["cellphone"] = this.cellphone;
                dr["email"] = this.email;
                dr["fullname"] = this.fullname;
                dr["confirmation_code"] = this.confirmation_code;
                dr["token"] = this.token;
            }
            dbo.Update(dt);
            return true;
        }

        /// <summary>
        /// harry做的登陆
        /// </summary>
        /// <param name="cellphone"></param>
        /// <param name="plain_password"></param>
        /// <returns></returns>
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
                mm.token = dr["token"].ToString();
                mm.datetime = Common.DateTime2Double((DateTime)dr["datetime"]);
                mm.wechat_id = dr["wechat_id"].ToString();
                return mm;
            }
            throw new AuthenticationException("Login failed, cellphone not found");
        }


        internal static MemberModel SignUpMember(string cellphone, string fullname, string confirmation_code)
        {
            MemberModel member;
            string code = Common.Random4DigitCode();
            if (string.IsNullOrEmpty(confirmation_code))
            {
                if (!string.IsNullOrEmpty(cellphone))
                {
                    if (Common.doesCellphoneExist(cellphone))
                        throw new ArgumentException(ConfigurationManager.AppSettings["duplicate_cellphone"].ToString());
                    if (!MemberModel.CreateMember(cellphone, code))
                        throw new ArgumentException("创建失败");
                    if (cellphone.Length == 11)
                        Common.SendSMSCode("【白朵】您的验证码是" + code, cellphone);
                }
                else
                    throw new ArgumentException("cellphone不能为空");
                throw new AuthenticationException(ConfigurationManager.AppSettings["volleykey"]);
            }
            else
            {
                if (!string.IsNullOrEmpty(cellphone))
                {
                    member = new MemberModel(cellphone);
                }
                else
                    throw new ArgumentException("cellphone不能为空");
                if (!string.IsNullOrEmpty(member.confirmation_code) && member.confirmation_code == confirmation_code)
                {
                    member.token = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
                    member.confirmation_code = "";
                    member.fullname = string.IsNullOrEmpty(fullname) ? member.cellphone.ToString() : fullname.Replace(" ", "_");
                    member.save();
                    return member;
                }
                else
                    throw new AuthenticationException(ConfigurationManager.AppSettings["confirmation_code_mismatch"]);
            }
        }

        ///// <summary>
        ///// 判断是否已有账号，如果已有就直接登陆，否则为注册
        ///// </summary>
        ///// <param name="cellphone"></param>
        ///// <param name="fullname"></param>
        ///// <param name="email"></param>
        ///// <param name="confirmation_code"></param>
        ///// <returns></returns>
        //internal static bool Judgment(string cellphone,string fullname,string email,string confirmation_code)
        //{
        //    if (string.IsNullOrEmpty(cellphone))
        //        throw new ArgumentException(ConfigurationManager.AppSettings["general_error"]);
        //    SqlDataObject dbo = new SqlDataObject();
        //    dbo.SqlComm = "select * from t_member where cellphone = @cellphone and judge = 1";
        //    DataTable dt = dbo.GetDataTable(new SqlParameter("@cellphone", cellphone));
        //    if (dt.Rows.Count != 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(confirmation_code))//获得验证码
        //        {
        //            string code = Common.Random4DigitCode();
        //            //if (!CreateMember(cellphone, email, code))
        //              //  throw new ArgumentException(ConfigurationManager.AppSettings["general_error"]);
        //            if (cellphone.Length == 11)
        //                Common.SendSMSCode("【白朵】您的验证码是" + code, cellphone);
        //            return false;
        //        }
        //        else//通过对比验证码然后注册
        //        {
        //            MemberModel member = new MemberModel(cellphone);
        //            if (!string.IsNullOrEmpty(member.confirmation_code) && member.confirmation_code == confirmation_code)
        //            {
        //                member.confirmation_code = "";
        //                member.email = string.IsNullOrEmpty(email) ? "" : email;
        //                member.fullname = string.IsNullOrEmpty(fullname) ? member.cellphone.ToString() : fullname.Replace(" ", "_");
        //                member.save();
        //                return true;
        //            }
        //            else
        //                throw new AuthenticationException(ConfigurationManager.AppSettings["confirmation_code_mismatch"]);
        //        }

        //    }
        //}





        internal static MemberModel GetMemberByToken(string token)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_member where token = @token";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@token", token));
            if (dt.Rows.Count > 0)
            {
                MemberModel member = MemberModel.GetMemberByDataTable(dt);
                return member;
            }else
                throw new ArgumentException("token错误");

            
        }
        
        internal static MemberModel GetMemberByDataTable(DataTable dt)
        {
            MemberModel member = new MemberModel();
            foreach (DataRow dr in dt.Rows)
            {
                member.member_id = (int)dr["member_id"];
                member.fullname = dr["fullname"].ToString();
                member.cellphone = dr["cellphone"].ToString();
                member.confirmation_code = dr["confirmation_code"].ToString();
                member.email = dr["email"].ToString();
                member.signup_type = dr["signup_type"].ToString();
                member.datetime = Common.DateTime2Double((DateTime)dr["datetime"]);
                member.token = dr["token"].ToString();
                member.wechat_id = dr["wechat_id"].ToString();
            }
            return member;
        }

        internal static MemberModel GetMemberByWechat(string wechat_id)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_member where wechat_id = @wechat_id";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@wechat_id", wechat_id));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MemberModel member = new MemberModel((int)dr["member_id"]);
                    return member;
                }
            }
            throw new ArgumentException("wechat_id错误");
        }
    }
}