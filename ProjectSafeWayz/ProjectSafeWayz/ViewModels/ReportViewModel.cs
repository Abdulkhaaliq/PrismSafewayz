using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectSafeWayz.ViewModels
{
    public class ReportViewModel : ViewModelBase
    {
        public IPageDialogService _pageDialogService;
        public INavigationService _navigationService;

        //  public IPageDialogService _pageDialogService;
        /*   private TimelineModel _report;
         public List<IncidentTypes> IncidentList { get; set; }
         public TimelineModel Report
         {
             get { return _report; }
            set { SetProperty(ref _report, value); }
         }8*/

        public ReportViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
             _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            Title = "Report";
            //   Report = new TimelineModel();

            //   IncidentList = GetIncidentTypes().OrderBy(t => t.IncidentName).ToList();
        }

        private DelegateCommand _findLocationCommand;
        public DelegateCommand FindLocationCommand =>
            _findLocationCommand ?? (_findLocationCommand = new DelegateCommand(ExecuteFindLocationCommand));

        async void ExecuteFindLocationCommand()
        {
            await _navigationService.NavigateAsync("MainPage");
        }

        private DelegateCommand _postReportCommand;
         public DelegateCommand PostReportCommand =>
          _postReportCommand ?? (_postReportCommand = new DelegateCommand(ExecutePostReportCommand));

         async void ExecutePostReportCommand()
         {
       //  if (Report.Location != null && Report.IncidentType != null && Report.IncidentDescription != null)
       // {
          bool valid = await _pageDialogService.DisplayAlertAsync("Attention", "Are you sure all information is correct?", "Yes", "No");
             if (valid == true)
             {
       //  PostReport();*/
               await _navigationService.NavigateAsync("myapp:///SWMasterDetailPage/NavigationPage/CommunityFeed");
             }
             else
              return;
         }
        // else
        // return;*/



        /*  public async void PostReport()
         {
             var client = new HttpClient();
             var url = "https://10.0.2.2:5000/api/IncidentReport";
             try
             {

                 var json = JsonConvert.SerializeObject(Report);
                 var content = new StringContent(json, Encoding.UTF8, "application/json");
                 var response = await client.PostAsync(url, content);

             }
             catch (Exception)
             {
                // await _pageDialogService.DisplayAlertAsync("Error", "Please make sure you entered all fields", "Ok");
             }*/
        //   }

        /* public List<IncidentTypes> GetIncidentTypes()
         {
             var types = new List<IncidentTypes>()
             {
                 new IncidentTypes(){ IncidentName = "Accident"},
                  new IncidentTypes(){ IncidentName = "Robbery"},
                   new IncidentTypes(){ IncidentName = "Murder"},
                    new IncidentTypes(){ IncidentName = "Shooting"},
                     new IncidentTypes(){ IncidentName = "Assault"}
             };

             return types;
         }*/

    }
}

