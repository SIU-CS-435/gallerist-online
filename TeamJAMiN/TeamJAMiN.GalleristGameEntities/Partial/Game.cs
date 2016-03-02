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
        public void AddArtists(List<TemplateArtist> artists)
        {
            foreach (TemplateArtist artist in artists)
            {
                var gameArtist = new GameArtist(artist);
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
            foreach (TemplateContract contract in contracts)
            {
                var gameContract = new GameContract(contract);
                Contracts.Add(gameContract);
            }
        }
    }
}
