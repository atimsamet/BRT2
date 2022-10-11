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
    public class LoginService : ILoginService
    {
        public void Create(Login entity)
        {
            using (BRTDbContext db = new BRTDbContext())
            {               
                entity.CreateDate = DateTime.Now;
                entity.Status = 1;
                entity.UpdateDate = DateTime.Now;
                //entity.CreateUsername = entity.Username;
                db.Logins.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id, Login entity)
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

        public List<Login> GetAllUsers()
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                return db.Logins.Where(x => x.Status == 1).ToList();
            }
        }

        public void Update(int id, Login entity)
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                //product.UpdateUsername
                var guncellenecekEleman = db.Logins.Find(id);
                guncellenecekEleman.Username = entity.Username;
                guncellenecekEleman.Password = entity.Password;
                guncellenecekEleman.UpdateDate = DateTime.Now;
               
                db.Entry(guncellenecekEleman).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
