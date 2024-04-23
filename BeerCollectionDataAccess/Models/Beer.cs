using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCollectionDataAccess.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
    }
}
