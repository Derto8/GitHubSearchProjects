using DTOs.Github.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Abstract
{
    public interface ISearchGithubProjectsService
    {
        Task<SearchResultResponse> GetSearchResultsAsync(string searchStr);
        Task SaveSearchResultsAsync(string searchStr, string gitlabUrl);
        Task DeleteSearchResultAsync(string searchStr);
    }
}
