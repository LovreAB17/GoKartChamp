using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoKartChamp.Model;

namespace GoKartChamp.BaseLib
{
    public interface IEnterResultsView
    {

        bool ShowViewModal(List<Race> upRaces, List<Driver> activeDrivers);

        string RaceName { get; }

        string Result { get; }

        string FastestLap { get; }



    }
}
