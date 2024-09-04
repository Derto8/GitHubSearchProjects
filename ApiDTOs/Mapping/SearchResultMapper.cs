using ApiDTOs.Github.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOsResponse = DTOs.Github.Responses.SearchResultResponse;

namespace ApiDTOs.Mapping
{
    public static class SearchResultMapper
    {
        public static SearchResultResponse MapToResponse(this DTOsResponse dto, PagedRequestDTO filer, string githubUrl)
        {
            if (dto.Items?.Count() == 0) return new SearchResultResponse();

            if (filer.PageSize == 0) filer.PageSize = dto.Items == null ? 0 : dto.Items.Count();

            return new SearchResultResponse
            {
                Count = dto.Items.Count(),
                PageSize = filer.PageSize,
                PageNumber = filer.PageNumber,
                Items = dto.Items?
                    .Skip((filer.PageNumber - 1) * filer.PageSize)
                    .Take(filer.PageSize)
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
