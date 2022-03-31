using dotnet_mycompany.Domain.Entities;
using dotnet_mycompany.Domain.Repositories.Abstract;

namespace dotnet_mycompany.Domain.Repositories.EntityFramework
{
	public class EFTextFieldsRepository : ITextFieldsRepository
	{
		private readonly AppDbContext context;

		public EFTextFieldsRepository(AppDbContext context)
		{
			this.context = context;
		}
		public IQueryable<TextField> GetTextFields()
		{
			return context.TextFields;
		}
		public TextField GetTextFieldById(Guid id)
		{
			return context.TextFields.FirstOrDefault(f => f.Id == id);
		}

		public TextField GetTextFieldByCodeWord(string codeWord)
		{
			return context.TextFields.FirstOrDefault(f => f.CodeWord == codeWord);
		}

		public void SaveTextField(TextField entity)
		{
			if(entity.Id == default)
			{
				context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
			}
			else
			{
				context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
			context.SaveChanges();
		}

		public void DeleteTextField(Guid id)
		{
			context.TextFields.Remove(new TextField() { Id = id });
			context.SaveChanges();
		}

		
	}
}
