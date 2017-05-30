using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityServerFour.Configuration;
using IdentityServer4.Validation;
using IdentityServerFour.Extentions;
using IdentityServer4.Services;
using Microsoft.Extensions.PlatformAbstractions;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace IdentityServerFour
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentityServer()
                        .AddInMemoryClients(Clients.Get())
                        .AddInMemoryIdentityResources(Configuration.Resources.GetIdentityResources())
                        .AddInMemoryApiResources(Configuration.Resources.GetApiResources())
                        .AddTestUsers(Users.Get())
                        .AddSigningCredential(new X509Certificate2(Path.Combine(".", "certs", "AuthSample.pfx")))
                        .AddProfileService<ProfileService>()
                        .AddExtensionGrantValidator<DelegationGrantValidator>(); ;
            
                        //.AddTemporarySigningCredential(); /*// Can be used for testing until a real cert is available*/

            services.AddCors();


           
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();

            services.AddMvc();// AddWebApiConventions(); //Add WebApi;


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ////Grab key for signing JWT signature
            ////In prod, we'd get this from the certificate store or similar
            //var certPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "idsrv3test.pfx");
            //var certPath = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "idsrv3test.pfx"), "idsrv3test");

            //var cert = new X509Certificate2(certPath);

            loggerFactory.AddConsole(/*LogLevel.Debug*/);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }

            app.UseCors(builder =>
            builder
            //.WithOrigins("http://gdedev13.gdeacu.com"
            //                   , "http://localhost:44322")
            .AllowAnyHeader()
            .AllowAnyOrigin());

            app.UseIdentityServer();

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });

             //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseStaticFiles();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvcWithDefaultRoute();
        }
    }
}
