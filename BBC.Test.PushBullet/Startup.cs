using BBC.Test.PushBullet.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using BBC.Test.PushBullet.Filter;

namespace BBC.Test.PushBullet
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
            services.AddMvc( o => o.Filters.Add<ApiExceptionFilter>() );
            services.AddSingleton<UserService>();
            services.AddSingleton<PushBulletService>();
            services.AddAutoMapper();
            // services.AddEntityFrameworkInMemoryDatabase();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // app.UseExceptionHandler();

            app.UseMvc();

        }
    }
}
