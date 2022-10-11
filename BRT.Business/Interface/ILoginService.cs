using BRT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRT.Business.Interface
{
    public interface ILoginService
    {
        List<Login> GetAllUsers();
        void Create(Login entity);
        void Delete(int id, Login entity);
        void Update(int id, Login entity);
    }
}
