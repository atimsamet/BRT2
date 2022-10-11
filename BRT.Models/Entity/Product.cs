using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRT.Models.Entity
{
    public class Product : Base
    {
        public string ProductName { get; set; }
        public double Price{ get; set; }
        public Category Category{ get; set; }
    }
}
