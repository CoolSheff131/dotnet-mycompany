using dotnet_mycompany.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_mycompany.Domain
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<TextField> TextFields { get; set; }
		public DbSet<ServiceItem> ServiceItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "12r23frwfsoi",
				Name = "admin",
				NormalizedName = "ADMIN",
			});

			modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = "adfsfdjckcz",
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
				SecurityStamp = string.Empty
			});

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "12r23frwfsoi",
				UserId = "adfsfdjckcz"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("g"),
				CodeWord = "PageIndex",
				Title = "Главная"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("sgdf"),
				CodeWord = "PageServices",
				Title = "Наши услуги"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("qwer"),
				CodeWord = "PageContacts",
				Title = "Контакты"
			});
		}
	}
}
