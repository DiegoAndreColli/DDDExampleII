using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDExampleII.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDDExampleII.Presentation.MVC.Controllers
{
    public class FundTransferController : Controller
    {
        private readonly IFundTransferAppService service;

        public FundTransferController(IFundTransferAppService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "This is the example Page.";
            return View();
        }

        public IActionResult List()
        {
            ViewData["Transfers"] = service.ListTransfers();
            ViewData["Message"] = "This is the List Page.";
            return View();
        }

    }
}