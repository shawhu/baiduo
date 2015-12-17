using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace blindwork
{
    public class Common
    {
        internal static bool SendSMSCode(string message, string cellphone_number)
        {
            try
            {
                CSharpSmsApi.SMS.sendSms(ConfigurationManager.AppSettings["SMSKEY"], message, cellphone_number);
            }
            catch
            {
                return false;
            }
            return true;
        }
        internal static string Random4DigitCode()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = 0;
            numIterations = rand.Next(1000, 9999);
            return numIterations.ToString();
        }

        public static DateTime Double2DateTime(double interval)
        {
            DateTime dt = DateTime.Parse("1970-1-1 00:00:00 +0000");
            if (DateTime.Now.IsDaylightSavingTime())
                interval += 3600;
            return dt.Add(TimeSpan.FromSeconds(interval));
        }

        public static double DateTime2Double(DateTime dt)
        {
            DateTime now = DateTime.Parse("1970-1-1 00:00:00 +0000");
            double seconds = (dt - now).TotalSeconds;
            if (DateTime.Now.IsDaylightSavingTime())
                seconds -= 3600;
            return seconds;
        }

        /// <summary>
        /// 检查Cellphone是否已被用掉
        /// </summary>
        /// <param name="nickname"></param>
        public static bool doesCellphoneExist(string cellphone)
        {
            SqlDataObject dbo = new SqlDataObject();
            dbo.SqlComm = "select * from t_member where cellphone = @cellphone and (token is not null)";
            DataTable dt = dbo.GetDataTable(new SqlParameter("@cellphone",cellphone));
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
    }
}