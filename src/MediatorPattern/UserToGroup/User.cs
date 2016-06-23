using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.UserToGroup
{
    /// <summary>
    /// Colleague
    /// </summary>
    public class User
    {
        UsersToGroups usersToGroups;
        public User(UsersToGroups usersToGroups)
        {
            this.usersToGroups = usersToGroups;
        }
        public int ID { get; set; }

        public void AddGroup(Group g)
        {
            usersToGroups.AddUserToGroup(this, g);
        }
    }    
}
