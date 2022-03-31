using dotnet_mycompany.Service;
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
			app.UseRouting();

			// подключаем поддержку статичных файлов в приложении (css, js и т.д.)
			app.UseStaticFiles();

			// регистрируем нужные нам маршруты (ендпоинты)
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
