using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports.Application.ServiceAbstractions;
using Sports.Application.Services;
using Sports.Domain.DTOs;

namespace Sports.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService teamService;
        public TeamsController(ITeamService teamService)
        {
                this.teamService = teamService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await teamService.GetTeams();
            return result.StatusCode == 200 ? Ok(result) : NotFound(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            var result = await teamService.GetTeam(Id);
            return result.StatusCode == 200 ? Ok(result) : NotFound(result);
        }  
        [HttpGet("GetTeamsByTournament/{Id}")]
        public async Task<IActionResult> GetTeamsByTournament([FromRoute] int Id)
        {
            var result = await teamService.GetTeamsByTournament(Id);
            return result.StatusCode == 200 ? Ok(result) : NotFound(result);
        }     
        [HttpGet("LastXAddedTeams/{Count}")]
        public async Task<IActionResult> LastXAddedTeams([FromRoute] int Count)
        {
            var result = await teamService.LastXAddedTeams(Count);
            return result.StatusCode == 200 ? Ok(result) : NotFound(result);
        }
      
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] TeamDTO teamDTO)
        {
            var result = await teamService.PostTeam(teamDTO);
            return result.StatusCode == 201 ? Created(nameof(Post), result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromForm] TeamDTO teamDTO)
        {
            var result = await teamService.PutTeam(teamDTO);
            return result.StatusCode == 204 ? Created(nameof(Post), result) : BadRequest(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await teamService.DeleteTeam(Id);
            return result.StatusCode == 200 ? Ok() : BadRequest(result);
        }
    }
}
