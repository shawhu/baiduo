using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blindwork
{
    public class AddressModel
    {
        public int address_id { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string zipcode { get; set; }
        public bool is_defult { get; set; }
        public MemberModel member { get; set; }

        /// <summary>
        /// 根据address_id获得实例
        /// </summary>
        /// <param name="address_id"></param>
        internal AddressModel(int address_id)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_address where address_id = @address_id";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@address_id", address_id));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.address_id = (int)dr["address_id"];
                    this.address = dr["address"].ToString();
                    this.city = dr["city"].ToString();
                    this.province = dr["province"].ToString();
                    this.zipcode = dr["zipcode"].ToString();
                    this.is_defult = (bool)dr["is_defult"];
                    this.member = new MemberModel((int)dr["member_id"]);
                }
            }
        }

        /// <summary>
        /// 创建地址
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="province"></param>
        /// <returns></returns>
        internal static int CreateAddress(int member_id, string address, string city, string province)
        {
            
            SqlDataObject dbo = new SqlDataObject();

            dbo.SqlComm = "select * from t_address where member_id = @member_id and address = @address and city = @city and province = @province";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@member_id", member_id), new SqlParameter("@address", address), new SqlParameter("@city", city), new SqlParameter("province", province));
            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.Rows[0];
                return (int)dr["address_id"];
            }
            else
            {
                AddressModel.Judement(member_id);//判断是否修改默认地址
                dbo.SqlComm = "insert into t_address(member_id,address,city,province) values (@member_id,@address,@city,@province)";

                dbo.ExecuteNonQuery(new SqlParameter("@member_id", member_id), new SqlParameter("@address", address), new SqlParameter("@city", city), new SqlParameter("province", province));
                //int address_id = SqlDataObject.GetIdentity("address_id");为什么这样得到的是null?
                dbo.SqlComm = "select * from t_address where member_id = @member_id and address = @address and city = @city and province = @province";
                dt = dbo.GetDataTable(new SqlParameter("@member_id", member_id), new SqlParameter("@address", address), new SqlParameter("@city", city), new SqlParameter("province", province));
                DataRow dr = dt.Rows[0];
                return (int)dr["address_id"];;
            }
        }

        /// <summary>
        /// 修改默认地址
        /// </summary>
        /// <param name="member_id"></param>
        private static void Judement(int member_id)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_address where member_id = @member_id";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@member_id", member_id));
            if (dt.Rows.Count > 0)
            {
                dbo.SqlComm = "update t_address set is_defult = 0 where member_id = @member_id";
                dbo.ExecuteNonQuery(new SqlParameter("@member_id", member_id));
            }
        }
    }
}