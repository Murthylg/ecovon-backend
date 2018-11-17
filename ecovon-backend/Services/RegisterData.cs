using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecovon_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ecovon_backend.Services
{
    public interface IRegisterData
    {
        IEnumerable<Login> GetAllLogin();
        IEnumerable<User> GetAllUser();
        User Get(int id);
        Login Gets(int id);
        void Update(User user);
        void Update(Login user);
        void Commit();
    }

    public class sqlIRegisterData : IRegisterData
    {
        private ecovondbcontext _context;

        public sqlIRegisterData(ecovondbcontext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public User Get(int id)
        {
            return _context.User.FirstOrDefault(r => r.UserId == id);
        }

        public IEnumerable<Login> GetAllLogin()
        {
            return _context.Login;
        }
        public void Update(User model)
        {
             _context.User.Update(model);
        }

        public void Update(Login model)
        {
            _context.Login.Update(model);
        }

        public Login Gets(int id)
        {
            return _context.Login.FirstOrDefault(r => r.UserId == id);
        }

        IEnumerable<User> IRegisterData.GetAllUser()
        {

            return _context.User.Select(r => r).Include(a => a.UserRoleDetails).Include(a => a.CustomerDetails);
        }
    }

    
}
