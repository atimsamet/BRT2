using BRT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRT.Business.Interface
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        void Create(Category entity);
        void Delete(int id, Category entity);
        void Update(int id, Category entity);
    }
}
