using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestWPF.Exceptions;
using TestWPF.Models;
using TestWPF.Services;
using TestWPF.Store;
using TestWPF.ViewModels;

namespace TestWPF.Commands
{
    public class MakeUsersCommand : CommandBase
    {
        private readonly Main _main;
        private readonly NavigationService _addUserViewNavigationService;
        private ProfileViewModel _makeUsersViewModel;

        private int _count = 1;
        public MakeUsersCommand(ProfileViewModel makeUsersViewModel, Main main, NavigationService addUserViewNavigationService)
        {
            _makeUsersViewModel = makeUsersViewModel;
            _main = main;
            _addUserViewNavigationService = addUserViewNavigationService;
            _makeUsersViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ProfileViewModel.Name) ||
                e.PropertyName == nameof(ProfileViewModel.Sity)
                )
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeUsersViewModel.Name)
                && !string.IsNullOrEmpty(_makeUsersViewModel.Sity)
                && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            User user = new User(
                new IDUser(_count, _makeUsersViewModel.Sity, _makeUsersViewModel.Name, _makeUsersViewModel.Birthday),
                DateTime.Now,
                _makeUsersViewModel.Name
                );
            _count++;

            try
            {
                _main.MakeUser(user);
                _addUserViewNavigationService.Navigate();


            }
            catch(UserConflictException)
            {
                MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
