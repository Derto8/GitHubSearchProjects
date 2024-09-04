using DTOs.Github.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Abstract
{
    public interface IGithubAPIService
    {
        Task<string> GetSearchData(string strSearch, string gitlabUrl);
    }
}
