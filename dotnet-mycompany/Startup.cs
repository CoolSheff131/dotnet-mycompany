using dotnet_mycompany.Domain;
using dotnet_mycompany.Domain.Repositories;
using dotnet_mycompany.Domain.Repositories.Abstract;
using dotnet_mycompany.Domain.Repositories.EntityFramework;
using dotnet_mycompany.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace dotnet_mycompany
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)=> Configuration = configuration;

		public void ConfigureServices(IServiceCollection services)
		{
			// подключаем конфиг из appsettings.json
			Configuration.Bind("Project", new Config());

			// подключаем нужный функционал приложения в качестве сервисов
			services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
			services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
			services.AddTransient<DataManager>();

			//подключаем контекс БД
			services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

			//настраиваем identity систему
			services.AddIdentity<IdentityUser, IdentityRole>(opts =>
			{
				opts.User.RequireUniqueEmail = true;
				opts.Password.RequiredLength = 6;
				opts.Password.RequireNonAlphanumeric = false;
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireDigit = false;
			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

			//настраиваем authentication cookie
			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = "myCompanyAuth";
				options.Cookie.HttpOnly = true;
				options.LoginPath = "/account/login";
				options.AccessDeniedPath = "/account/accessdenied";
				options.SlidingExpiration = true;
			});

			// добавляем поддержку контроллеров и представлений (MVC)
			services.AddControllersWithViews()
				// выставляем совместимость с asp.net core 3.0
				.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
				.AddSessionStateTempDataProvider();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//!!! порядок регистрации middleware очень важен
			// в процессе разработки нам важно видеть подробную информацию об ошибках
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// подключаем поддержку статичных файлов в приложении (css, js и т.д.)
			app.UseStaticFiles();

			// подключаем систему маршрутизации
			app.UseRouting();

			// подключаем аутентификацию и авторизацию
			app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseAuthorization();

			// регистрируем нужные нам маршруты (ендпоинты)
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
