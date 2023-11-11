using Microsoft.AspNetCore.Mvc;
using Sports.Application.ServiceAbstractions;
using Sports.Domain.DTOs;

namespace Sports.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentService tournamentService;
        public TournamentsController(ITournamentService tournamentService)
        {
            this.tournamentService = tournamentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await tournamentService.GetTournaments();
            return result.StatusCode == 200 ? Ok(result) : NotFound(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute]int Id)
        {
            var result=await tournamentService.GetTournament(Id);
            return result.StatusCode==200?Ok(result) : NotFound(result);
        }  
        [HttpGet("GetForUpdate/{Id}")]
        public async Task<IActionResult> GetForUpdate([FromRoute]int Id)
        {
            var result=await tournamentService.GetTournamentForUpdate(Id);
            return result.StatusCode==200?Ok(result) : NotFound(result);
        }     
        [HttpGet("SearchTournamentByTitle/{Key}")]
        public async Task<IActionResult> SearchTournamentByTitle([FromRoute]string Key)
        {
            var result=await tournamentService.SearchTournamentByTitle(Key);
            return result.StatusCode==200?Ok(result) : NotFound(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]TournamentDTO tournamentDTO)
        {
            var result=await tournamentService.PostTournament(tournamentDTO);
            return result.StatusCode == 201?Created(nameof(Post),result):BadRequest(result);    
        } 
        [HttpPut]
        public async Task<IActionResult> Put([FromForm]TournamentDTO tournamentDTO)
        {
            var result=await tournamentService.PutTournament(tournamentDTO);
            return result.StatusCode == 204?Created(nameof(Post),result):BadRequest(result);    
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result=await tournamentService.DeleteTournament(Id);
            return result.StatusCode == 200?Ok():BadRequest(result);    
        }
    }
}
