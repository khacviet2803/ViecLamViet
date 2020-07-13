using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDemo.ModelsView
{
    public class GoogleProfile
    {
        public string Id { get; set; }
        public string name { get; set; }
        public ImageProfile Image { get; set; }
        public string email { get; set; }
      
    }

    public class Email
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
    public class ImageProfile
    {
        public string Url { get; set; }
    }
}