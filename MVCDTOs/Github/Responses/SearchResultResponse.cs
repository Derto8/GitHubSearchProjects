using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MVCDTOs.Github.Responses
{
    public class SearchResultResponse
    {
        public IEnumerable<Items> Items { get; set; }
    }

    public class Items
    {
        public string Name { get; set; }

        public string Login { get; set; }

        public int Stargazers_Count { get; set; }

        public int Watchers_Count { get; set; }

        public string Full_Name { get; set; }
    }

}
