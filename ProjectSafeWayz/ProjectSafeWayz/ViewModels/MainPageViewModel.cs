using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjectSafeWayz.Models;
using ProjectSafeWayz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace ProjectSafeWayz.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INavigatedAware
    {
        public IPageDialogService _pageDialogService;
        private IMappingService _mappingService;

        public Xamarin.Forms.Maps.Map Map { get; set; }

        public readonly ObservableCollection<Position> Location;
        public INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService, IMappingService mapping, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            Title = "Map";
            _mappingService = mapping;
            Map = new Xamarin.Forms.Maps.Map();
        }

        private DelegateCommand _selectLocationComand;
        public DelegateCommand SelectLocationComand =>
            _selectLocationComand ?? (_selectLocationComand = new DelegateCommand(ExecuteSelectLocationComand));

        async void ExecuteSelectLocationComand()
        {
            var pos = Map.VisibleRegion.Center;
            var placemarks = await Geocoding.GetPlacemarksAsync(pos.Latitude, pos.Longitude);

            var placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
                bool location = await _pageDialogService.DisplayAlertAsync("Is this the correct location?", $"{placemark.FeatureName} {placemark.Thoroughfare} {placemark.SubAdminArea}", "Yes", "No");
                if (location == true)
                {
                    await _navigationService.NavigateAsync("PostIncidentPage");
                }
            }
            else
            {
                return;
            }
        }
           
    }
}