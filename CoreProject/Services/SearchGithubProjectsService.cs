using CoreProject.Abstract;
using CoreProject.Context;
using CoreProject.Entities;
using DTOs.Github.Responses;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoreProject.Services
{
    public class SearchGithubProjectsService : ISearchGithubProjectsService
    {
        private readonly IGithubAPIService _githubAPIService;
        private readonly ISearchResultService _searchResultService;

        public SearchGithubProjectsService(IGithubAPIService githubAPIService,
            ISearchResultService searchResultService)
        {
            _githubAPIService = githubAPIService;
            _searchResultService = searchResultService;
        }

        public async Task DeleteSearchResultAsync(string searchStr)
        {
            var searchResult = await _searchResultService.GetAsync(searchStr);
            if (searchResult is null) return;

            await _searchResultService.DeleteAsync(searchResult);
        }

        public async Task<SearchResultResponse> GetSearchResultsAsync(string searchStr)
        {
            var searchResult = await _searchResultService.GetAsync(searchStr);

            return searchResult is not null ? JsonConvert.DeserializeObject<SearchResultResponse>(searchResult.Data) : new SearchResultResponse();
        }

        public async Task SaveSearchResultsAsync(string searchStr, string gitlabUrl)
        {
            var searchResult = await _searchResultService.GetAsync(searchStr);
            if (searchResult is not null)
                return;

            var gitlabData = await _githubAPIService.GetSearchData(searchStr, gitlabUrl);

            await _searchResultService.AddAsync(new SearchResult
            {
                SearchValue = searchStr,
                Data = gitlabData,
            });
        }
    }
}
