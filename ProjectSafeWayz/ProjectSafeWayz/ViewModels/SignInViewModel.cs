using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectSafeWayz.Messages;
using ProjectSafeWayz.Services.Interfaces;
using SafeWayzLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectSafeWayz.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        public INavigationService _navigationService;
        public IPageDialogService _pageDialogService;
        public IEventAggregator _eventAggregator;
        public ISecurityService _securityService;

        private UserDetails _person;
        public UserDetails Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

        public SignInViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IEventAggregator eventAggregator, ISecurityService securityService)
            : base(navigationService)
        {
            _securityService = securityService;
            _eventAggregator = eventAggregator;
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            Title = "Login";
            Person = new UserDetails();

        }

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));

        async void ExecuteLoginCommand()
        {
             if ((Person.UserName != null) && (Person.Password != null))
             {
                 var loginResult = await _securityService.Login(Person.UserName, Person.Password);

                if (loginResult)
                {
                    _eventAggregator.GetEvent<LoginMessage>().Publish();
                    await _pageDialogService.DisplayAlertAsync("Welcome", "Successful Login", "Ok");
                    await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/MainPage");
                }
                else
                    return;
             }
             else
                return;     
        }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/SignUp");
        }
    }
}
