using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using GoKartChamp.PresentationLayer;
using GoKartChamp.MemBasedDAL;
using GoKartChamp.Controllers;

namespace GoKartChamp.AppStarter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            WindowFormsFactory _formsFactory = new WindowFormsFactory();

            DriverRepository _driverRepository = DriverRepository.GetInstance();
            TrackRepository _trackRepository = TrackRepository.GetInstance();
            RaceRepository _raceRepository = RaceRepository.GetInstance();


            MainController _mainController = new MainController(_formsFactory, _driverRepository, _trackRepository, _raceRepository);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GoKartChamp.PresentationLayer.formMainWindow(_mainController));
        }
    }
}
