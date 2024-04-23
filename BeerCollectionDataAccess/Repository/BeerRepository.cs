using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerCollectionDataAccess.Interfaces;
using BeerCollectionDataAccess.Models;

namespace BeerCollectionDataAccess.Repository
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BeerCollectionContext _context;

        public BeerRepository(BeerCollectionContext context)
        {
            _context = context;
        }

        public void AddBeer(Beer beer)
        {
            _context.Beers.Add(beer);
            _context.SaveChanges();
        }

        public List<Beer> GetAllBeers()
        {
            return _context.Beers.ToList();
        }

        public List<Beer> SearchBeerByName(string name)
        {
            return _context.Beers.Where(b => b.Name.Contains(name)).ToList();
        }

        public void UpdateBeerRating(int id, int newRating)
        {
            var beer = _context.Beers.FirstOrDefault(b => b.Id == id);
            if (beer != null)
            {
                double totalRating = beer.Rating != 0 ? beer.Rating : 0;
                double averageRating = (totalRating + newRating) / 2;

                beer.Rating = averageRating;

                _context.SaveChanges();
            }
        }
    }
}

