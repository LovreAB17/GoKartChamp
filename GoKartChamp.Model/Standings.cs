using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model
{
    public static class Standings
    {

        public static List<Driver> GetStandings(List<Driver> _drivers)
        {
            return _drivers.OrderByDescending(o => o.Points).ToList();
        }

    }
}
