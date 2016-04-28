using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.DataContexts;
using TeamJAMiN.GalleristComponentEntities;
using TeamJAMiN.Models;

namespace TeamJAMiN.Controllers.GameControllerHelpers
{
    public class GameManager
    {
        private static GameResponse CheckGameState(Game game, GalleristComponentsDbContext galleristContext)
        {
            var gameResponse = new GameResponse
            {
                Game = game,
                Success = false,
                Message = "",
                Title = ""
            };

            if (game == null || galleristContext == null)
            {
                gameResponse.Title = "Not Found";
                gameResponse.Message = "Sorry but this does not appear to be a valid game.";
                gameResponse.Success = false;
            }
            //nothing bad happened
            else
            {
                gameResponse.Success = true;
            }

            return gameResponse;
        }

        public static GameResponse GetGame(int gameId, GalleristComponentsDbContext galleristContext)
        {
            var game = galleristContext.Games
                .Include("Art").Include("Artists")
                .Include("ReputationTiles")
                .Include("Contracts")
                .Include("Visitors")
                .Include("Players")
                .Include("Assistants")
                .Include("Turns")
                .FirstOrDefault(m => m.Id == gameId);
            return CheckGameState(game, galleristContext);
        }
    }

    public class GameResponse
    {
        public Game Game { get; set; }
        public bool Success { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}