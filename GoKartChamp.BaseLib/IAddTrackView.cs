using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib
{
    public interface IAddTrackView
    {

        bool ShowViewModal();

        string TrackName { get; }
        string TrackLocation { get; }
        int TrackLength { get; }


    }
}
