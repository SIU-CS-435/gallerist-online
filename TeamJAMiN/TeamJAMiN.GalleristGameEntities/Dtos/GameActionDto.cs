using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities.Dtos
{
    public class GameActionDto
    {
        public string Action { get; set; } //todo: enum, eventually markov chain
        public int? MoneyAmountSpent { get; set; }
        public int? InfluenceAmountSpent { get; set; }
        //todo: figure out a list of all possible values a user could pass back to the server for each action type 
    }
}
