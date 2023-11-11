using Microsoft.Extensions.DependencyInjection;
using Sports.Application.ServiceAbstractions;
using Sports.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Application.DI
{
    public static class ApplicationDI
    {
        public static void ApplicationStrapping(this IServiceCollection Services)
        {
            Services.AddScoped<IDropDownService, DropDownService>();
            Services.AddScoped<ITournamentService, TournamentService>();
            Services.AddScoped<ITeamService, TeamService>();
        }
    }
}
