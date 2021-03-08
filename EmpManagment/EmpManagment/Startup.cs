using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EmpManagment.Security;
using EmpManagmentBLL.CommanBs;
using EmpManagmentBLL.ComplaientDelete;
using EmpManagmentBOL.Tables;
using EmpManagmentDAL.DbContextClass;
using EmpManagmentIBLL.ICommanRepositry;
using EmpManagmentIBLL.IComplaientRepo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmpManagment
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public static IConfiguration StaticConfig { get; private set; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            StaticConfig = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Inject AspNetCoreIdentity dependdencies
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            })
            .AddEntityFrameworkStores<EmployeeDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<CustomEmailConfirmationTokenProvider<ApplicationUser>>("CustomEmailConfirmation");

            //Set token life span to 5 hours this change will apply all token provider method if we want specify to a specific token generate then create to custom token provider (Default 1 day )
            services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromHours(5));

            // Changes token lifespan of just the Email Confirmation Token type
            services.Configure<CustomEmailConfirmationTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromDays(3));

            services.AddMemoryCache();

            services.AddDistributedMemoryCache();

            //Inject AppDbContext dependencies
            services.AddDbContextPool<EmployeeDbContext>(item => item.UseSqlServer(configuration.GetConnectionString("EmployeeDBConnection"), assembly => assembly.MigrationsAssembly(typeof(EmployeeDbContext).Assembly.FullName)));

            //Adding mvc 
            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = true;
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                option.Filters.Add(new AuthorizeFilter(policy));
                option.SuppressAsyncSuffixInActionNames = false;
            })
            .AddRazorRuntimeCompilation();

            //Adding Authentication
            services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = Startup.StaticConfig["GoogleClientId"];
                options.ClientSecret = Startup.StaticConfig["GoogleScreteKey"];
                options.RemoteAuthenticationTimeout = TimeSpan.FromSeconds(120);
                options.SaveTokens = true;
                options.CorrelationCookie = new Microsoft.AspNetCore.Http.CookieBuilder
                {
                    HttpOnly = true,
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                    SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.None,
                    Expiration = TimeSpan.FromSeconds(120),
                    MaxAge = TimeSpan.FromMinutes(15)
                };
            })
            .AddFacebook(options =>
            {
                options.AppId = Startup.StaticConfig["FacebookAppId"];
                options.AppSecret = Startup.StaticConfig["FacebookScreteKey"];
                options.RemoteAuthenticationTimeout = TimeSpan.FromSeconds(120);
                options.SaveTokens = true;
                options.CorrelationCookie = new Microsoft.AspNetCore.Http.CookieBuilder
                {
                    HttpOnly = true,
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                    SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.None,
                    Expiration = TimeSpan.FromSeconds(120),
                    MaxAge = TimeSpan.FromMinutes(15)
                };
            });

            //Adding Application Cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                options.LoginPath = new PathString("/Comman/Account/Login");
                options.LogoutPath = new PathString("/Comman/Account/Logout");
                options.AccessDeniedPath = new PathString("/User/Administration/AccessDenied");
                options.SlidingExpiration = true;

            });

            //Adding Authorization and role policy
            services.AddAuthorization(options =>
            {
                //We can add edt police directly here ... this code is commentd for use antoher way of this method
                //options.AddPolicy("EditRolePolicy", policy => policy.RequireAssertion(context =>
                //            context.User.IsInRole("Admin") &&
                //            context.User.HasClaim(claim => claim.Type == "Edit Role" /*&& claim.Value == "true"*/) ||
                //            context.User.IsInRole("Super Admin")));

                options.AddPolicy("DeleteRolePolicy", policy => policy.RequireClaim("Delete Role"));
                options.AddPolicy("EditRolePolicy", policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));
                //If Handlers failuer then do not invoke next Handlers
                options.InvokeHandlersAfterFailure = false;
                options.AddPolicy("CreateRolePolicy", policy => policy.RequireClaim("Create Role"));
                options.AddPolicy("AdminRolePolicy", policy => policy.RequireRole("Admin", "Super Admin"));
                options.AddPolicy("UserRolePolicy", policy => policy.RequireRole("User", "Manager"));
            });

            //Extar Configure for date 
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                 {
                     new CultureInfo("en-IN")
                 };
                options.DefaultRequestCulture = new RequestCulture("en-IN");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            //To set Scope of page life cycle 
            services.AddScoped<IAccountRepository, SqlCommanRepositry>();
            services.AddScoped<IComplaientRepositery, SqlComplaientBs>();
            services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();

            //Register the secod custom authorization handler
            services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();
            services.AddSingleton<DataProtectionPurposeStrings>();
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
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy(new CookiePolicyOptions()
            {
                HttpOnly = HttpOnlyPolicy.None,
                Secure = CookieSecurePolicy.None,
                MinimumSameSitePolicy = SameSiteMode.Lax
            });
            app.UseAuthentication();
           
            app.UseAuthorization();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "areaRoute",
            //        template: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
            //    );

            //    //Default Route
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        //private bool AuthorizeAccess(AuthorizationHandlerContext context)
        //{
        //    return (context.User.IsInRole("Admin") && context.User.HasClaim(claim => claim.Type == "Edit Role" && claim.Value == "true")) || context.User.IsInRole("Super Admin");
        //}
    }
}
