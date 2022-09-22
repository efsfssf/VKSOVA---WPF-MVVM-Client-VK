using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Messages;
using TestWPF.Services;
using TestWPF.ViewModels;
using TestWPF.VK_api;

namespace TestWPF.Commands
{
    class LoginCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private LoginViewModel _usersListing;
        private LoginService _loginService { get; set; }

        private MessageBus _messageBus;
        private readonly string _access_token;

        public LoginCommand(LoginViewModel usersListing, NavigationService navigationService, MessageBus messageBus)
        {
            _usersListing = usersListing;
            _navigationService = navigationService;
            _usersListing.PropertyChanged += OnViewModelPropertyChanged;
            _messageBus = messageBus;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.Login) ||
                e.PropertyName == nameof(LoginViewModel.Password) ||
                e.PropertyName == nameof(LoginViewModel.Access_token)
                )
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_usersListing.Login)
                && !string.IsNullOrEmpty(_usersListing.Password)
                || !string.IsNullOrEmpty(_usersListing.Access_token)
                && base.CanExecute(parameter);
        }

        public async override void Execute(object? parameter)
        {
            /*_loginService = LoginService.Load(new Login(), _usersListing.Login, _usersListing.Password);
            _loginService.PropertyChanged += OnGetToken;*/
            _navigationService.Login();
            //await _messageBus.SendTo<ProfileViewModel>(new TextMessage(_usersListing.Access_token));
        }

        /*private async void OnGetToken(object? sender, PropertyChangedEventArgs e)
        {
            _navigationService.Login();
            await _messageBus.SendTo<ProfileViewModel>(new TextMessage(_loginService.LoginResponse.access_token));

            
        }*/
    }
}
