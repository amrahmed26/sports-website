

using Sports.Infastructure.Abstractions;

namespace Sports.Domain.Abstractions
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        public ITournamentRepository tournamentRepository{ get; }
        public ITeamRepository teamRepository{ get; }
        Task<int> Complete();
    }
}
