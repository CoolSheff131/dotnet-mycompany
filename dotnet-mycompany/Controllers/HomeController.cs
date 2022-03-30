using Microsoft.AspNetCore.Mvc;

namespace dotnet_mycompany.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
