using dotnet_mycompany.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mycompany.Models.ViewComponents
{
	public class SidebarViewComponent : ViewComponent
	{
		private readonly DataManager dataManager;

		public SidebarViewComponent(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		public Task<IViewComponentResult> InvokeAsync()
		{
			return Task.FromResult((IViewComponentResult)View("default", dataManager.ServiceItems.GetServiceItems()));
		}
 	}
}
