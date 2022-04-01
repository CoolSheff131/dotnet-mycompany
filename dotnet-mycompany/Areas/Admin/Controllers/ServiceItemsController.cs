﻿using dotnet_mycompany.Domain.Entities;
using dotnet_mycompany.Domain.Repositories;
using dotnet_mycompany.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mycompany.Areas.Admin.Controllers
{
	public class ServiceItemsController : Controller
	{
		private readonly DataManager dataManager;
		private readonly IWebHostEnvironment hostingEnvironment;
		public ServiceItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
		{
			this.dataManager = dataManager;
			this.hostingEnvironment = hostingEnvironment;
		}

		public IActionResult Edit(Guid id)
		{
			var entity = id == default ? new ServiceItem() : dataManager.ServiceItems.GetServiceItemById(id);
			return View(entity);
		}
		[HttpPost]
		public IActionResult Edit (ServiceItem model, IFormFile titleImageFile)
		{
			if (ModelState.IsValid)
			{
				if(titleImageFile != null)
				{
					model.TitleImagePath = titleImageFile.FileName;
					using(var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
					{
						titleImageFile.CopyTo(stream);
					}
				}
				dataManager.ServiceItems.SaveServiceItem(model);
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}
			return View(model);
		}
		
		[HttpPost]
		public IActionResult Delete(Guid id)
		{
			dataManager.ServiceItems.DeleteServiceItem(id);
			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
		}
	}
}