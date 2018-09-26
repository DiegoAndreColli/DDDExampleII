using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDExampleII.Application.Interfaces;
using DDDExampleII.Domain.Entities;
using DDDExampleII.Presentation.MVC.Models;
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
            var view = new FundTransferView();
            view.Entities = service.ListEntities();
            view.Transfer = new Transfer { Value = 100};
            
            ViewData["Message"] = "This is the example Fund Transfer Page.";
            return View(view);
        }

        public IActionResult List()
        {
            ViewData["Transfers"] = service.ListTransfers();
            return View();
        }


        public IActionResult TransferFund(Transfer transfer)
        {
            service.TransferFund(transfer);
            ViewData["Transfers"] = service.ListTransfers();
            return View("List");

        }
    }
}