using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "Tournaments";
        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))       //reference to caterizeform forech 
            {
                var p = new DynamicParameters();    //dpont waste tie in redembering
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellPhoneNumber", model.CellPhoneNumber);

                p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                model.id = p.Get<int>("@id");//different id for this,and anothr difft one for textconnector to avoid this chng config fle  Part2

                return model;
            }
        }
        //savaes a new prize to dattabase
        public PrizeModel CreatePrize(PrizeModel model)//PrizeModel is a type of class previously created class library
        {           //UI doesn't know dapper
            //model.id = 1;

            //return model;          //returns the prize information,including unique identifier

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))       //reference to caterizeform forech 
            {
                var p = new DynamicParameters();    //dpont waste tie in redembering
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);

                p.Add("@id", 0,DbType.Int32,direction : ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.id = p.Get<int>("@id");//different id for this,and anothr difft one for textconnector to avoid this chng config fle  Part2

                return model;
             }
        }  //thats all with db lets lok intotext file

        public TeamModel CreateTeam(TeamModel model)  //createteam two insert qry: 1) team 2)teammembers(insert no. ofrows for a team team member teamid,personid)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))       //reference to caterizeform forech 
            {
                var p = new DynamicParameters();    //dpont waste tie in redembering
                p.Add("@TeamName", model.TeamName);
                p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

                model.id = p.Get<int>("@id");//different id for this,and anothr difft one for textconnector to avoid this chng config fle  Part2

                foreach (PersonModel tm in model.TeamMembers)
                {
                    p = new DynamicParameters();    //dpont waste tie in redembering
                    p.Add("@TeamId", model.id);
                    //p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output); // not treq we hv teamid as id
                    p.Add("@PersonId", tm.id);

                    connection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
                }

                return model;
            }
        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {

                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();

            }
            return output;
        }

        public List<TeamModel> GetTeam_All()//each team get reocrds
        {
            //throw new NotImplementedException();
            List<TeamModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {

                output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

                foreach(TeamModel team in output)
                {
                    var p = new DynamicParameters();    //dpont waste tie in redembering
                    p.Add("@TeamId", team.id);//for dyamic para  with inuut @ paramter is thr if stored proc
                    team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam",p,commandType: CommandType.StoredProcedure).ToList();
                }

            }
            return output;
        }
    }
}
