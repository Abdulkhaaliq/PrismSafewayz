using Newtonsoft.Json;
using Prism.Events;
using Prism.Services;
using ProjectSafeWayz.Messages;
using ProjectSafeWayz.Services.Interfaces;
using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSafeWayz.Services
{
    public class SercurityService : ISecurityService
    {
        private IEventAggregator _eventAggregator;
        public IList<MenuItem> _allMenuItems;

        public IPageDialogService _pageDialogService;

        public UserDetails userDetails;
        public bool LoggedIn { get; set; }

        public SercurityService(IEventAggregator eventAggregator)
        {
            CreateMenuItems();

            _eventAggregator = eventAggregator;

        }

        public IList<MenuItem> GetAllowedAccessItems()
        {
            LoggedIn = true;

            if (LoggedIn)
            {
                var accessItems = new List<MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.Secured || item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.LogOut)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
            else
            {
                var accessItems = new List<MenuItem>();

                foreach (var item in _allMenuItems)
                {
                    if (item.MenuType == MenuTypeEnum.UnSecured || item.MenuType == MenuTypeEnum.Login)
                    {
                        accessItems.Add(item);
                    }
                }

                return accessItems.OrderBy(x => x.MenuOrder).ToList();
            }
        }

        public async Task<bool> Login(string username, string password)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://10.0.2.2:5000/api/UserDetails/{username}/{password}");

            try
            {
                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject(content);
                var login = json.ToString();
                if (login.Contains(username) && login.Contains(password))
                {
                    LoggedIn = true;
                }
                return true;
            }
            catch (Exception)
            {

            }

            return false;

        }

        public void LogOut()
        {
            LoggedIn = false;

            _eventAggregator.GetEvent<LogoutMessage>().Publish();
        }

        private void CreateMenuItems()
        {
            _allMenuItems = new List<MenuItem>();

            var menuItem = new MenuItem
            {
                MenuItemId = 1,
                MenuItemName = "Login",
                NavigationPath = "myapp:///SWMasterDetailPage/NavigationPage/SignIn",
                MenuType = MenuTypeEnum.Login,
                MenuOrder = 99
            };
            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem
            {
                MenuItemId = 2,
                MenuItemName = "Logout",
                NavigationPath = "myapp:///SWMasterDetailPage/NavigationPage/SignIn",
                MenuOrder = 99,
                MenuType = MenuTypeEnum.LogOut
            };
            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem
            {
                MenuItemId = 3,
                MenuItemName = "Timeline",
                NavigationPath = "NavigationPage/CommunityFeed",
                MenuOrder = 2,
                MenuType = MenuTypeEnum.Secured
            };
            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem
            {
                MenuItemId = 4,
                MenuItemName = "Map",
                NavigationPath = "NavigationPage/MapsPage",
                MenuOrder = 1,
                MenuType = MenuTypeEnum.Secured
            };
            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem
            {
                MenuItemId = 5,
                MenuItemName = "Sign Up",
                NavigationPath = "NavigationPage/SignUp",
                MenuOrder = 98,
                MenuType = MenuTypeEnum.Login
            };
            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem
            {
                MenuItemId = 7,
                MenuItemName = "About Us",
                NavigationPath = "NavigationPage/AboutUs",
                MenuOrder = 4,
                MenuType = MenuTypeEnum.UnSecured
            };
            _allMenuItems.Add(menuItem);

            menuItem = new MenuItem
            {
                MenuItemId = 8,
                MenuItemName = "Settings",
                NavigationPath = "NavigationPage/SettingsPage",
                MenuOrder = 5,
                MenuType = MenuTypeEnum.Secured
            };
            _allMenuItems.Add(menuItem);
        }
    }
}