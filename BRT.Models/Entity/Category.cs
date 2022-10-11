using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRT.Models.Entity
{
    public class Category : Base
    {
        public string CategoryName { get; set; }
        public double Discount{ get; set; }
    }
}
