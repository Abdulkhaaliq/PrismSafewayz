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
using Xamarin.Forms.Maps;

namespace ProjectSafeWayz.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public IPageDialogService _pageDialogService;
        private IMappingService _mappingService;

        public Map Map { get; set; }

        public readonly ObservableCollection<Position> Location;
        public INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService, IMappingService mapping, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            Title = "Map";
            _mappingService = mapping;
            Map = new Map();
        }
    }
}