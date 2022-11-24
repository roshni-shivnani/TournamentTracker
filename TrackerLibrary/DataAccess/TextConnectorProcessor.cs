using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers//not acual but to hide name
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName) //PrizeMdels.csv
        {      //C:\data\TournamentTracker\PrizeModels.csv
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }
        public static List<string> LoadFile(this string file)  //takes filename and loads file as string
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();



        }

        public static List<PersonModel> ConvertToPersonModel(this List<string> lines)
        {
            List<PersonModel> output=new List<PersonModel>();
            foreach(string line in lines)
            {
                string[] cols=line.Split(',');//if your data contains , it is prob cret unnssary prob

                PersonModel p = new PersonModel();
                p.id = int.Parse(cols[0]);
                p.FirstName= cols[1];
                p.LastName= cols[2];
                p.EmailAddress= cols[3];
                p.CellPhoneNumber= cols[4];
                output.Add(p);

            }
            return output;
        }
        public static List<PrizeModel> ConvertToPrizeModel(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }
            return output;
        }
        public static void SaveToPrizeFile(this List<PrizeModel> models,  string fileName  )
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);//obervcrwrites contentif file found otherwiese new file
            
        }
        public static void SaveToPeopleFile(this List<PersonModel> models,string fileName)
        {
            List<string> lines=new List<string>();

            foreach(PersonModel p in models)
            {
                lines.Add($"{p.id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellPhoneNumber}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static List<TeamModel> ConvertToTeamModel(this List<string> lines,string peopleFileName)
        {
            //id,team name, add to pipe
            //3,Tim's team,1|3|5
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModel();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel t = new TeamModel();

                t.id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');//silt & stroe

                foreach(string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.id == int.Parse(id)).First()); //parse.id() is of forech id
                }
            }
            return output;
        }

        public static void SaveToTeamFile(this List<TeamModel> models,string fileName)
        {
            List<string> lines= new List<string>();

            foreach(TeamModel t in models)
            {
                lines.Add($"{t.id},{t.TeamName},{ConvertPeopleListToString(t.TeamMembers)}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";

            if(people.Count==0)
            {
                return "";
            }
            //2|5
            foreach(PersonModel p in people)
            {
                output += $"{p.id}|";
            }

            output=output.Substring(0,output.Length-1);

            return output;

           
        }
    }
}
