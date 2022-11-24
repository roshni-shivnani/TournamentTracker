using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection        //whoever impemets idatacon will have a method createprize
    {
        PrizeModel CreatePrize(PrizeModel model);//a method not have public

        PersonModel CreatePerson(PersonModel model);

        TeamModel CreateTeam(TeamModel model);

        List<PersonModel> GetPerson_All();

        List<TeamModel> GetTeam_All();
    }
}
