using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using ProjectSafeWayz.Messages;
using ProjectSafeWayz.Services.Interfaces;
using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectSafeWayz.ViewModels
{
    public class SWMasterDetailPageViewModel : ViewModelBase
    {
        private ISecurityService _securityService;
        private IEventAggregator _eventAggregator;
        private DelegateCommand<MenuItem> _navigateCommand;
        private ObservableCollection<MenuItem> _menuItems;
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }
        public DelegateCommand<MenuItem> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<MenuItem>(ExecuteNavigateCommand));
        public async void ExecuteNavigateCommand(MenuItem menu)
        {
            if (menu.MenuType == MenuTypeEnum.LogOut)
                _securityService.LogOut();
            else
                await NavigationService.NavigateAsync(menu.NavigationPath);
        }
        public SWMasterDetailPageViewModel(INavigationService navigationService, ISecurityService securityService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            Title = "Menu";
            _securityService = securityService;
            _eventAggregator = eventAggregator;
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());

            _eventAggregator.GetEvent<LoginMessage>().Subscribe(LoginEvent);

            _eventAggregator.GetEvent<LogoutMessage>().Subscribe(LogOutEvent);
        }
        public async void LoginEvent()
        {
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());
            await NavigationService.NavigateAsync("SWMasterDetailPage/NavigationPage/MainPage");
        }
        public async void LogOutEvent()
        {
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());
            await NavigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/SignIn");
        }
    }
}