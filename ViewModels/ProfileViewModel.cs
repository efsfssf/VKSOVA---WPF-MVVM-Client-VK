using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestWPF.Commands;
using TestWPF.Exceptions;
using TestWPF.Messages;
using TestWPF.Models;
using TestWPF.Services;
using TestWPF.Store;
using TestWPF.VK_api;

namespace TestWPF.ViewModels
{
    public class ProfileViewModel: ViewModelBase
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

        private string? _access_token;

        public string? Access_token
        {
            get { return _access_token; }
            set
            {
                _access_token = value;
                OnPropertyChanged(nameof(Access_token));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly MessageBus _messageBus;
        public ProfileViewModel(Main main, NavigationService addUserViewNavigationService, NavigationService make, MessageBus messageBus)
		{
            _messageBus = messageBus;
            MakeUsersCommand = new NavigateCommand(make);
            // Передаем команде данные переменных этого класса, и освновной класс
            SubmitCommand = new MakeUsersCommand(this, main, addUserViewNavigationService);
			CancelCommand = new BackCommand(addUserViewNavigationService);

            /*_messageBus.Receive<TextMessage>(this, async message => {

				if (message.Text != null && message.Text != "")
				{
					Access_token = message.Text;

                }
				else
				{
                    throw new LoginConflictException(Access_token);

                }
			});*/

        }
	}
}
