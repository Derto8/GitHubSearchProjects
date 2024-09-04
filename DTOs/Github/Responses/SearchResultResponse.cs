using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.Github.Responses
{
    public class SearchResultResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<Items> Items { get; set; }
    }

    public class Items
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }

        [JsonPropertyName("stargazers_count")]
        public int Stargazers_Count { get; set; }

        [JsonPropertyName("watchers_count")]
        public int Watchers_Count { get; set; }

        [JsonPropertyName("full_name")]
        public string Full_Name { get; set; }
    }

    public class Owner
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }
    }
}
