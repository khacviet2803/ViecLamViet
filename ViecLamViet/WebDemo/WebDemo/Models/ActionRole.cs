using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.Models
{
    public class ActionRole
    {
        [Key]
        public int Id { get; set; }
        public string RolieId { get; set; }
        public int WebActionId { get; set; }

        public virtual WebAction WebAction { get; set; }
        public virtual Rolie Rolie { get; set; }
    }
}
