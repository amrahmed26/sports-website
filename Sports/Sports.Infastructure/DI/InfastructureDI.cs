using Microsoft.Extensions.DependencyInjection;
using Sports.Domain.Abstractions;
using Sports.Infastructure.Abstractions;
using Sports.Infastructure.Repositories;
using System.Reflection;

namespace Sports.Infastructure.DI
{
    public static class InfastructureDI
    {
        public static void InfastructureStrapping(this IServiceCollection Services)
        {

            Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddScoped<ITeamRepository, TeamRepository>();
            Services.AddScoped<ITournamentRepository, TournamentRepository>();
            Services.AddScoped<ITeamTournamentRepository, TeamTournamentRepository>();
            Services.AddScoped<IPlayerRepository, PlayerRepository>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
