using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebDemo.Models;

namespace WebDemo.Utils
{
   public class XSession
    {
      

        /// <summary>
        /// Truy xuất người dùng đăng nhập
        /// </summary>
        public static CandidateInfo User
        {
            get
            {
                return HttpContext.Current.Session["User"] as CandidateInfo;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }

        public static void RemoveUser()
        {
            HttpContext.Current.Session.Remove("User");
        }

        public static string ReturnUrl
        {
            get
            {
                return HttpContext.Current.Session["ReturnUrl"] as String;
            }
            set
            {
                HttpContext.Current.Session["ReturnUrl"] = value;
            }
        }

        /// <summary>
        /// Truy xuất người dùng đăng nhập
        /// </summary>
        public static Master Master
        {
            get
            {
                return HttpContext.Current.Session["Master"] as Master;
            }
            set
            {
                HttpContext.Current.Session["Master"] = value;
            }
        }
        public static void RemoveMaster()
        {
            HttpContext.Current.Session.Remove("Master");
        }
    }
}
