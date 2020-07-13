using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDemo.ModelsView
{
    public class CV
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Chưa Nhập Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Chưa Nhập Tên")]
        public string name { get; set; }
      
        public string cv { get; set; }
      
    }
}