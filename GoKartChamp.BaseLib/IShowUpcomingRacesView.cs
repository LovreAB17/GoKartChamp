using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoKartChamp.Model;

namespace GoKartChamp.BaseLib
{
    public interface IShowUpcomingRacesView
    {

        void ShowModaless(IMainController inMainController, List<Race> inUpcomingRaces);

    }
}
