using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DDDExampleII.Presentation.MVC.Controllers
{
    public class FundTransferController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "This is the example Page.";
            return View();
        }

        public IActionResult List()
        {
            ViewData["Message"] = "This is the List Page.";
            return View();
        }

    }
}