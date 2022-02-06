using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PayNext.Core.Interfaces;
using PayNext.Core.Services;
using PayNext.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayNext
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddDbContext<PayNextContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
				x => x.MigrationsAssembly("PayNext.Infrastructure")));
			services.AddTransient(typeof(IAsyncRepository<>), typeof(EfRepository<>));
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ICardService, CardService>();
			services.AddMvc().AddRazorPagesOptions(options =>
			{
				options.Conventions.AddPageRoute("/Account/login", "");
				//options.Conventions.AddPageRoute("/Index", "");
			});
			services.AddDataProtection();
			//services.AddRazorPages().AddViewLocalization();
			services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				//endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/");
				endpoints.MapRazorPages();
			});
		}
	}
}
