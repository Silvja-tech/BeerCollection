using BeerCollectionDataAccess.Models;

namespace BeerCollectionDataAccess.Interfaces
{
    public interface IBeerRepository
    {
        void AddBeer(Beer beer);
        List<Beer> GetAllBeers();
        List<Beer> SearchBeerByName(string name);
        void UpdateBeerRating(int id, int newRating);
    }
}
