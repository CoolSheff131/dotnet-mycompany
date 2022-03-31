using dotnet_mycompany.Domain.Entities;

namespace dotnet_mycompany.Domain.Repositories.Abstract
{
	public interface IServiceItemsRepository
	{
		IQueryable<ServiceItem> GetServiceItems();
		ServiceItem GetServiceItemById(Guid id);
		void SaveServiceItem(ServiceItem entity);
		void DeleteServiceItem(Guid id);
	}
}
