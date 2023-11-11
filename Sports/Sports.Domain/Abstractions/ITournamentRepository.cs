using Sports.Domain.Abstractions;
using Sports.Domain.DTOs;
using Sports.Domain.Entities;


namespace Sports.Infastructure.Abstractions
{
    public interface ITournamentRepository:IGenericRepository<Tournament>
    {
        Task<TournamentDTO> PostTournamentTeams(TournamentDTO tournamentDTO);
        Task<TournamentDTO> PutTournamentTeams(TournamentDTO tournamentDTO);
        Task<bool> DeleteTournament(int Id);
    }
}
