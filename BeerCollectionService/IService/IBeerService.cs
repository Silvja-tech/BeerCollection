using BeerCollectionDataAccess.Models;
using BeerCollectionDTO;

namespace BeerCollectionBusinessLogic.IService
{
    public interface IBeerService
    {
        void AddBeer(BeerDto beer);
        List<BeerDto> GetAllBeers();
        List<BeerDto> SearchBeerByName(string name);
        void UpdateBeerRating(int id, int newRating);

    }
}
