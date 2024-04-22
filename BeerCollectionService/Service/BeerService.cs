using AutoMapper;
using BeerCollectionBusinessLogic.IService;
using BeerCollectionDataAccess.Interfaces;
using BeerCollectionDataAccess.Models;
using BeerCollectionDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BeerCollectionBusinessLogic.Service
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BeerService> _logger;

        public BeerService(IBeerRepository beerRepository , IMapper mapper , ILogger<BeerService> logger)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public void AddBeer(BeerDto beerDTO)
        {
            var beer = _mapper.Map<Beer>(beerDTO);
            _beerRepository.AddBeer(beer);
        }

        public List<BeerDto> GetAllBeers()
        {
            try
            {
                var beers = _beerRepository.GetAllBeers();
                return _mapper.Map<List<BeerDto>>(beers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error happened while getting the beers.");
                throw new Exception("An error happened while getting the beers.");
            }
           
        }

        public List<BeerDto> SearchBeerByName(string name)
        {
            var beers = _beerRepository.SearchBeerByName(name);
            return _mapper.Map<List<BeerDto>>(beers);

        }

        public void UpdateBeerRating(int id, int newRating)
        {
            _beerRepository.UpdateBeerRating(id, newRating);
        }
    }
}

