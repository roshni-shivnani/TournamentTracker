using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess.TextHelpers;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {

        private const string PrizesFile = "PrizeModels.csv";

        private const string PeopleFile = "PersonModels.csv";//for text conn team

        private const string TeamFile = "TeamModels.csv";

        public PersonModel CreatePerson(PersonModel model)
        {
            //throw new NotImplementedException();
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();//add contnt

            int currentid = 1;

            if(people.Count>0)
            {
               currentid=people.OrderByDescending(x=>x.id) .First().id+1;
            }
            model.id = currentid;

            people.Add(model);

            people.SaveToPeopleFile(PeopleFile);

            return model;

        }

        //wire up crateprize for text files


        public PrizeModel CreatePrize(PrizeModel model)       //uncomme t for better
        {
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();
            //model.id = 1;

            //return model;

            int currentId = 1; /*prizes.OrderByDescending(x => x.id).First().id + 1;*/ //ncomment give error

            if (prizes.Count < 0)
            {
                currentId = prizes.OrderByDescending(x => x.id).First().id + 1;
            }
            model.id = currentId;

            prizes.Add(model);

            prizes.SaveToPrizeFile(PrizesFile);//updates .csv file

            return model;
            //Load the text file
            //Convert the text to List<PrizeModel>
            //Find the new ID
            //Add the new record with the new ID (max=1)
            //Convert the prizes to list<string>
            //Save the list<string> to the text file
        }

        

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModel(TeamFile);

            int currentId = 1;
            if(teams.Count>0)
            {
                currentId = teams.OrderByDescending(x => x.id).First().id + 1;
            }
            model.id = currentId;

            teams.Add(model);
            teams.SaveToTeamFile(TeamFile);
            return model;
        }

        public List<PersonModel> GetPerson_All()
        {
            //throw new NotImplementedException();
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }

        public List<TeamModel> GetTeam_All()
        {
            throw new NotImplementedException();
        }
    }
}
