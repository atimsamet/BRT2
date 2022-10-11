using BRT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRT.Business.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        void Create(Product entity);
        void Delete(int id, Product entity);
        void Update(int id, Product entity);
    }
}
