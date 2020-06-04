using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSafeWayz.Services.Interfaces
{
    public interface ISecurityService
    {
        IList<MenuItem> GetAllowedAccessItems();
        Task<bool> Login(string username, string password);
        void LogOut();
    }
}
