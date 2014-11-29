using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BD_Server
{
    public class DataAccessHelper
    {
        public static DateTime NullDateTime
        {
            get { return DateTime.Parse("1970-1-1 00:00:00 +0000"); }
        }

        public static DateTime GetDateTimeFromDouble(double interval)
        {
            DateTime dt = DateTime.Parse("1970-1-1 00:00:00 +0000");
            return dt.Add(TimeSpan.FromSeconds(interval));
        }

        public static double GetDoubleFromDateTime(DateTime dt)
        {
            DateTime now = DateTime.Parse("1970-1-1 00:00:00 +0000");
            return (dt - now).TotalSeconds;
        }

        public static double GetDoubleFromCurentTime() {
            DateTime now = DateTime.Now;
            return GetDoubleFromDateTime(now);
        }

        

        public static bool ConvertBoolData(string dbstr)
        {
            int val = 0;
            if (int.TryParse(dbstr, out val))
            {
                return (val > 0);
            }
            return string.Equals(dbstr.ToUpper(), "TRUE");
        }

        /// <summary>
        /// 检查Email合法性
        /// </summary>
        public static bool CheckValidEmail(string address)
        {
            if (String.IsNullOrEmpty(address))
                return false;

            return Regex.IsMatch(address, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                                RegexOptions.IgnoreCase);
        }



        /// <summary>
        /// md5混淆加密
        /// </summary>
        /// <param name="decrytstr"></param>
        /// <returns></returns>
        public static string MixedEncrypt(string decrytstr)
        {
            string seed = string.Format("{0}-{1}-", Guid.NewGuid().ToString().Substring(34), Guid.NewGuid().ToString().Substring(0, 2));
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(decrytstr));
            return (seed + BitConverter.ToString(s)).ToLower();
        }

        /// <summary>
        /// 判断密文是否和明文匹配
        /// </summary>
        /// <param name="encrytstr"></param>
        /// <param name="decryptstr"></param>
        /// <returns></returns>
        public static bool MixedCompare(string encrytstr, string decryptstr)
        {
            string md5str = encrytstr.Substring(6);
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(decryptstr));
            return string.Equals(BitConverter.ToString(s), md5str, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
