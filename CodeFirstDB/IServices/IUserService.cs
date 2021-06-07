using CodeFirstDB.ViewModle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstDB.IServices
{
    public interface IUserService
    {
        IEnumerable <User> GetUser();

        User AddUser(User user);

        User UpdateUser(User user);
    }
}
