using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Models
{
    public class Main
    {
        private readonly Users_List _users_list;

        // Название
        public string Name { get; }

        // инициализация
        public Main(string name)
        {
            Name = name;

            _users_list = new Users_List();
        }
        public IEnumerable<User> GetForUser(string name)
        {
            return _users_list.GetForUser(name);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users_list.GetAllUsers();
        }

        public void MakeUser(User user)
        {
            _users_list.AddUsers(user);
        }

    }
}
