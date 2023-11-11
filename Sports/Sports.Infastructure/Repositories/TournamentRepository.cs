using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sports.Domain.DTOs;
using Sports.Domain.Entities;
using Sports.Infastructure.Abstractions;
using Sports.Infastructure.DataContext;

namespace Sports.Infastructure.Repositories
{
    public class TournamentRepository:GenericRepository<Tournament> ,ITournamentRepository
    {
        public TournamentRepository(SportsDbContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public async Task<bool> DeleteTournament(int Id)
        {
           var teams= _context.TeamTournaments.Where(x=>x.TournamentId==Id).ToList();
            if(teams is not null)
            {
        _context.TeamTournaments.RemoveRange(teams);
            }
                _context.Tournaments.Remove(_context.Tournaments.FirstOrDefault(x=>x.TournamentId==Id));

            var result = _context.SaveChanges(); 
            return result>=1?true:false;
        }

        public async Task<TournamentDTO> PostTournamentTeams(TournamentDTO tournamentDTO)
        {
            using var transaction= _context.Database.BeginTransaction();
            try
            {
              var data =  mapper.Map<Tournament>(tournamentDTO);
               await _context.Tournaments.AddAsync(data);
              await  _context.SaveChangesAsync();
                
                foreach (var item in tournamentDTO.TeamIds)
                {
                    await _context.TeamTournaments.AddAsync(new TeamTournament { TeamId = item, TournamentId = data.TournamentId });
                    await _context.SaveChangesAsync();

                }

                await transaction.CommitAsync();
                return tournamentDTO;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<TournamentDTO> PutTournamentTeams(TournamentDTO tournamentDTO)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {

                var entity = mapper.Map<Tournament>(tournamentDTO);
                _context.Entry(entity).State = EntityState.Modified; 
                _context.TeamTournaments.RemoveRange(_context.TeamTournaments.Where(x => x.TournamentId == tournamentDTO.TournamentId).ToList());              
                 _context.SaveChanges();
                foreach (var item in tournamentDTO.TeamIds)
                {
                     _context.TeamTournaments.Add(new TeamTournament { TeamId = item, TournamentId = (int)tournamentDTO.TournamentId});
                    _context.SaveChanges();

                }

                await transaction.CommitAsync();
                return tournamentDTO;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
