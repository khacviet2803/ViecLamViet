using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.Models
{
    public class Rolie
    {
        public Rolie()
        {
            this.ActionRoles = new HashSet<ActionRole>();
            this.MasterRoles = new HashSet<MasterRole>();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ActionRole> ActionRoles { get; set; }
        public virtual ICollection<MasterRole> MasterRoles { get; set; }
    }
}
