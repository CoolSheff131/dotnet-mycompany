using dotnet_mycompany.Domain.Entities;

namespace dotnet_mycompany.Domain.Repositories.Abstract
{
	public interface ITextFieldsRepository
	{
		IQueryable<TextField> GetTextFields();
		TextField GetTextFieldById(Guid id);
		TextField GetTextFieldByCodeWord(string codeWord);
		void SaveTextField(TextField entity);
		void DeleteTextField(Guid id);
	}
}
