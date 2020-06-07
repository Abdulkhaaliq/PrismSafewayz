using Prism;
using Prism.Ioc;
using ProjectSafeWayz.ViewModels;
using ProjectSafeWayz.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjectSafeWayz.Services.Interfaces;
using ProjectSafeWayz.Services;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProjectSafeWayz
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            VersionTracking.Track();
            //This states if it is the first time a user launched the app
            if(VersionTracking.IsFirstLaunchEver)
            {
           
                await NavigationService.NavigateAsync("SWMasterDetailPage/NavigationPage/SignUp");
            }
            else
            {
                await NavigationService.NavigateAsync("SWMasterDetailPage/NavigationPage/MapsPage");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<ISecurityService, SercurityService>();
            containerRegistry.RegisterSingleton<IService, IncidentsService>();
            containerRegistry.RegisterSingleton<IMappingService, MappingService>();
        


            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutUs, AboutUsViewModel>();
            containerRegistry.RegisterForNavigation<CommunityFeed, CommunityFeedViewModel>();
            containerRegistry.RegisterForNavigation<FilterPage, FilterPageViewModel>();
            containerRegistry.RegisterForNavigation<PostDetails, PostDetailsViewModel>();
            containerRegistry.RegisterForNavigation<SignIn, SignInViewModel>();
            containerRegistry.RegisterForNavigation<SignUp, SignUpViewModel>();
            containerRegistry.RegisterForNavigation<SWMasterDetailPage, SWMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterForNavigation<AccountPage, AccountPageViewModel>();
            containerRegistry.RegisterForNavigation<MapsPage, MapsPageViewModel>();
            containerRegistry.RegisterForNavigation<ExplorePage, ExplorePageViewModel>();
            containerRegistry.RegisterForNavigation<PostIncidentPage, PostIncidentPageViewModel>();
        }
    }
}
