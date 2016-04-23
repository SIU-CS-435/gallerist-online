using System;
using System.Collections.Generic;
using System.Linq;
using TeamJAMiN.Controllers.GameLogicHelpers;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameControllerHelpers
{
    public static class SetupPlayers
    {
        public static void SetupPlayerStart(this Game newGame)
        {
            newGame.AssignColors();
            foreach (Player player in newGame.Players)
            {
                player.GetNewAssistant();
                player.GetNewAssistant();
                player.GalleristLocation = PlayerLocation.Gallery;
            }
            newGame.PlayerOrder = newGame.Players.Shuffle().ToList();
            newGame.SetupFirstTurn();
        }
        public static void AssignColors(this Game newGame)
        {
            var rPlayers = newGame.Players.Shuffle();
            var colorEnum = ((PlayerColor[])Enum.GetValues(typeof(PlayerColor))).Shuffle().GetEnumerator(); ;
            foreach (Player player in rPlayers)
            {
                colorEnum.MoveNext();
                if (colorEnum.Current == PlayerColor.none)
                {
                    colorEnum.MoveNext();
                }
                player.Color = (PlayerColor)colorEnum.Current;
            }
        }

        public static void SetNextPlayer(this Game game)
        {
            game.CurrentPlayerId = game.PlayerOrder[0].Id;
            if (game.Players.Count != 1) //todo add logic for kicked out or executive actions
            {
                var isRemoved = game.PlayerOrder.Remove(game.CurrentPlayer);
                game.PlayerOrder.Add(game.CurrentPlayer);
                game.PlayerOrder = game.PlayerOrder;
            }
        }
}
}