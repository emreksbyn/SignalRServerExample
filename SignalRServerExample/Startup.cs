using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

namespace SignalRServerExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Guvenlik onlemlerini gecebilmek icin :
            services.AddCors(options => options.AddDefaultPolicy(policy =>
                             policy.AllowAnyMethod()
                                   .AllowAnyHeader()
                                   .AllowCredentials()
                                   .SetIsOriginAllowed(origin => true)
            ));

            // IHubContext interface ni MyBusiness sinifinda kullanabilmem icin bu sekilde tanimlamam gerekir :
            services.AddTransient<MyBusiness>();

            services.AddSignalR();

            // Projemize Controller sinifini sonradan ekledik ve tabikide startup sinifinda bunu bildirmemiz gerekecek.
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // UseRouting in uzerinde tanimlanmasi gerekir.
            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MyHub>("/myhub");
                // Controllerdan yapilan attribute tabanli routing in eslestirmesi
                endpoints.MapControllers();
            });
        }
    }
}