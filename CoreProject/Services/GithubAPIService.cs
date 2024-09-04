using CoreProject.Abstract;
using DTOs.Github.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Services
{
    public class GithubAPIService : IGithubAPIService
    {
        public async Task<string> GetSearchData(string strSearch, string gitlabUrl)
        {
            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(gitlabUrl);
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("request");
                var response = await httpClient.GetAsync($"/search/repositories?q={strSearch}");
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
