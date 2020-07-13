using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using System.Net;
using WebDemo.ModelsView;
using WebDemo.Models;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using WebDemo.Utils;

namespace WebDemo.Controllers
{
    public class LoginSocialController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void LoginWithGooglePlus()
        {
            
            GoogleConnect.ClientId = "962491188788-d8f5idouvutong9aufua4hv5nrretf70.apps.googleusercontent.com";
            GoogleConnect.ClientSecret = "1hftLV2zSm8_hT0nHIYNRvU8";
            GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];
            GoogleConnect.Authorize("profile", "email");
        }

        [ActionName("LoginWithGooglePlus")]
        public ActionResult LoginWithGooglePlusConfirmed()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string code = Request.QueryString["code"];               
                
                string poststring = @"grant_type=authorization_code&code=" + code + "&client_id=" + GoogleConnect.ClientId + "&client_secret=" + GoogleConnect.ClientSecret + "&redirect_uri=" + GoogleConnect.RedirectUri + "";

                string url = "https://accounts.google.com/o/oauth2/token";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                UTF8Encoding utfenc = new UTF8Encoding();
                byte[] bytes = utfenc.GetBytes(poststring);
                Stream outputstream = null;
                try
                {
                    request.ContentLength = bytes.Length;
                    outputstream = request.GetRequestStream();
                    outputstream.Write(bytes, 0, bytes.Length);
                }
                catch { }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                string responseFromServer = streamReader.ReadToEnd();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                Tokenclass obj = js.Deserialize<Tokenclass>(responseFromServer);
                GetuserProfile(obj.access_token);
               
               
            }
           
           
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Logout()
        {
            XSession.User = null;

            return RedirectToAction("Index", "Home");
        }
            public void GetuserProfile(string accesstoken)
        {
            string url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + accesstoken + "";
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JObject json = JObject.Parse(responseFromServer);
            GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json.ToString());

            CandidateInfo candidateInfo = new CandidateInfo();
            candidateInfo.Name = profile.name;
            candidateInfo.Email = profile.email;
            candidateInfo.Id = profile.Id;
            candidateInfo.Gender = "Nam";
            candidateInfo.Level = "Không";
            candidateInfo.Skill = "Không";
            candidateInfo.Address = "Không";
            candidateInfo.Phone = "0123456789";
          
            XSession.User = candidateInfo;
            MyDbContext db = new MyDbContext();
            var temp = db.CandidateInfos.Where(x => x.Id == candidateInfo.Id).FirstOrDefault();
            if(temp==null)
            {
                db.CandidateInfos.Add(candidateInfo);
                db.SaveChanges();
            }


        }
    }
    public class Tokenclass
    {
        private string _access_token = "";
        private string _token_type = "";
        private int _expires_in = 0;
        private string _refresh_token = "";

        public string access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }
        public string token_type
        {
            get { return _token_type; }
            set { _token_type = value; }
        }
        public int expires_in
        {
            get { return _expires_in; }
            set { _expires_in = value; }
        }
        public string refresh_token
        {
            get { return _refresh_token; }
            set { _refresh_token = value; }
        }
    }
}