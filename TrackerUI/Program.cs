using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new CreateTournamentForm());

            TrackerLibrary.GlobalConfig.IntializeConnections(DatabaseType.Sql);//intead of sql write textfile          //to vrfy createteamfrm vhng to sql //selectedmemeber to txt file -TEtextfiel
            //Application.Run(new TournamentViewerForm());
            Application.Run(new CreateTournamentForm());

        }
    }
}
