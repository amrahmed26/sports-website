using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sports.Domain.Abstractions;
using Sports.Domain.DTOs;
using Sports.Domain.Entities;
using Sports.Infastructure.DataContext;

namespace Sports.Infastructure.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(SportsDbContext context,IMapper mapper):base(context,mapper)
        {
                
        }

        public async Task<bool> DeleteTeam(int Id)
        {
            var teams = _context.TeamTournaments.Where(x => x.TeamId == Id).ToList();
            _context.TeamTournaments.RemoveRange(teams);
            _context.Teams.Remove(_context.Teams.FirstOrDefault(x => x.TeamId == Id));
            var result = _context.SaveChanges();
            return result >= 1 ? true : false;
        }

        public async Task<object> GetTeamsByTournament(int Id)
        {
            var data=await (from team in _context.Teams
                      join tournament in _context.TeamTournaments
                      on team.TeamId equals tournament.TeamId 
                      where tournament.TournamentId==Id 
                      select new 
                      {
                          team.TeamId,
                          team.TeamName,
                          team.Logo
                      }
                     
                ).ToListAsync();
            return data;
        }

        public async Task<object> LastXAddedTeams(int count)=>
            await _context.Teams.Take(count).OrderByDescending(x=>x.TeamId).ToListAsync();
       
    }
}
