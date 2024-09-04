using ApiDTOs;
using ApiDTOs.Mapping;
using CoreProject.Abstract;
using DTOs.Github.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace APIProject.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchGithubProjectsService _githubProjectsService;
        private readonly IConfiguration _configuration;

        private readonly string _githubApiUrl;
        public readonly string _githubUrl;

        public SearchController(ISearchGithubProjectsService githubProjectsService,
            IConfiguration configuration)
        {
            _githubProjectsService = githubProjectsService;
            _configuration = configuration;

            _githubApiUrl = _configuration["GithubAPIUrl"];
            _githubUrl = _configuration["GitHubUrl"];
        }

        [HttpPost("find")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> PostFind([FromBody] string searchStr)
        {
            try
            {
                await _githubProjectsService.SaveSearchResultsAsync(searchStr.Trim(), _githubApiUrl);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                //сюда можно впихнуть какой-нибудь Serilog с интерфейсом Seq - логирование
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("find")]
        [ProducesResponseType(typeof(SearchResultResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFind([FromQuery] PagedRequestDTO filter, string searchStr)
        {
            try
            {
                var data = await _githubProjectsService.GetSearchResultsAsync(searchStr.Trim());
                return Ok(data.MapToResponse(filter, _githubUrl));
            }
            catch (Exception ex)
            {
                //сюда можно впихнуть какой-нибудь Serilog с интерфейсом Seq - логирование
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("find/{searchStr}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFind(string searchStr)
        {
            try
            {
                await _githubProjectsService.DeleteSearchResultAsync(searchStr.Trim());
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                //сюда можно впихнуть какой-нибудь Serilog с интерфейсом Seq - логирование
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
