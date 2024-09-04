using MVCDTOs.Github.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOsResponse = DTOs.Github.Responses.SearchResultResponse;

namespace MVCDTOs.Mapping
{
    public static class SearchResultMapper
    {
        public static SearchResultResponse MapToResponse(this DTOsResponse dto, string githubUrl)
        {
            return new SearchResultResponse
            {
                Items = dto.Items?
                    .Select(c => new Items
                    {
                        Name = c.Name,
                        Login = c.Owner.Login,
                        Stargazers_Count = c.Stargazers_Count,
                        Full_Name = string.Concat(githubUrl, c.Full_Name),
                        Watchers_Count = c.Watchers_Count,
                    })
            };
        }
    }
}
