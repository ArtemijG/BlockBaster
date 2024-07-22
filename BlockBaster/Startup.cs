using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlockBaster.Service;
using BlockBaster.Data;
using BlockBaster.Data.Repositories.Abstract;
using BlockBaster.Data.Repositories.EntityFramework;
using BlockBaster.Data.Repositories;
using BlockBaster.Data.Entities;

namespace BlockBaster
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем конфиг из appsetting.json
            Configuration.Bind("Project", new Config());

            services.AddTransient<IActorMovieRepository, EFActorMovieRepository>();
            services.AddTransient<IActorRepository, EFActorRepository>();
            services.AddTransient<ICountryRepository, EFCountryRepository>();
            services.AddTransient<IGenreRepository, EFGenreRepository>();
            services.AddTransient<IMovieCountryRepository, EFMovieCountryRepository>();
            services.AddTransient<IMovieGenreRepository, EFMovieGenreRepository>();
            services.AddTransient<IMovieRepository, EFMovieRepository>();
            services.AddTransient<IProducerMovieRepository, EFProducerMovieRepository>();
            services.AddTransient<IProducerRepository, EFProducerRepository>();
            //services.AddTransient<IRoleRepository, EFRoleRepository>();
            services.AddTransient<IScriptwriterMovieRepository, EFScriptwriterMovieRepository>();
            services.AddTransient<IScriptwriterRepository, EFScriptwriterRepository>();
            services.AddTransient<ISubscriptionRepository, EFSubscriptionRepository>();
            services.AddTransient<IUserMovieRepository, EFUserMovieRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            //services.AddTransient<IUserRoleRepository, EFUserRoleRepository>();
            services.AddTransient<DataManager>();

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "BlockBusterCookie";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/login";
                options.SlidingExpiration = true;
                
            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy =>
                {
                    policy.RequireRole("admin");
                });
                x.AddPolicy("UserArea", policy =>
                {
                    policy.RequireRole("user");
                });
            });
            //поддержка контроллеров и представлений (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
                x.Conventions.Add(new UserAreaAuthorization("User", "UserArea"));
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("User", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("Account", "{controller=Account}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
