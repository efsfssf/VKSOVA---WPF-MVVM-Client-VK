using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Exceptions;

namespace TestWPF.Models
{
    public class Users_List
    {
        private readonly List<User> _users;

        public Users_List()
        {
            _users = new List<User>();
        }

        public IEnumerable<User> GetForUser(string name)
        {
            return _users.Where(x => x.Name == name);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public void AddUsers(User user)
        {
            foreach (User item in _users)
            {
                if(item.Conflicts(user))
                {
                    throw new UserConflictException(item, user);
                }
            }
            _users.Add(user);
        }
    }
}
