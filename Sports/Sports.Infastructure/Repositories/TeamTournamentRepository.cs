using Sports.Domain.Entities;
using Sports.Domain.Abstractions;
using Sports.Infastructure.DataContext;
using AutoMapper;

namespace Sports.Infastructure.Repositories
{
    public class TeamTournamentRepository:GenericRepository<TeamTournament>, ITeamTournamentRepository
    {
        public TeamTournamentRepository(SportsDbContext context, IMapper mapper):base(context, mapper)
        {
            
        }
    }
}
