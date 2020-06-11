using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace ProjectSafeWayz.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        public INavigationService _navigationService;
        public IPageDialogService _pageDialogService;

        private UsersModel _person;
        public UsersModel Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

        public SignUpViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {

            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            Title = "Register";
            Person = new UsersModel();
        }
        private DelegateCommand _uriCommand;
        public DelegateCommand UriCommand =>
            _uriCommand ?? (_uriCommand = new DelegateCommand(ExecuteUriCommand));

        async void ExecuteUriCommand()
        {
            await Browser.OpenAsync(new Uri("https://xamarin.com"));
        }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/SignIn");
        }

        private DelegateCommand _signupCommand;
        public DelegateCommand SignupCommand =>
            _signupCommand ?? (_signupCommand = new DelegateCommand(ExecuteSignupCommand));

        async void ExecuteSignupCommand()
        {
             if ((Person.UserName == null && Person.Email == null && Person.Password == null))
             {
                 await _pageDialogService.DisplayAlertAsync("Error", "Please fill in all your details", "ok");
             }
             else
             {
                 var response = await _pageDialogService.DisplayAlertAsync("T&C", "If you accept the t&c's you may create this account", "accept", "cancel");

                 if (response == false)
                 {
                     await _navigationService.NavigateAsync("myapp:///MenuMasterDetail/NavigationPage/SignUpPage");
                 }
                 else
                 {
                     Post();
            await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/SignIn");
            }

        }
        }

        public async void Post()
        {
            var client = new HttpClient();
            var url = "https://10.0.2.2:5000/api/UserDetails";
            try
            {

                var json = JsonConvert.SerializeObject(Person);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

            }
            catch (Exception)
            {
                await _pageDialogService.DisplayAlertAsync("Try Again", "Please enter your correct details", "Ok");
            }
        }
    }
}
