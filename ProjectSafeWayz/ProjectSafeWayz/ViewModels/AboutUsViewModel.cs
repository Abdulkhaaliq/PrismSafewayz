using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ProjectSafeWayz.ViewModels
{
    public class AboutUsViewModel : ViewModelBase
    {
        public INavigationService _navigationService;
        public AboutUsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "About Us";


        }
    }
}
