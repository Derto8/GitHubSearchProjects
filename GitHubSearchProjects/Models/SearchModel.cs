using System.ComponentModel.DataAnnotations;

namespace GitHubSearchProjects.Models
{
    public class SearchModel
    {
        [Display(Name = "Название репозитория")]
        [Required(ErrorMessage = "Введите название репозитория")]
        public string SearchValue { get; set; }
    }
}
