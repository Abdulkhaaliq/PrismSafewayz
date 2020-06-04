using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectSafeWayz.ViewModels
{
    public class CommunityFeedViewModel : ViewModelBase, INavigationAware
    {
        public INavigationService _navigationService;
        public ObservableCollection<TimelineModel> Incidents { get; set; }
        public CommunityFeedViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Community Feed";

            Incidents = new ObservableCollection<TimelineModel>
            {
                new TimelineModel { IncidentType = "Accident", Area = "Grassy Park", IncidentDescription = "Car hit a robot in the heap of traffic because of a taxi that lost a wheel in the middle of the road.", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Location = "1 Lilydale Road Lotus River"},
                new TimelineModel { IncidentType = "Shooting", Area = "Plumstead", IncidentDescription = "Shoot out by a local shop", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Location = "42 Milford Rd, Plumstead"},
                new TimelineModel { IncidentType = "Murder", Area = "Mananberg", IncidentDescription = "Man was shot and killed", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Location = "41 Thames Walk, Manenberg"},
                new TimelineModel { IncidentType = "Robbery", Area = "Wynberg", IncidentDescription = "local shop looted", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Location = "2 Brisbane Rd, Wynberg"},
                new TimelineModel { IncidentType = "Assault", Area = "Kenilworth", IncidentDescription = "Assault by a local shop", TimeOfIncident = DateTime.Now, Image = null, CreatedBy = "Anonymous", Location = "15 Penrith Rd, Kenilworth"}
            };
        }

        private DelegateCommand _filterCommand;
        public DelegateCommand FilterCommand =>
            _filterCommand ?? (_filterCommand = new DelegateCommand(ExecuteFilterCommand));

        async void ExecuteFilterCommand()
        {
            await _navigationService.NavigateAsync("FilterPage");
        }

        private DelegateCommand _postCommand;
        public DelegateCommand PostCommand =>
            _postCommand ?? (_postCommand = new DelegateCommand(ExecutePostCommand));

        public async void ExecutePostCommand()
        {
            await _navigationService.NavigateAsync("Report");
        }

    }
}
