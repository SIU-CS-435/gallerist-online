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
        public static Dictionary<ArtType, List<TemplateArt>> chooseArt(this List<TemplateArt> completeList)
        {
            var result = new Dictionary<ArtType, List<TemplateArt>>();
            foreach (ArtType type in Enum.GetValues(typeof(ArtType)))
            {
                result.Add(type, completeList.Where(a => a.Type == type).ToList());
                result[type] = result[type].Shuffle().ToList();
            }
            return result;
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
                    artist.IsDiscovered = true;
                    firstBlue = true;
                }
                else
                    artist.IsDiscovered = false;
                if (!result.ContainsKey(artist.ArtType))
                    result.Add(artist.ArtType,artist);
            }
            return result;
        }
    }
}
