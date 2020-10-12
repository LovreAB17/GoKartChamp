using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoKartChamp.Model;

namespace GoKartChamp.BaseLib
{
    public interface IShowFinishedRacesView
    {

        void ShowModaless(IMainController inMainController, List<Race> inFinishedRaces);

    }
}