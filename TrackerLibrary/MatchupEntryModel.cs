using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchupEntryModel
    {
        public TeamModel TeamCompeting { get; set; }

        public double Score { get; set; }
        //returns a parent matchup from this temaas winner
        public MatchupModel ParentMatchup { get; set; }
    }
}
