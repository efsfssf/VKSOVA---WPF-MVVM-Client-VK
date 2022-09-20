using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Models;

namespace TestWPF.ViewModels
{
    public class UserViewModel
    {
        private readonly User _user;

        public string? IDUser => _user.IDUser?.ToString();
        public string? Name => _user.Name;
        public DateTime LastSeen => _user.LastSeen.Date;

        public UserViewModel(User user)
        {
            _user = user;
        }
    }
}
