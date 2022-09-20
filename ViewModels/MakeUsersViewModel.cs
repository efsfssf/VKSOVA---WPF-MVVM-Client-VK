using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestWPF.Commands;
using TestWPF.Models;
using TestWPF.Services;
using TestWPF.Store;

namespace TestWPF.ViewModels
{
    public class MakeUsersViewModel: ViewModelBase
    {
		private string? _name;

		public string? Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

        public ICommand MakeUsersCommand { get; }

        private string? _sity;

		public string? Sity
		{
			get { return _sity; }
			set
			{
				_sity = value;
				OnPropertyChanged(nameof(Sity));
			}
		}

		private DateTime _birthday = DateTime.Today;

		public DateTime Birthday
		{
			get { return _birthday; }
			set
			{
				_birthday = value;
				OnPropertyChanged(nameof(Birthday));
			}
		}

		public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

		public MakeUsersViewModel(Main main, NavigationService addUserViewNavigationService, NavigationService make)
		{

            MakeUsersCommand = new NavigateCommand(make);
            // Передаем команде данные переменных этого класса, и освновной класс
            SubmitCommand = new MakeUsersCommand(this, main, addUserViewNavigationService);
			CancelCommand = new BackCommand(addUserViewNavigationService);

        }

    }
}
