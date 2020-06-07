using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectSafeWayz.Converters;
using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Helpers;
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;

namespace ProjectSafeWayz.ViewModels
{
    public class CommunityFeedViewModel : ViewModelBase, INavigationAware, IPageLifecycleAware
    {
        private readonly IPageDialogService _pageDialogService;

        public INavigationService _navigationService;

        private TimelineModel _reportData;
        public TimelineModel ReportData
        {
            get { return _reportData; }
            set { SetProperty(ref _reportData, value); }
        }
        public ObservableCollection<TimelineModel> Incidents { get; set; }
        public CommunityFeedViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            Title = "Community Feed";

            Incidents = new ObservableCollection<TimelineModel>
            {
                new TimelineModel { IncidentType = IncidentNames.Accident, Area = "Grassy Park", IncidentDescription = "Car hit a robot in the heap of traffic because of a taxi that lost a wheel in the middle of the road.", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Latitude = -34.040055, Longitude = 18.510534},
                new TimelineModel { IncidentType = IncidentNames.Shooting, Area = "Plumstead", IncidentDescription = "Shoot out by a local shop", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Latitude = 13.03948, Longitude = 19.39485},
                new TimelineModel { IncidentType = IncidentNames.Murder, Area = "Mananberg", IncidentDescription = "Man was shot and killed", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Latitude = 13.03948, Longitude = 19.39485},
                new TimelineModel { IncidentType = IncidentNames.Robbery, Area = "Wynberg", IncidentDescription = "local shop looted", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Latitude = 13.03948, Longitude = 19.39485},
                new TimelineModel { IncidentType = IncidentNames.Assault, Area = "Kenilworth", IncidentDescription = "Assault by a local shop", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Latitude = 13.03948, Longitude = 19.39485}
            };
        }

        private DelegateCommand _filterCommand;
        public DelegateCommand FilterCommand =>
            _filterCommand ?? (_filterCommand = new DelegateCommand(ExecuteFilterCommand));

        async void ExecuteFilterCommand()
        {
            await _navigationService.NavigateAsync("PostIncidentPage");
        }

     
        public async void OnAppearing()
        {
            try
            {
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    // Connection to internet is available
                    var stats = await ApiServices.GetIncidentReport();
                    ReportData = stats;
                }
                else
                {
                    if (current != NetworkAccess.Internet)
                    {
                        await _pageDialogService.DisplayAlertAsync("Unexpected Error", "No Interent access", "cancel", "ok");
                    }
                }
            }
            catch (Exception)
            {
               
            }
        }

        public void OnDisappearing()
        {
           
        }
    }
}
