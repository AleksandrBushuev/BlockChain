using BlockChain.Web.Services;
using BlockChain.Web.Services.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlockChain.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddMemoryCache();

            services.AddSingleton<IBlockChainCacheService, BlockChainCacheService>();
            services.AddScoped<IBlockChainService, BlockChainService>();
        }

     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NodeHub>("/broadcast");
            });
        }
    }
}
