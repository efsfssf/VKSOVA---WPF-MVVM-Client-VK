using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.DTOs;
using TestWPF.VK_api;

namespace TestWPF.Services
{
    public class LoginService
    {
        private readonly string _login;
        private readonly string _password;
        private readonly IAPIService _APIService;

        public static LoginService Load(IAPIService aPIService, string login, string password)
        {
            LoginService loginService = new LoginService(login, password, aPIService);
            loginService.authorization();
            return loginService;
        }

        private DataDTO _loginResponse;
        public DataDTO LoginResponse
        {
            get
            {
                return _loginResponse;
            }
            set
            {
                _loginResponse = value;
                OnPropertyChanged(nameof(LoginResponse));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoginService(string login, string password, IAPIService aPIService)
        {
            _login = login;
            _password = password;
            _APIService = aPIService;
        }

        public void authorization()
        {
            _APIService.GetAPIService(_login, _password).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    LoginResponse = task.Result;
                }
            });
        }

    }
}
