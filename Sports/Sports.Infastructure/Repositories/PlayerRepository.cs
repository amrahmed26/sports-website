using AutoMapper;
using Sports.Domain.Abstractions;
using Sports.Domain.Entities;
using Sports.Infastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Infastructure.Repositories
{
    public class PlayerRepository:GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(SportsDbContext context, IMapper mapper) : base(context, mapper)
        {
            
        }
    }
}
