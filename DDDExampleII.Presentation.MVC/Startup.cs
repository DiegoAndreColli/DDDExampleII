﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DDDExampleII.Domain.Services;
using DDDExampleII.Infra.Data.Context;
using DDDExampleII.Domain.Entities;
using DDDExampleII.Domain.Interfaces.Repositories;
using DDDExampleII.Infra.Data.Repositories;
using DDDExampleII.Application;
using DDDExampleII.Application.Interfaces;
using DDDExampleII.Domain.Interfaces.Services;

namespace DDDExampleII.Presentation.MVC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            var connection = @"Data Source=DESKTOP-KIU0CU0\SQLEXPRESS;Initial Catalog=DDDExampleII;Persist Security Info=True;User ID=sa;Password=metallica;MultipleActiveResultSets=True;";
            //var connection = @"Data Source=sql6005.site4now.net;Initial Catalog=DB_A3E5FB_diegocolli;Persist Security Info=True;User ID=DB_A3E5FB_diegocolli_admin;Password=DieFla15!9;MultipleActiveResultSets=True;";

            services.AddDbContext<DDDExampleIIContext>(
                options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connection, b => b.MigrationsAssembly("DDDExampleII.Presentation.MVC"))
             );

            //services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IFundTransferAppService, FundTransferAppService>();
            services.AddTransient<IFundTransferService, FundTransferService>();
            services.AddTransient<IUnitOfWorkRepository, UnitOfWorkRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
