﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class TextConnectior : IDataConnection
    {



        //wire up crateprize for text files
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.id = 1;

            return model;
        }

    }
}
