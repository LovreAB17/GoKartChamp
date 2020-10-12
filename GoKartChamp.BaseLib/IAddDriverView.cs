using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib
{
    public interface IAddDriverView
    {

        bool ShowViewModal();

        int DriverGoKart { get; }
        string DriverFirstName { get; }
        string DriverLastName { get; }
        

    }
}
