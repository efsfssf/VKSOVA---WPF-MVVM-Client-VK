using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Models
{
    public class User
    {
        public IDUser IDUser { get; }
        public string? Name { get; }
        public DateTime LastSeen { get; }
        public User(IDUser iDUser, DateTime lastSeen, string? name)
        {
            IDUser = iDUser;
            LastSeen = lastSeen;
            Name = name;
        }

        internal bool Conflicts(User user)
        {
            if (user.IDUser != IDUser)
                return false;

            return true;
        }
    }
}
