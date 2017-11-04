using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Livraria.UI.SIte.Models;
using Livraria.Application.Interfaces;
using MediatR;
using Livraria.Domain.Core.Notifications;
using Livraria.UI.Site.Controllers;

namespace Livraria.UI.SIte.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICustomerAppService _customerAppService;

        public HomeController(ICustomerAppService customerAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _customerAppService = customerAppService;
        }

        public IActionResult Index()
        {
            _customerAppService.Register(new Application.ViewModels.CustomerViewModel()
            {
                Email = "fernandoftorres@gmail.com",
                BirthDate = new System.DateTime(1982,3,10),
                Name ="Fernando Torres"
            });
            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
