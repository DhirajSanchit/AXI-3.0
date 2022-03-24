using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AxiDAL.DAL;
using AxiInterfaces;
using AxiLogic.Containers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Axi3._0
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
            //Haalt Connection string uit de appsettings.Json
            var ConnectionString = Configuration.GetConnectionString("Default");
            var dbConnection = ConnectionString;
            

            //SELF-SERVICE SERVER INSTANCE | Wijst het toe aan de connectie van het project
            services.AddTransient<IDbConnection>(sp => new SqlConnection(ConnectionString));
            
            //Tests DB Connection
            services.AddScoped<ITestDAL, TestDAL>();
            services.AddScoped<ITestDapperContainer, TestDapperContainer>();
            //TODO: Develop Proof of Concept below for SQLReader Version
            //services.addScoped<ITestReaderContainer, TestReaderContainer>();

            
            
            //Dependency Injection for Data Layer classes and objects  
            
            //Dependency Injection for Logic Layer classes and objects
            
            
            
            services.AddControllersWithViews();
            services.AddRazorPages();
            
            //Library enabling front-end compiling when pressing F5
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}