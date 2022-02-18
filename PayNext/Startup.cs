using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PayNext.Core.Helpers.Common;
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
			services.AddSession(options =>
			{
				// Set a short timeout for easy testing.
				options.IdleTimeout = TimeSpan.FromSeconds(8000);
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
				// Make the session cookie essential
				options.Cookie.IsEssential = true;
			});
			#region Authentication
			//services.ConfigureApplicationCookie(o => o.LoginPath = "/Admin/Account/login");
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
			 options.LoginPath = "/Account/login");
			services.ConfigureApplicationCookie(o => o.LoginPath = "/");

			#endregion
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;


			});

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddDbContext<PayNextContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
				x => x.MigrationsAssembly("PayNext.Infrastructure")));
			services.AddTransient(typeof(IAsyncRepository<>), typeof(EfRepository<>));
			services.AddHttpContextAccessor();
			services.AddScoped<IUserService, UserService>();
			services.AddSingleton<ISessionManager, SessionManager>();
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
			var cookiePolicyOptions = new CookiePolicyOptions
			{
				MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None,
				Secure = CookieSecurePolicy.Always,
				HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always
			};

			app.UseCookiePolicy(cookiePolicyOptions);
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSession();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				//endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/");
				endpoints.MapRazorPages();
			});
		}
	}
}
