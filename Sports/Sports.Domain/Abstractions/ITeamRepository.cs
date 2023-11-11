using Sports.Domain.Entities;


namespace Sports.Domain.Abstractions
{
    public interface ITeamRepository:IGenericRepository<Team>
    {
        Task<object> LastXAddedTeams(int count);
        Task<object> GetTeamsByTournament(int Id);
        Task<bool> DeleteTeam(int Id);
    }
}
