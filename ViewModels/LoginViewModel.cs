using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Input;
using TestWPF.Commands;
using TestWPF.Models;
using TestWPF.Services;
using TestWPF.VK_api;


namespace TestWPF.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {

        private string? _access_token;

        public string? Access_token
        {
            get { return _access_token; }
            set { _access_token = value; OnPropertyChanged(nameof(Access_token)); }
        }


        private Uri _myHtml = new Uri("https://oauth.vk.com/oauth/authorize?client_id=6287487&scope=1073737727&redirect_uri=https://oauth.vk.com/blank.html&display=page&response_type=token&revoke=1&slogin_h=014ae5c74d0a338000.214c01f8758939be21&__q_hash=3c1309ef7a01fe35b4065000919c77fc");

        public Uri MyHtml
        {
            get { return _myHtml; }
            set
            {
                _myHtml = value;
                CheckUri(MyHtml);
                OnPropertyChanged();
                OnPropertyChanged(nameof(MyHtml));
            }
        }


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

        private Visibility _visibility;
        public Visibility VisibilityWeb
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;

                OnPropertyChanged("VisibilityWeb");
            }
        }

        private readonly Main _main;
        private readonly ObservableCollection<UserViewModel> _users;

        public ICommand loginAppCommand { get; }

        public IEnumerable<UserViewModel> Users => _users;

        public LoginViewModel(Main main, NavigationService makeUsersViewModel, MessageBus messageBus)
        {
            if (main != null)
            {
                _main = main;
                _users = new ObservableCollection<UserViewModel>();

                loginAppCommand = new LoginCommand(this, makeUsersViewModel, messageBus);

                //MyHtml = new Uri("https://oauth.vk.com/oauth/authorize?client_id=6287487&scope=1073737727&redirect_uri=https://oauth.vk.com/blank.html&display=page&response_type=token&revoke=1&slogin_h=014ae5c74d0a338000.214c01f8758939be21&__q_hash=3c1309ef7a01fe35b4065000919c77fc");

                UpdateUsers();
            }
            
        }

        public string CheckUri(Uri prop)
        {
            string qs = HttpUtility.HtmlDecode(prop.ToString());
            //var parsedACC = HttpUtility.ParseQueryString(qs).Get("https://oauth.vk.com/blank.html#access_token");
            var parsedACC = HttpUtility.ParseQueryString(qs).Get("https://oauth.vk.com/oauth/authorize?client_id");
            if (parsedACC != null)
            {
                Access_token = parsedACC;
                VisibilityWeb = Visibility.Hidden;
            }

            return parsedACC;
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
