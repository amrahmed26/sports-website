using AutoMapper;
using Sports.Domain.Abstractions;
using Sports.Infastructure.Abstractions;
using Sports.Infastructure.DataContext;
using System.Collections;


namespace Sports.Infastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportsDbContext _context;
        private readonly IMapper mapper;

        private Hashtable _repositories;
        public UnitOfWork(SportsDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
            tournamentRepository=new TournamentRepository(context,mapper);
            teamRepository=new TeamRepository(context,mapper);  
        }

        public ITournamentRepository tournamentRepository { get; }
        public ITeamRepository teamRepository { get; }

        public async Task<int> Complete() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories is null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_context,mapper);
                _repositories.Add(type, repository);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }

    }
}
