using System;
using System.Collections.Generic;
using System.Text;

namespace project1.models
{
    public class CityModel
    {
        public string City { get; set; }
        public Boolean Favourite { get; set; }
        public CityModel(string city, Boolean favourite)
        {
            City = city;
            Favourite = favourite;
        }
    }
}
