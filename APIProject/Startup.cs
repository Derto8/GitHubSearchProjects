using CoreProject.Abstract;
using CoreProject.Context;
using CoreProject.Services;
using Microsoft.EntityFrameworkCore;

namespace APIProject
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            string connection = config.GetConnectionString("ConnectionDataBase");
            services.AddDbContext<MainContext>(options => options.UseNpgsql(connection));

            services.AddScoped<IGithubAPIService, GithubAPIService>();
            services.AddScoped<ISearchGithubProjectsService, SearchGithubProjectsService>();
            services.AddScoped<ISearchResultService, SearchResultService>();
        }
    }
}
