using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.Abstract
{
    public interface ISuperHeroesRepository
    {
        DbSet<SuperHero> SuperHeroes { get; }
        DbSet<SuperPower> SuperPowers { get; }
    }
}
