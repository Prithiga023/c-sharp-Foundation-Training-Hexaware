using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;

namespace OrderManagementSystem.dao
{
    public interface ICreateUserDao
    {
        bool CreateUser(User user);
    }
}
