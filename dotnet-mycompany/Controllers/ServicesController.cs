using dotnet_mycompany.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mycompany.Controllers
{
	public class ServicesController : Controller
	{
		private readonly DataManager dataManager;

		public ServicesController(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}
		public IActionResult Index(Guid id)
		{
			if(id != default)
			{
				return View("Show", dataManager.ServiceItems.GetServiceItemById(id));
			}
			ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
			return View(dataManager.ServiceItems.GetServiceItems());
		}
	}
}
