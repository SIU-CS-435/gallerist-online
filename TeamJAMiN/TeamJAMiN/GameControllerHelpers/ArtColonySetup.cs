using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.GameControllerHelpers
{
    public static class ArtColonySetup
    {

        public static Dictionary<ArtType,List<TemplateArt>> shuffleArt(this Dictionary<ArtType,List<TemplateArt>> artLists, Game game)
        {
            var keys = new List<ArtType>(artLists.Keys);
            foreach ( ArtType key in keys )
            {
                artLists[key] = artLists[key].Shuffle().ToList();
                var i = 0;
                foreach (TemplateArt art in artLists[key])
                {
                    var gameArt = new GameArt(art);
                    gameArt.Order = i++;
                    game.Art.Add(gameArt);
                }

            }
            return artLists;
        }

        public static Dictionary<ArtType,TemplateArtist> chooseArtists(this List<TemplateArtist> completeList)
        {
            bool firstBlue = false;
            completeList = completeList.Shuffle().ToList();
            Dictionary<ArtType,TemplateArtist> result = new Dictionary<ArtType, TemplateArtist>();
            foreach (TemplateArtist artist in completeList)
            {
                if (artist.Category == ArtistCategory.blue && firstBlue == false)
                {
                    artist.Discovered = true;
                    firstBlue = true;
                }
                if (!result.ContainsKey(artist.ArtType))
                {
                    result.Add(artist.ArtType,artist);
                }
            }
            return result;
        }
    }
}
