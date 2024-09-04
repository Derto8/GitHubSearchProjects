using CoreProject.Abstract;
using MVCDTOs.Mapping;
using GitHubSearchProjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GitHubSearchProjects.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ISearchGithubProjectsService _searchGithubProjectsService;
        private readonly IConfiguration _configuration;

        private readonly string _githubApiUrl;
        public readonly string _githubUrl;

        public HomeController(ILogger<HomeController> logger,
            ISearchGithubProjectsService searchGithubProjectsService,
            IConfiguration configuration)
        {
            _searchGithubProjectsService = searchGithubProjectsService;
            _configuration = configuration;

            _githubApiUrl = _configuration["GithubAPIUrl"];
            _githubUrl = _configuration["GitHubUrl"];
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchModel model)
        {
            if (!ModelState.IsValid) return View();

            await _searchGithubProjectsService.SaveSearchResultsAsync(model.SearchValue, _githubApiUrl);

            return RedirectToAction("SearchingResults", "Home", new { searchValue = model.SearchValue });
        }

        public async Task<IActionResult> SearchingResults(string searchValue)
        {
            var data = (await _searchGithubProjectsService.GetSearchResultsAsync(searchValue)).MapToResponse(_githubUrl);

            var returnModel = new SearchingResultModel
            {
                GithubRepositories = data.Items?.Select(c => new GithubRepositoriesModel
                {
                    Name = c.Name,
                    Login = c.Login,
                    StargazersCount = c.Stargazers_Count,
                    WatchersCount = c.Watchers_Count,
                    Url = c.Full_Name
                })
            };

            return View(returnModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
