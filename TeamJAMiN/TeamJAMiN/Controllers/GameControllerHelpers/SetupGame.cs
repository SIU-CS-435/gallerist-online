using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.Controllers.GameLogicHelpers;
using TeamJAMiN.DataContexts;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameControllerHelpers
{
    public static class SetupGame
    {
        public static void CreateRandomSetup(this Game newGame)
        {
            using (var galleristContext = new GalleristComponentsDbContext())
            {
                //put list building on separate lines for clarity
                var gameTemplate = galleristContext.TemplateGames.Where(g => g.Name == "GameResources").FirstOrDefault();
                var artLists = gameTemplate.Art.ToList().chooseArt();
                newGame.AddArtStack(artLists);

                var blueArtists = gameTemplate.Artists.Where(a => a.Category == ArtistCategory.red).ToList().chooseArtists();
                var redArtists = gameTemplate.Artists.Where(a => a.Category == ArtistCategory.blue).ToList().chooseArtists();
                var artBonuses = ArtColonySetup.chooseArtBonuses();

                newGame.AddArtists(blueArtists.Values.ToList(),artBonuses);
                newGame.AddArtists(redArtists.Values.ToList(),artBonuses);


                var reputationTiles = gameTemplate.ReputationTiles.ToList().chooseReputationTiles();
                newGame.AddReputationTiles(reputationTiles);

                var contracts = gameTemplate.Contracts.ToList().Shuffle().ToList();
                newGame.AddContracts(contracts);
                newGame.DrawContracts();
            }
        }

        public static void StartGame(this Game newGame)
        {
            newGame.ChooseVisitors();
            newGame.setupPlayers(); //must happen before visitor draw
            newGame.DrawInitialVisitors();
            newGame.SetupTickets();
            newGame.assignReputationTiles();
            newGame.IsStarted = true;
            newGame.CurrentActionState = GameActionState.GameStart;
            (new ActionManager(newGame)).DoAction(GameActionState.Pass);
        }
    }
}