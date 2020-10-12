using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoKartChamp.Model;

namespace GoKartChamp.BaseLib
{
    public interface IShowRaceResultsView
    {

        void ShowModaless(Race race, List<Driver> drivers, Driver fastestLap, List<int> points);


    }
}
