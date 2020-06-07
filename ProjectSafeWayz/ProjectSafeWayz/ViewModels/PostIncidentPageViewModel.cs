using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectSafeWayz.ViewModels
{
    public class PostIncidentPageViewModel : ViewModelBase
    {
        public INavigationService _navigationService;
        public IPageDialogService _pageDialogService;
        public List<string> IncidentTypes { get; set; }
        public PostIncidentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            Title = "Report";
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        
            
            IncidentTypes = Enum.GetNames(typeof(IncidentNames)).ToList();

        }

        private DelegateCommand _selectLocationCommand;
        public DelegateCommand SelectLocationCommand =>
            _selectLocationCommand ?? (_selectLocationCommand = new DelegateCommand(ExecuteSelectLocationCommand));

        async void ExecuteSelectLocationCommand()
        {
            await _navigationService.NavigateAsync("MainPage");
        }
    }
}
