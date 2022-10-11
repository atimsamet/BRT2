using BRT.Business.Interface;
using BRT.DataAccess;
using BRT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace BRT.Business.Services
{
    public class CategoryService : ICategoryService
    {
        public void Create(Category entity)
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                //if (string.IsNullOrEmpty(entity.ProductName))
                //{
                //    return;
                //}
                entity.CreateDate = DateTime.Now;
                entity.Status = 1;
                entity.UpdateDate = DateTime.Now;
                //entity.CreateUsername =
                db.Categories.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id, Category entity)
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                //category.UpdateUsername
                entity.UpdateDate = DateTime.Now;
                entity.Status = 0;
                entity.Id = id;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                return db.Categories.Where(x => x.Status == 1).ToList();
            }
        }

        public void Update(int id, Category entity)
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                //product.UpdateUsername

                var guncellenecekEleman = db.Categories.Find(id);
                guncellenecekEleman.CategoryName = entity.CategoryName;
                guncellenecekEleman.Discount = entity.Discount;
                guncellenecekEleman.UpdateDate = DateTime.Now; 

                db.Entry(guncellenecekEleman).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
