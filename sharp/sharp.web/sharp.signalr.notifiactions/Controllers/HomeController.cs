using System.Web.Mvc;
using sharp.signalr.notifiactions.SignalR;

namespace sharp.signalr.notifiactions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            displayMessage("Index");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            displayMessage("About");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            displayMessage("Contact");
            return View();
        }

        private void displayMessage(string message)
        {
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.displayMessage(message);
        }
    }
}