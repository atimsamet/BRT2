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
    public class ProductService : IProductService
    {
        public void Create(Product entity)
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
                db.Products.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id, Product entity)
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                //product.UpdateUsername
                entity.UpdateDate = DateTime.Now;
                entity.Status = 0;
                entity.Id = id;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                return db.Products.Where(x => x.Status == 1).ToList();
            }
        }

        public void Update(int id, Product product)
        {
            using (BRTDbContext
                db = new BRTDbContext())
            {
                //product.UpdateUsername
                var guncellenecekEleman = db.Products.Find(id);
                guncellenecekEleman.ProductName = product.ProductName;
                guncellenecekEleman.Price = product.Price;
                guncellenecekEleman.UpdateDate = DateTime.Now;
               
                db.Entry(guncellenecekEleman).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
