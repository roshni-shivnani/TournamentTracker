using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
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
    }
}
