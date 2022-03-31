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
				Id = "53a8d841-dd38-4044-8bcf-c3852ce19a1b",
				Name = "admin",
				NormalizedName = "ADMIN",
			});

			modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = "af278e2b-003d-4289-a11f-30ff88905804",
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
				RoleId = "53a8d841-dd38-4044-8bcf-c3852ce19a1b",
				UserId = "af278e2b-003d-4289-a11f-30ff88905804"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("1e6c1474-afc0-4b08-b08c-d7c280ead026"),
				CodeWord = "PageIndex",
				Title = "Главная"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("373547d3-9332-4e25-a76b-267331844484"),
				CodeWord = "PageServices",
				Title = "Наши услуги"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("10058beb-6d89-47a0-98fb-d264dfb6fdff"),
				CodeWord = "PageContacts",
				Title = "Контакты"
			});
		}
	}
}
