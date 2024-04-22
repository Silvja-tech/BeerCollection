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
                // Calculate the new average rating
                var totalRating = beer.Rating * beer.RatingCount;
                beer.RatingCount++;
                beer.Rating = (totalRating + newRating) / beer.RatingCount;

                _context.SaveChanges();
            }
        }
    }
}

