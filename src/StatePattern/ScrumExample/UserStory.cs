using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatePattern.ScrumExample
{
    public class UserStoryMotivational
    {
        public String Name { get; set; }
        public UserStoryState State { get; set; }
    }
}
