using BeerCollectionBusinessLogic.IService;
using BeerCollectionBusinessLogic.Service;
using BeerCollectionDataAccess.Models;
using BeerCollectionDTO;
using Microsoft.AspNetCore.Mvc;

namespace BeerCollectionApi.Controllers
{
    [ApiController]
    [Route("api/beers")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpPost]
        public IActionResult AddBeer([FromBody] BeerDto beerDto)
        {

            _beerService.AddBeer(beerDto);

            return Ok("Beer added successfully");
        }

        [HttpGet]
        public IActionResult GetAllBeers()
        {
            try
            {
                var beers = _beerService.GetAllBeers();
                return Ok(beers);
            }
            catch (Exception ex )
            {

                return StatusCode(500 ,$"An error occurred while getting data with message:{ex.Message}");
            }
           
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchBeer(string name)
        {
            var beers = _beerService.SearchBeerByName(name);
            return Ok(beers);
        }

        [HttpPut("{id}/rating")]
        public IActionResult UpdateBeerRating(int id, int newRating)
        {
            if (newRating < 1 || newRating > 5)
            {
                return BadRequest("Rating must be between 1 and 5");
            }

            _beerService.UpdateBeerRating(id, newRating);
            return Ok("Beer rating updated successfully");
        }
    }
}

