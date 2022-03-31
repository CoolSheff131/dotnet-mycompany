using dotnet_mycompany.Domain.Repositories.Abstract;

namespace dotnet_mycompany.Domain.Repositories
{
	public class DataManager
	{
		public ITextFieldsRepository TextFields { get; set; }
		public IServiceItemsRepository ServiceItems { get; set; }
		public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository)
		{
			TextFields = textFieldsRepository;
			ServiceItems = serviceItemsRepository;
		}
	}
}
