using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTeam3
{
    class CompareByPrice : IComparer<House>
    {

        /// <summary>
        /// Compare/Sort by Price property
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        public int Compare(House x, House y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
