using Microsoft.AspNetCore.Mvc;
using Pos.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.WebApplication.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly List<MenuItem> _menus;

        public MenuViewComponent()
        {

            _menus = new List<MenuItem>
            {
                new MenuItem { Id = Guid.NewGuid(), Position = 1, Title = "Dashboard", Url = "/Home", Icon = "md md-dashboard" },
                new MenuItem { Id = Guid.NewGuid(), Position = 2, Title = "Master", Url = "/Master", Icon = "md md-group" },
                new MenuItem { Id = Guid.NewGuid(), Position = 3, Title = "Order", Url = "/Adminstration", Icon = "md md-account-child" },
                new MenuItem { Id = Guid.NewGuid(), Position = 4, Title = "Report", Url = "/Attendance", Icon = "md md-av-timer" },                
            };

            _menus.Add(new MenuItem { Id = Guid.NewGuid(), Position = 1, Title = "Product", Url = "/Master/Product", Icon = "md md-account-child", Parent = _menus.Where(x => x.Title.Contains("Master")).SingleOrDefault().Id });
            _menus.Add(new MenuItem { Id = Guid.NewGuid(), Position = 2, Title = "Product Category", Url = "/Master/ProductCategory", Icon = "md md-account-child", Parent = _menus.Where(x => x.Title.Contains("Master")).SingleOrDefault().Id });




        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("Default", _menus));
        }
    }
}
