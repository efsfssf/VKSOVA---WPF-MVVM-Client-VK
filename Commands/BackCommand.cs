using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Services;

namespace TestWPF.Commands
{
    internal class BackCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public BackCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.GetLastViewModel();
        }
    }
}
