using BlaAppCrd.Areas.Identity;
using BlaAppCrd.Data;
using static CommonCrd.Code.GLB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// =========================================== Inclui Syncfusion no projeto =======================================================
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Authorization;

namespace BlaAppCrd
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            CnnString = Configuration.GetConnectionString("DB");
        }
        public object GlobalFilters { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();         

            // ================================== Habilita services Syncfusion ======================================================
            services.AddSyncfusionBlazor( );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ================================== License Keys - Syncfusion===========================================================  
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzY4MjkzQDMxMzgyZTM0MmUzMEwwN1hiQVNHQVNVVnF5K0pLbm5KTTVueVhOWXRCNk0rWFNNWTBVTTdJWkE9");
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzgwNDA3QDMxMzgyZTM0MmUzMGlsczRhTUNRT3dRZVlocElCR0JUQ2pKWTBCQmpTVklTdnBLRzVOeXJnZnc9");
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzgwNDEzQDMxMzgyZTM0MmUzMGRIakJjYWVNLzlrQWUrR2lIVkxZTkJsRVAvZCt2SHZuWDRLbEkwUUhhdWM9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}