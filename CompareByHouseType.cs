using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTeam3
{
    class CompareByHouseType : IComparer<House>
    {

        /// <summary>
        /// Compare/Sort by HouseType property
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        public int Compare(House x, House y)
        {
            return x.HouseType.CompareTo(y.HouseType);

        }
    }
}
