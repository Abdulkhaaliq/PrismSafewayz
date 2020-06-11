using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectSafeWayz.Models;
using System.Net.Http;
using ProjectSafeWayz.Helpers;
using Unity.Injection;

namespace ProjectSafeWayz.ViewModels
{
    public class PostIncidentPageViewModel : ViewModelBase
    {
        public ApiServices _apiServices;
        public INavigationService _navigationService;
        public IPageDialogService _pageDialogService;

        private IncidentReportModel _report;
        public IncidentReportModel Report
        {
            get { return _report; }
            set { SetProperty(ref _report, value); }
        }

        public List<string> IncidentTypes { get; set; }
        public PostIncidentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            Title = "Report";
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        
            
            IncidentTypes = Enum.GetNames(typeof(IncidentNames)).ToList();
            Report = new IncidentReportModel();
            Report.IncidentType = _selectedIncidentType;
        }

        private DelegateCommand _selectLocationCommand;
        public DelegateCommand SelectLocationCommand =>
            _selectLocationCommand ?? (_selectLocationCommand = new DelegateCommand(ExecuteSelectLocationCommand));

        async void ExecuteSelectLocationCommand()
        {
            await _navigationService.NavigateAsync("MainPage");
        }

        private DelegateCommand _cancelCommand;
        public DelegateCommand CancelCommand =>
            _cancelCommand ?? (_cancelCommand = new DelegateCommand(ExecuteCancelCommand));

        async void ExecuteCancelCommand()
        {
            await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/CommunityFeed");
        }

        private DelegateCommand _postCommand;
        public DelegateCommand PostCommand =>
            _postCommand ?? (_postCommand = new DelegateCommand(ExecutePostCommand));

        async void ExecutePostCommand()
        {
            bool valid = await _pageDialogService.DisplayAlertAsync("Verify", "Are you sure all details are true?","Yes","No");
            if(valid == true)
            {
                    if (Report.IncidentDescription != null)
                    {
                       // ReportIncident();
                        await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/CommunityFeed");
                    }
                    else
                    {
                        await _pageDialogService.DisplayAlertAsync("Invalid", "Please fill in all fields", "Ok");
                    }
            }
        }

        public async void ReportIncident()
        {
            await _apiServices.PostReport(Report);
        }

        private IncidentNames _selectedIncidentType;
        public IncidentNames SelectedIncidentType
        {
            get { return _selectedIncidentType; }
            set
            {
                if (_selectedIncidentType != value)
                {
                    SetProperty(ref _selectedIncidentType, value);
                }
            }
        }
    }
}
