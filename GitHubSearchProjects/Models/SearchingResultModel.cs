using System.ComponentModel.DataAnnotations;

namespace GitHubSearchProjects.Models
{
    public class SearchingResultModel
    {
        public IEnumerable<GithubRepositoriesModel> GithubRepositories { get; set; }
    }

    public class GithubRepositoriesModel
    {
        [Display(Name = "Название репозитория")]
        public string Name { get; set; }

        [Display(Name = "Логин автора")]
        public string Login { get; set; }

        [Display(Name = "Количество звезд")]
        public int StargazersCount { get; set; }

        [Display(Name = "Количество просмотров")]
        public int WatchersCount { get; set; }

        public string Url { get; set; }
    }
}
