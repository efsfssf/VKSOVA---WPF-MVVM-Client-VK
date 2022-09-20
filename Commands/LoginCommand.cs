using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Services;
using TestWPF.ViewModels;
using TestWPF.VK_api;

namespace TestWPF.Commands
{
    class LoginCommand : CommandBase 
    {
        private readonly NavigationService _navigationService;
        private UsersListingViewModel _usersListing;
        private LoginService _loginService { get; set; }

        public LoginCommand(UsersListingViewModel usersListing, NavigationService navigationService)
        {
            _usersListing = usersListing;
            _navigationService = navigationService;
            _usersListing.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UsersListingViewModel.Login) ||
                e.PropertyName == nameof(UsersListingViewModel.Password)
                )
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_usersListing.Login)
                && !string.IsNullOrEmpty(_usersListing.Password)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _loginService = LoginService.Load(new Login(), _usersListing.Login, _usersListing.Password);
            _loginService.PropertyChanged += OnGetToken;
        }

        private void OnGetToken(object? sender, PropertyChangedEventArgs e)
        {
            _navigationService.Login(_loginService.LoginResponse.access_token);
        }
    }
}
