using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Для обновления частей интерфейса
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void DoTabRequest(string v);
    }
}
