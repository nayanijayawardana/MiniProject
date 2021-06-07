using CodeFirstDB.DataLayer;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstDB.Services
{
    public class UserService : IUserService
    {

        VotingDbContext dbcontext;

        public UserService(VotingDbContext _db)
        {
            dbcontext = _db;
        }

        public IEnumerable<User> GetUser()
        {
            var user = dbcontext.Users.ToList();
            return user;

        }

        public User AddUser(User user)
        {
            if (user != null)
            {
                dbcontext.Users.Add(user);
                dbcontext.SaveChanges();
                return user;
            }

            return null;
        }

        public User UpdateUser(User user)
        {
            dbcontext.Entry(user).State = EntityState.Modified;
            dbcontext.SaveChanges();
            return user;
        }
    }

}


