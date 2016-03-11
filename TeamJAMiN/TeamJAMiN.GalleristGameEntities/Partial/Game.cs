using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public partial class Game
    {
        public void AddArtStack(List<TemplateArt> artList)
        {
            var i = 0;
            foreach (TemplateArt art in artList)
            {
                var gameArt = new GameArt(art);
                gameArt.Order = i++;
                Art.Add(gameArt);
            }
        }
        public void AddArtStack(Dictionary<ArtType, List<TemplateArt>> artDict)
        {
            foreach (var artList in artDict.Values)
            {
                var i = 0;
                foreach (TemplateArt art in artList)
                {
                    var gameArt = new GameArt(art);
                    gameArt.Order = i++;
                    Art.Add(gameArt);
                }
            }
        }
        public void AddArtists(List<TemplateArtist> artists, List<BonusType> artistBonuses)
        {
            foreach (TemplateArtist artist in artists)
            {
                var gameArtist = new GameArtist(artist);
                gameArtist.DiscoverBonus = artistBonuses[0];
                artistBonuses.RemoveAt(0);
                Artists.Add(gameArtist);
            }
        }
        public void AddReputationTiles(List<TemplateReputationTile> tiles)
        {
            foreach (TemplateReputationTile tile in tiles)
            {
                var gameTile = new GameReputationTile(tile);
                ReputationTiles.Add(gameTile);
            }
        }
        public void AddContracts(List<TemplateContract> contracts)
        {
            var i = 0;
            foreach (TemplateContract contract in contracts)
            {
                var gameContract = new GameContract(contract);
                gameContract.Order = i++;
                Contracts.Add(gameContract);
            }
        }
    }
}
