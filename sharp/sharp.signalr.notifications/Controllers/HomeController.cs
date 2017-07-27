using System.Web.Mvc;
using sharp.signalr.notifications.SignalR;

namespace sharp.signalr.notifications.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SendMessage("1");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            SendMessage("2");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            SendMessage("3");
            return View();
        }

        private void SendMessage(string message)
        {
            var context = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.displayMessage(message);
        }
    }
}