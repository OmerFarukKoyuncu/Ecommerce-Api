using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Content : BaseEntity
    {
        public string PageName { get; set; }
        public string ContentText { get; set; }
    }
}
