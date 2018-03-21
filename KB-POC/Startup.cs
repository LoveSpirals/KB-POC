using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Configuration;

namespace POC_1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string clientId = configuration["ida:ClientId"];
            string aadInstance = configuration["ida:AADInstance"];
            string tenant = configuration["ida:Tenant"];
            string postLogoutRedirectUri = configuration["ida:PostLogoutRedirectUri"];
    }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddAuthentication()
                .AddCookie()
                .AddMicrosoftAccount(opts =>
                {
                    opts.ClientId = "bf79dc67-aa09-4171-8dd2-5a3f60e16586";
                    opts.ClientSecret = "IxOlVVN3ljWb6dZZ8/iwSen+YF4Fuvqygndv0JnDYsY=";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
