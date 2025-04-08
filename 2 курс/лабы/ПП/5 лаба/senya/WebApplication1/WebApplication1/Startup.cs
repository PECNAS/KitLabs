using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void  ConfigureServices(IServiceCollection services)
        {
			services.AddOptions();
			string connection = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection));
			services.AddMvc();
			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30); // Устанавливаем время жизни сессии
			});
			services.AddHttpContextAccessor();
		}
        public void Configure(WebApplication app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseSession(); // Добавьте эту строку перед app.UseEndpoints();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			});
			app.UseCookiePolicy();

			var dbContext = serviceProvider.GetService<MobileContext>();
			SampleData.Initialize(dbContext, env);
        }
    }
}
