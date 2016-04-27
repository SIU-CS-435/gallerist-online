using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public static class AssistantManager
    {
        public static int[] AssistantCost = new int[] { 1, 2, 2, 3, 3, 4, 5, 6 };
        public static BonusType[] AssistantBonus = new BonusType[] { };
        public static void GetNewAssistant(this Player player)
        {
            var assistant = new PlayerAssistant() { Location = PlayerAssistantLocation.Office };
            player.Assistants.Add(assistant);
            player.Game.Assistants.Add(assistant);
        }
        public static int GetNextAssistantCost(this Player player)
        {
            int costIndex = player.Assistants.Count - 2;
            return GetAssistantCostByIndex(costIndex);
        }
        public static int GetAssistantCostByIndex(int index)
        {
            return AssistantCost[index];
        }
    }
}