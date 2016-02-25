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

        public static Dictionary<ArtType,List<Art>> shuffleArt(this Dictionary<ArtType,List<Art>> artLists)
        {
            var keys = new List<ArtType>(artLists.Keys);
            foreach ( ArtType key in keys )
            {
                artLists[key] = artLists[key].Shuffle().ToList();
            }
            return artLists;
        }

        public static Dictionary<ArtType,Artist> chooseArtists(this List<Artist> completeList)
        {
            bool firstBlue = false;
            completeList = completeList.Shuffle().ToList();
            Dictionary<ArtType,Artist> result = new Dictionary<ArtType, Artist>();
            foreach (Artist artist in completeList)
            {
                if (artist.category == ArtistCategory.blue && firstBlue == false)
                {
                    artist.discovered = true;
                    firstBlue = true;
                }
                if (!result.ContainsKey(artist.artType))
                {
                    result.Add(artist.artType,artist);
                }
            }
            return result;
        }
    }
}
