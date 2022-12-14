using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestWPF.Exceptions;
using TestWPF.Models;
using TestWPF.Services;
using TestWPF.Store;
using TestWPF.ViewModels;

namespace TestWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Main _main;
        private readonly MessageBus _messageBus;
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _main = new Main("Simple app");
            _navigationStore = new NavigationStore();
            _messageBus = new MessageBus();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateUsersListingViewModel();
            _navigationStore.AddHistory(_navigationStore.CurrentViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            

            base.OnStartup(e);
            //if (Environment.OSVersion.Version.Build < 22523)
            //{
            //    MessageBox.Show("This demonstration requires Windows 11 Insider Preview build 22523 or newer.", "Incompatible Windows build", MessageBoxButton.OK, MessageBoxImage.Error);
            //    Shutdown();
            //    return;
            //}
            MainWindow.Show();
        }

        private ProfileViewModel CreateMakeUsersViewModel()
        {
            return new ProfileViewModel(_main, new NavigationService(_navigationStore, CreateUsersListingViewModel), new NavigationService(_navigationStore, CreateMakeUsersViewModel), _messageBus);
        }

        private LoginViewModel CreateUsersListingViewModel()
        {
            return new LoginViewModel(_main, new NavigationService(_navigationStore, CreateMakeUsersViewModel), _messageBus);
        }
    }
}
