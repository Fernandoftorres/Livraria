using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Livraria.UI.Site.Models;
using MediatR;
using Livraria.Domain.Core.Notifications;
using Livraria.UI.Site.Controllers;

namespace Livraria.UI.Site.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(INotificationHandler<DomainNotification> notifications)
            : base(notifications)
        {

        }            

        public IActionResult Index()
        {
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
