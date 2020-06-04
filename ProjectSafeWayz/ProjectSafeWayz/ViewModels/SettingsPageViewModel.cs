using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectSafeWayz.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public INavigationService _navigationService;
        public SettingsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Settings";
        }

        private DelegateCommand _notificationCommand;
        public DelegateCommand NotificationCommand =>
            _notificationCommand ?? (_notificationCommand = new DelegateCommand(ExecuteNotificationCommand));

        async void ExecuteNotificationCommand()
        {
            await _navigationService.NavigateAsync("NotificationPage");
        }

        private DelegateCommand _filterCommand;
        public DelegateCommand FilterCommand =>
            _filterCommand ?? (_filterCommand = new DelegateCommand(ExecuteFilterCommand));

        async void ExecuteFilterCommand()
        {
            await _navigationService.NavigateAsync("FilterPage");
        }

        private DelegateCommand _accountCommand;
        public DelegateCommand AccountCommand =>
            _accountCommand ?? (_accountCommand = new DelegateCommand(ExecuteAccountCommand));

        async void ExecuteAccountCommand()
        {
            await _navigationService.NavigateAsync("AccountPage");
        }
    }
}
