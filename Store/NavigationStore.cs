using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.ViewModels;

namespace TestWPF.Store
{
    public class NavigationStore
    {
        private ViewModelBase? _currentViewModel;
        private IList<ViewModelBase>? _history = new List<ViewModelBase>();
        public IList<ViewModelBase> History
        {
            get { return _history; }
            set
            {
                _history = value;
            }
        }
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public void AddHistory(ViewModelBase VM)
        {
            History.Add(VM);
        }
    }
}
