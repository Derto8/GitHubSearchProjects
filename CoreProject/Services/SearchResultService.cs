using CoreProject.Abstract;
using CoreProject.Context;
using CoreProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Services
{
    public class SearchResultService : ISearchResultService
    {
        private readonly MainContext _mainContext;
        public SearchResultService(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task AddAsync(SearchResult searchResult)
        {
            await _mainContext.AddAsync(searchResult);
            await _mainContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(SearchResult searchResult)
        {
            _mainContext.Remove(searchResult);
            await _mainContext.SaveChangesAsync();
        }

        public async Task<SearchResult> GetAsync(string searchStr)
        {
            return await _mainContext.SearchResult.FirstOrDefaultAsync(c => c.SearchValue == searchStr);
        }
    }
}
