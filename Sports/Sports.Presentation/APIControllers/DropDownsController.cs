using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sports.Application.ServiceAbstractions;
using Sports.Domain.Entities;

namespace Sports.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownsController : ControllerBase
    {
        private readonly IDropDownService dropDownService;
        public DropDownsController(IDropDownService dropDownService)
        {
            this.dropDownService = dropDownService;
        }
        [HttpGet("GetTeamsDropDown")]
        public async Task<IActionResult> GetTeamsDropDown() =>
            Ok(await dropDownService.GetDropDownAsync<Team>(x => new { Id = x.TeamId, Name = x.TeamName },null));
        [HttpGet("GetTournamentsDropDown")]
        public async Task<IActionResult> GetTournamentsDropDown() =>
            Ok(await dropDownService.GetDropDownAsync<Tournament>(x => new { Id = x.TournamentId, x.Name },null));
    }
}
