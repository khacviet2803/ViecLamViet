using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebDemo.Utils
{
    public class XCookie
    {
        /// <summary>
        /// Đọc giá trị cookie
        /// </summary>
        /// <param name="name">Tên cookie</param>
        /// <param name="defval">Giá trị mặc định</param>
        /// <returns>Giá trị cookie hoặc giá trị mặc định nếu cookie không tồn tại</returns>
        public static String GetValue(String name, String defval = "")
        {
            var cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                return defval;
            }
            var value = cookie.Value.FromBase64();
            return value;
        }

        /// <summary>
        /// Tạo và gửi cookie về client để lưu lại
        /// </summary>
        /// <param name="name">Tên cookie</param>
        /// <param name="days">Số ngày tồn tại</param>
        /// <param name="value">Danh sách các giá trị</param>
        public static void Add(String name, int days = 0, String value = "")
        {
            var cookie = new HttpCookie(name, value.ToBase64());
            cookie.Expires = DateTime.Now.AddDays(days);
            cookie.Path = "/";
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
