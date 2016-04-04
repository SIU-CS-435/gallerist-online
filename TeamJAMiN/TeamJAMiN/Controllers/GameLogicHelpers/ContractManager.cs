using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public static class ContractManager
    {
        //todo check if draw deck is empty before drawing and take actions as appropriate
        //i.e. write method for shuffling discard/draft as per the rulebook
        public static bool IsContractLocationEmpty(this Game game, GameContractLocation location)
        {
            return game.Contracts.Any(c => c.Location == location);
        }
        public static void ReplaceContract(this Game game, GameContractLocation location)
        {
            game.DrawContract(location);
        }

        public static GameContract DrawContract(this Game game, GameContractLocation location)
        {
            var deckDict = game.GetContractDecks();
            var contract = deckDict[GameContractLocation.DrawDeck].First();
            contract.Location = location;
            contract.Order = deckDict[location].Count;
            return contract;
        }

        public static List<GameContract> DrawContracts(this Game game)
        {
            var locationOrder = new List<GameContractLocation> { GameContractLocation.Draft0, GameContractLocation.Draft1, GameContractLocation.Draft2, GameContractLocation.Draft3 };
            var deckDict = game.GetContractDecks();
            var drawnContracts = deckDict[GameContractLocation.DrawDeck].Take(4);
            var drawnIterator = drawnContracts.GetEnumerator();
            foreach ( GameContractLocation location in locationOrder )
            {
                drawnIterator.MoveNext();
                drawnIterator.Current.Order = deckDict[location].Count;
                drawnIterator.Current.Location = location;
            }
            return drawnContracts.ToList();
        }

        public static Dictionary<GameContractLocation,List<GameContract>> GetContractDecks( this Game game)
        {
            var result = new Dictionary<GameContractLocation, List<GameContract>> {
                { GameContractLocation.DrawDeck, game.Contracts
                    .Where(c => c.Location == GameContractLocation.DrawDeck)
                    .OrderBy(c => c.Order)
                    .ToList()
                },
                { GameContractLocation.Draft0, game.Contracts
                    .Where(c => c.Location == GameContractLocation.Draft0).OrderByDescending(c => c.Order).ToList()
                },
                { GameContractLocation.Draft1, game.Contracts
                    .Where(c => c.Location == GameContractLocation.Draft1).OrderByDescending(c => c.Order).ToList()
                },
                { GameContractLocation.Draft2, game.Contracts
                    .Where(c => c.Location == GameContractLocation.Draft2).OrderByDescending(c => c.Order).ToList()
                },
                { GameContractLocation.Draft3, game.Contracts
                    .Where(c => c.Location == GameContractLocation.Draft3).OrderByDescending(c => c.Order).ToList()
                },
            };
            return result;
        }
    }
}