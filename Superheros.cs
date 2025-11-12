using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero
{
    internal class Superheros
    {
        public string Name { get; set; }

        public string ImageSourceName { get; set; }

        public double SuperheroScore { get; set; }

        public Superheros(string name, string imageSourceName, double superheroScore)
        {
            Name = name;
            ImageSourceName = imageSourceName;
            SuperheroScore = superheroScore;
        }
    }
}
