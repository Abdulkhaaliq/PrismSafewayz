using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ProjectSafeWayz.ViewModels
{
    public class AccountPageViewModel : ViewModelBase
    {
        public IPageDialogService _pageDialogService;
        public INavigationService _navigationService;
        public AccountPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService )
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            Title = "Your Account";
        }

        private DelegateCommand _deleteAccountCommand;
        public DelegateCommand DeleteAccountCommand =>
            _deleteAccountCommand ?? (_deleteAccountCommand = new DelegateCommand(ExecuteDeleteAccountCommand));

        async void ExecuteDeleteAccountCommand()
        {
            var sure = await _pageDialogService.DisplayAlertAsync("Wait","Are you sure you want to do this?","Yes","No");
            if(sure == true)
            {
                DeleteAccount();
                await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/SignIn");
            }
            else
            {
                await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/AccountPage");
            }
           
        }

        private void DeleteAccount()
        {
            throw new NotImplementedException();
        }
    }
}
