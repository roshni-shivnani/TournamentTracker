using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        public int id { get; set; }         //unique identifier for each prize
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }

        public decimal PrizeAmount { get; set; }

        public double PrizePercentage { get; set; }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {

            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            int prizeAmountValue = 0;
            int.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            int prizePercentageValue = 0;
            int.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
            //PriceAmount = priceAmount;
        }
        public PrizeModel()
        {

        }
    }
}
