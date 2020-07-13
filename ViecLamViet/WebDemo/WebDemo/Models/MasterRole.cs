using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.Models
{
    public class MasterRole
    {
        [Key]
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string RolieId { get; set; }

        public virtual Rolie Rolie { get; set; }
        public virtual Master Master { get; set; }
    }
}
