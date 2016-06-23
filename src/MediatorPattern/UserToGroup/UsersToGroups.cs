using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.UserToGroup
{
    /// <summary>
    /// Mediator
    /// </summary>
    public class UsersToGroups
    {
        List<Tuple<User, Group>> usersToGroups;

        public UsersToGroups()
        {
            usersToGroups = new List<Tuple<User, Group>>();
            
        }

        public void AddUserToGroup(User user, Group group)
        {
            if (!usersToGroups.Any(ug => ug.Item1.ID == user.ID && ug.Item2.ID == group.ID))
                usersToGroups.Add(new Tuple<User, Group>(user, group));
        }

        public void RemoveUserFromGroup(User user, Group group)
        {
            usersToGroups.RemoveAll(t => t.Item1.ID == user.ID && t.Item2.ID == group.ID);
        }

    }
}
