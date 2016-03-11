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
        private static GameResponse CheckGameState(Game game, GalleristComponentsDbContext galleristContext, string username, ApplicationDbContext identityContext)
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

            //you passed in bad variables, stop doing that
            else if (string.IsNullOrWhiteSpace(username) || identityContext == null)
            {
                gameResponse.Title = "Not Authorized";
                gameResponse.Message = "Sorry but you are not authorized to play this game.";
                gameResponse.Success = false;
            }
            //new player joining a game
            else if (!game.Players.Any(m => m.UserId == identityContext.Users.First(u => u.UserName == username).Id))
            {
                //TODO: check game player restrictions (e.g. friends only, are there invites sent to a specific player, etc.). This is not yet implemented

                if (game.Players.Count() >= game.MaxNumberOfPlayers) //no room left
                {
                    gameResponse.Title = "Game Full";
                    gameResponse.Message = "Sorry, but this game is full and cannot support any additional players =(";
                    gameResponse.Success = false;
                }
                else
                {
                    gameResponse.Success = true;
                }
            }

            //nothing bad happened
            else
            {
                gameResponse.Success = true;
            }

            return gameResponse;
        }

        public static GameResponse GetGame(int gameId, string username, GalleristComponentsDbContext galleristContext, ApplicationDbContext userContext)
        {
            var game = galleristContext.Games.Include("Art").Include("Artists").Include("ReputationTiles").Include("Contracts").Include("Visitors").Include("Players").FirstOrDefault(m => m.Id == gameId);
            return CheckGameState(game, galleristContext, username, userContext);
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