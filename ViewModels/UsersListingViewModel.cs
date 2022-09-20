using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestWPF.Commands;
using TestWPF.Models;
using TestWPF.Services;
using TestWPF.VK_api;


namespace TestWPF.ViewModels
{
    public class UsersListingViewModel: ViewModelBase
    {

        private string? _login;

        public string? Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string? _password;

        public string? Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private readonly Main _main;
        private readonly ObservableCollection<UserViewModel> _users;

        public ICommand loginAppCommand { get; }

        public IEnumerable<UserViewModel> Users => _users;

        public UsersListingViewModel(Main main, NavigationService makeUsersViewModel)
        {
            _main = main;
            _users = new ObservableCollection<UserViewModel>();

            loginAppCommand = new LoginCommand(this, makeUsersViewModel);

            UpdateUsers();
        }

        private void UpdateUsers()
        {
            _users.Clear();

            foreach (User user in _main.GetAllUsers())
            {
                UserViewModel userViewModel = new UserViewModel(user);
                _users.Add(userViewModel);
            }
        }
    }
}
