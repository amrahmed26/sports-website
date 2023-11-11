﻿using Sports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Domain.Abstractions
{
    public interface IPlayerRepository:IGenericRepository<Player>
    {
    }
}
