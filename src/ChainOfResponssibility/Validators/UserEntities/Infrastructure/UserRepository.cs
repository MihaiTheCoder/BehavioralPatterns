using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainOfResponssibility.Validators.UserEntities
{
    public class UserRepository
    {
        List<User> users;
        public UserRepository()
        {
            users = new List<User>();
            users.Add(new User { ID = 1, Email = "a@a.a", TenantId = 1, UserName = "a", Rights = Rights.Create | Rights.Update });
            users.Add(new User { ID = 2, Email = "b@a.a", TenantId = 1, UserName = "b", Rights = Rights.Read});
            users.Add(new User { ID = 2, Email = "c@a.a", TenantId = 2, UserName = "c", Rights = Rights.Create | Rights.Update | Rights.Read | Rights.Delete });
        }

        public User Get(string email)
        {
            return users.First(u => u.Email == email);
        }

        public bool Exists(string email)
        {
            return users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public bool Exists(int id)
        {
            return users.Any(u => u.ID == id);
        }

        public void Add(User user)
        {
            lock (users)
            {
                int maxId = users.Max(u => u.ID);
                user.ID = maxId + 1;
                users.Add(user);
            }
            
        }

        public void Update(User user)
        {
            User dbUser = users.First(u => u.ID == user.ID);

            dbUser.Email = user.Email;
            dbUser.TenantId = user.TenantId;
            dbUser.UserName = user.UserName;
        }
        
    }
}
