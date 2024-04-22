using AutoMapper;
using BeerCollectionDataAccess.Models;
using BeerCollectionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCollectionDataAccess.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<BeerDto, Beer>();
            CreateMap<Beer, BeerDto>();

        }
    }
}
