using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTeam3
{

    /// <summary>
    /// Transaction class holds following data:
    /// - public string Address 
    /// - string City 
    /// - int Bedrooms 
    /// - int Bathrooms 
    /// - double SurfaceArea
    /// - string HouseType
    /// - decimal Price 
    /// </summary>
    class House
    {
        /// <summary>
        /// Data Properties
        /// </summary>
        public string Address { get; private set; }
        public string City { get; private set; }
        public int Bedrooms { get; private set; }
        public int Bathrooms { get; private set; }
        public double SurfaceArea { get; private set; }
        public string HouseType { get; private set; }
        public decimal Price { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public House(string[] data)
        {
            Address = data[0].Trim();
            City = data[1].Trim();
            Bedrooms = int.Parse(data[2].Trim());
            Bathrooms = int.Parse(data[3].Trim());
            SurfaceArea = double.Parse(data[4].Trim());
            HouseType = data[5].Trim();
            Price = decimal.Parse(data[6].Trim());
        }
       
    }
}
