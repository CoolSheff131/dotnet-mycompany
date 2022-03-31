using System.ComponentModel.DataAnnotations;

namespace dotnet_mycompany.Domain.Entities
{
	public abstract class EntityBase
	{
		protected EntityBase() => DateAdded = DateTime.UtcNow;

		[Required]
		public Guid Id { get; set; }

		[Display(Name = "Название (заголовок)")]
		public virtual string Title { get; set; }

		[Display(Name = "Краткое описание")]
		public virtual string Subtitle { get; set; } = "Subtitle";

		[Display(Name = "Полное описание")]
		public virtual string Text { get; set; }

		[Display(Name = "Титульная картинка")]
		public virtual string TitleImagePath { get; set; } = "image";

		[Display(Name = "SEO метатег Title")]
		public virtual string MetaTitle { get; set; } = "Title";

		[Display(Name = "SEO метатег Description")]
		public virtual string MetaDescription { get; set; } = "Description";

		[Display(Name = "SEO метатег Keywords")]
		public virtual string MetaKeywords { get; set; } = "Keywords";

		[DataType(DataType.Time)]
		public DateTime DateAdded { get; set; }
	}
}
