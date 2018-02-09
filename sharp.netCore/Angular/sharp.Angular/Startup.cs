using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace sharp.Angular
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new Microsoft.AspNetCore.SpaServices.Webpack.WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
