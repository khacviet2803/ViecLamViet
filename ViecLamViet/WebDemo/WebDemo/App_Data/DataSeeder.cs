using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Models;

namespace WebDemo.Data
{
    public static class DataSeeder
    {
        private static MyDbContext context;
        private static Random random = new Random();
        public static void Seed(MyDbContext context)
        {
            DataSeeder.context = context;
            SeedMaster();
            SeedRecruit_Info();
            SeedRecruit_Job();
           
        }
        private static void SeedRecruit_Info()
        {
            List<RecruitInfo> listRecruit_Info = new List<RecruitInfo>();

            listRecruit_Info.Add(new RecruitInfo() { Id = 1, MasterId = 1, About = "FPT%20Software%20is%20part%20of%20FPT%20Corporation%20%28FPT%20%u2013%20HoSE%29%20%u2013%20the%20global%20leading%20technology%2C%20outsourcing%20and%20IT%20services%20group%20headquartered%20in%20Vietnam%20with%20nearly%20US%242%20billion%20in%20revenue%20and%20more%20than%2013%2C000%20employees.%20Qualified%20with%20CMMI%20Level%205%20%26amp%3B%20ISO%2027001%3A2013%2C%20ASPICE%20LEVEL%203%2C%20FPT%20Software%20delivers%20world-class%20services%20in%20Smart%20factory%2C%20Digital%20platform%2C%20RPA%2C%20AI%2C%20IoT%2C%20Enterprise%20Mobilization%2C%20Cloud%2C%20AR/VR%2C%20Embedded%20System%2C%20Managed%20service%2C%20Testing%2C%20Platform%20modernization%2C%20Business%20Applications%2C%20Application%20Service%2C%20BPO%20and%20more%20services%20globally%20from%20delivery%20centers%20across%20the%20United%20States%2C%20Japan%2C%20Europe%2C%20Korea%2C%20China%2C%20Australia%2C%20Vietnam%20and%20the%20Asia%20Pacific.%26nbsp%3B%3C/i%3E%3Cbr%3E%3Cbr%3E%3Ci%3EIn%202017%2C%20FPT%20Software%20has%20been%20placed%20in%20top%2010%20of%20the%20ranking%20for%20three%20consecutive%20years.%20Among%20top%2010%2C%20FPT%20Software%20is%20the%20only%20IT%20Company", Logo= "https://cdn.itviec.com/employers/fpt-software/logo/w170/mir3HT3xtedbECJY5jVeRRgV/fpt-software-logo.png", poster= "https://cdn.itviec.com/photos/44603/headline_photo/fpt-software-tuyen-dung-viec-lam-IT-headline_photo.png?7bkb6ejiffJXXJzhhHDpdmxQ", OtherRequire = "%3Cp%3EJoin%20FPT%20Software%20%u2013%20You%20can%20make%20it%20too%21%20%3Cbr%3E%3Cbr%3EYou%20can%20catch%20up%20with%20unlimited%20opportunities%20to%20work%20and%20live%20in%20different%20countries%20over%20the%20world%2C%20join%20world%20class%20software%20projects%20with%20trendiest%20technologies%2C%20innovative%20products%20%26amp%3B%20services%20that%20bring%20great%20values%20to%20millions%20of%20people%20around%20the%20world%2C%20such%20as%20the%20world%u2019s%20largest%20airplane%20brand%2C%20biggest%20broadcast%20satellite%20services%20in%20the%20US%2C%20the%20leading%20manufacturer%20of%20postage%20meter%20and%20mailroom%20equipment%20in%20EU%2C%20etc.%20%3Cbr%3E%3Cbr%3EYou%20can%20choose%20your%20career%20path%20to%20become%20a%20technology%20expert%20or%20a%20professional%20manager%20which%20best%20fits%20your%20desire%2C%20qualifications%20and%20characteristics%20in%20an%20equal%20opportunity%20and%20open-minded%20culture%20workplace.%20%3Cbr%3E%3Cbr%3EYou%20can%20balance%20your%20working%20and%20spiritual%20life%20in%20the%20environment%20of%20youth%2C%20multinational%20culture%20and%20creativity%2C%20improve%20impressively%20vital%20soft%20skills%20including%20English%2C%20Japanese%2C%20French%u2026%20and%20communication%20skills%20through%20daily%20direct%20communication%20with%20global%20customers%20and%20employees.%20%3Cbr%3E%3Cbr%3EFPT%20Software%20is%20proud%20to%20accompany%20with%20thousands%20of%20individuals%20to%20continuously%20develop%20and%20explore%20their%20career%20path.%20%3Cbr%3E%3Cbr%3EYou%20can%20make%20it%20too%21%3C/p%3E", Address = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d15673.861764391819!2d106.800439!3d10.85216!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xb8b244d75d12213e!2zRlBUIFNvZnR3YXJlIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2sus!4v1589541088606!5m2!1svi!2sus", City = "Ho Chi Minh" });
            listRecruit_Info.Add(new RecruitInfo() { Id = 2, MasterId = 2, About = "%3Cstrong%3ETr%u1EDF%20th%E0nh%20%u0111%u1ED1i%20t%E1c%20t%E0i%20ch%EDnh%20%u0111%u01B0%u1EE3c%20l%u1EF1a%20ch%u1ECDn%20v%E0%20%u0111%E1ng%20tin%20c%u1EADy%20nh%u1EA5t%20c%u1EE7a%20kh%E1ch%20h%E0ng%3C/strong%3E%26nbsp%3Bnh%u1EDD%20kh%u1EA3%20n%u0103ng%20cung%20c%u1EA5p%20%u0111%u1EA7y%20%u0111%u1EE7%20c%E1c%20s%u1EA3n%20ph%u1EA9m%20v%E0%20d%u1ECBch%20v%u1EE5%20t%E0i%20ch%EDnh%20%u0111a%20d%u1EA1ng%20v%E0%20d%u1EF1a%20tr%EAn%20c%u01A1%20s%u1EDF%20lu%F4n%20coi%20kh%E1ch%20h%E0ng%20l%E0m%20tr%u1ECDng%20t%E2m.", OtherRequire = "%3Cp%3E%u201CV%u0103n%20h%F3a%20t%u1ED5%20ch%u1EE9c%u201D%20%u0111%u01B0%u1EE3c%20x%E2y%20d%u1EF1ng%20d%u1EF1a%20tr%EAn%205%20Gi%E1%20tr%u1ECB%20c%u1ED1t%20l%F5i%20%u0111%E3%20t%u1EA1o%20n%EAn%20s%u1EE9c%20m%u1EA1nh%20c%u1EE7a%20Techcombank%20v%E0%20l%E0%20n%u1EC1n%20t%u1EA3ng%20cho%20s%u1EF1%20ph%E1t%20tri%u1EC3n%20b%u1EC1n%20v%u1EEFng%20c%u1EE7a%20t%u1ED5%20ch%u1EE9c%2C%20mang%20l%u1EA1i%20th%E0nh%20c%F4ng%20cho%20kh%E1ch%20h%E0ng.%3C/p%3E", Logo = "https://cdn.itviec.com/employers/techcombank/logo/w170/G2KPh7rcAfxKYZWawVF1vLAw/techcombank-logo.png", poster = "https://cdn.itviec.com/photos/44634/headline_photo/techcombank-tuyen-dung-viec-lam-IT-headline_photo.jpg?A9QHPt611tDypLxwHeYY9h6b", Address = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d250719.16143350833!2d107.02893638749372!3d10.926545452530068!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x91a0bb52dadb162e!2sTechcombank!5e0!3m2!1sen!2s!4v1592717144260!5m2!1sen!2s", City = "Ho Chi Minh" });


            context.RecruitInfos.AddRange(listRecruit_Info);
            context.SaveChanges();
        }
        private static void SeedMaster()
        {
            List<Master> listMaster = new List<Master>();


            listMaster.Add(new Master() {Id = 1, Email = "demo@gmail.com", Password = "1", CompanyName = "FPT Software",Mobile = "03123223" });
            listMaster.Add(new Master() {Id =2 , Email = "demo1@gmail.com", Password ="1", CompanyName = "Techcombank", Mobile = "0312263" });

            context.Masters.AddRange(listMaster);
            context.SaveChanges();
        }
        private static void SeedRecruit_Job()
        {
            List<RecruitJob> listRecruit_Job = new List<RecruitJob>();

            listRecruit_Job.Add(new RecruitJob() { Id = 1 , RecruitInfoId=1, endJob = false,RecruitPosition = "Senior ERP/SAP Consultant Manager", Amount=10, Describe= "%3Cdiv%3E%3Cp%3E%3C/p%3E%3Cp%3E%3Cstrong%3EJOB%20BRIEF%3C/strong%3E%3C/p%3E%3Cp%3EEBS%20%28Enterprise%20Business%20Services%29%20is%20a%20competency%20unit%20of%20FPT%20Software%20%28%7E1000%20staff%29%20providing%20Core%20ERP%20%28SAP%2C%20MS%20Dynamic%20365%20preferred%29%20and%20surround%20applications%20together%20with%20digital%20transformation%20for%20big%20enterprises%20around%20the%20world.%20%26nbsp%3B%3C/p%3E%3Cp%3EWe%20are%20looking%20for%20an%20ambitious%20and%20energetic%20Senior%20ERP/SAP%20Consultant%20Manager%20for%20EBS%20to%20help%20us%20expand%20our%20clientele.%20You%20will%20be%20the%20front%20of%20the%20company%20and%20will%20have%20the%20dedication%20to%20create%20and%20apply%20an%20effective%20sales%20strategy.%3C/p%3E%3Cp%3E%3Cstrong%3EJOB%20DESCRIPTIONS%20%26nbsp%3B%3C/strong%3E%3C/p%3E%3Cul%3E%3Cli%3EIs%20responsible%20for%20sales%20consulting%20of%20EBS%u2019s%20solution%20and%20service%3C/li%3E%3Cli%3ELead%20Sales%20Consulting%20Team%20to%20develop%20marketing%20documents%20for%20main%20solution%20and%20services%20of%20EBS%3C/li%3E%3Cli%3EDevelop%20a%20growth%20strategy%20focused%20both%20on%20financial%20gain%20and%20customer%20satisfaction%3C/li%3E%3Cli%3EConduct%20research%20to%20identify%20new%20markets%20and%20customer%20needs%3C/li%3E%3Cli%3EArrange%20business%20meetings%20with%20prospective%20clients%3C/li%3E%3Cli%3EPromote%20the%20company%u2019s%20products/services%20addressing%20or%20predicting%20clients%u2019%20objectives%3C/li%3E%3Cli%3EPrepare%20sales%20contracts%20ensuring%20adherence%20to%20law-established%20rules%20and%20guidelines%3C/li%3E%3Cli%3EProvide%20trustworthy%20feedback%20and%20after-sales%20support%3C/li%3E%3Cli%3EBuild%20long-term%20relationships%20with%20new%20and%20existing%20customers%3C/li%3E%3Cli%3EDevelop%20staff%20into%20valuable%20salespeople%3C/li%3E%3C/ul%3E%3Cp%3E%3C/p%3E%3C/div%3E", Require= "%3Cp%3E%3C/p%3E%3Cul%3E%3Cli%3EBachelor%27s%20or%20Master%27s%20degree%20in%20%28Business%29%20Information%20Systems%20or%20Engineering%3C/li%3E%3Cli%3E10+%20years%20of%20experience%20with%20SAP%2C%20Finance%2C%20ERP%20etc.%3C/li%3E%3Cli%3E05+%20years%20enterprise%20level%20ERP%20project%20management%20experience%3B%20project%20management%3C/li%3E%3Cli%3E03+%20years%20in%20Consulting%3C/li%3E%3Cli%3EPrevious%20experience%20implementing%20top%20tier%20ERP%20programs%20%28SAP%2C%20Oracle%2C%20MS%20Dynamic%20365%29%20or%20other%20relevant%20manufacturing%20software.%3C/li%3E%3Cli%3EIn-dept%20knowledge%20or%20experience%20of%20implementing%20Core%20ERP%20is%20an%20advantage%3C/li%3E%3Cli%3EWorking%20experience%20in%20Big%204%20Consulting%20Companies%20or%20hands-on%20experience%20in%20ERP%20implementation%20consulting%20for%20large%20corporations.%3C/li%3E%3Cli%3EDialogue%20communication%20skills%20and%20persuasion%20skills%20towards%20C-level%20of%20enterprises.%3C/li%3E%3Cli%3EManagement%20skills%20of%20multi-national%20team%20and%20working%20for%20multi-national%20markets.%3C/li%3E%3Cli%3EExcellent%20English%20or%20Japanese%20communication%20and%20comprehension%3C/li%3E%3C/ul%3E%3Cp%3E%3C/p%3E", OtherRequire= "EBS (Enterprise Business Services) is a competency unit of FPT Software (~1000 staff) providing Core ERP (SAP, MS Dynamic 365 preferred) and surround applications together with digital transformation for big enterprises around the world.  ", RayOfPay="1,000 - 3,000 USD", PostDate=DateTime.Now, ComplateDate = DateTime.Now });
            
            

            context.RecruitJobs.AddRange(listRecruit_Job);
            context.SaveChanges();
        }

       
    }
}
