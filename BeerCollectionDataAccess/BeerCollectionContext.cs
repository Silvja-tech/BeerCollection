using BeerCollectionDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCollectionDataAccess
{
    public class BeerCollectionContext : DbContext
    {
        public BeerCollectionContext(DbContextOptions<BeerCollectionContext> options) : base(options)
        {

        }

        public DbSet<Beer> Beers { get; set; }

        
    }
}
