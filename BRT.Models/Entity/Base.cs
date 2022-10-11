using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRT.Models.Entity
{
    public class Base
    {
        public int Id{ get; set; }
        public string CreateUsername{ get; set; }
        public DateTime CreateDate{ get; set; }
        public string UpdateUsername { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status{ get; set; }
    }
}
