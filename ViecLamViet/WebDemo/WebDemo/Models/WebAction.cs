using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.Models
{
    public class WebAction
    {
        public WebAction()
        {
            this.ActionRoles = new HashSet<ActionRole>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ActionRole> ActionRoles { get; set; }
    }
}
