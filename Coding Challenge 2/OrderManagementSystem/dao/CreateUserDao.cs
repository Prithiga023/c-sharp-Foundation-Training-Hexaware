using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.dao;
using OrderManagementSystem.Entity;

namespace Order_Management_System.dao
{
    public class CreateUserDao : ICreateUserDao
    {
        public bool CreateUser(User user)
        {
            Console.WriteLine($"[CreateUserDao] User created: {user.Username}");
            return true;
        }
    }
}
