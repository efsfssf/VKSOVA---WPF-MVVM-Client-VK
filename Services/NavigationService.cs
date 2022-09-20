using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Store;
using TestWPF.ViewModels;

namespace TestWPF.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;
        public ViewModelBase last;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
            _navigationStore.AddHistory(_navigationStore.CurrentViewModel);
        }

        public void Login(string access_token)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }


        public void GetLastViewModel()
        {
            _navigationStore.CurrentViewModel = _navigationStore.History[_navigationStore.History.Count - 2];
            _navigationStore.History.RemoveAt(_navigationStore.History.Count - 1);
        }


    }
}
