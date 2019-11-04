using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pos.WebApplication.Areas.Masters.Controllers
{
    [Area("Order")]
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}