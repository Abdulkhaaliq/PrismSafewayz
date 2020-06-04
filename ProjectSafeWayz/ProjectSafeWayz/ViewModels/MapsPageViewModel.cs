using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjectSafeWayz.Models;
using ProjectSafeWayz.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace ProjectSafeWayz.ViewModels
{
    public class MapsPageViewModel : ViewModelBase
    {
        private IMappingService _mappingService;

        public Map Map { get; set; }

        readonly ObservableCollection<Location> _locations;

        public IEnumerable Locations => _locations;

        public INavigationService _navigationService;
        public MapsPageViewModel(INavigationService navigationService, IMappingService mapping)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Map";
            _mappingService = mapping;
        }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

       async void ExecuteNavigateCommand()
       {
            await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/CommunityFeed");
       }

        private DelegateCommand _exploreCommand;
        public DelegateCommand ExploreCommand =>
            _exploreCommand ?? (_exploreCommand = new DelegateCommand(ExecuteExploreCommand));

        async void ExecuteExploreCommand()
        {
            await _navigationService.NavigateAsync("ExplorePage");
        }
    }
}