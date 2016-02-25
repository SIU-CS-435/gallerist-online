using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string slug { get; set; }
        public ArtistCategory category { get; set; }
        public ArtType artType { get; set; }
        public int fame { get; set; }
        public int promotion { get; set; }
        public string starLevelData { get; set; }
        public int[] starLevels
        {
            get
            {
                return Array.ConvertAll(starLevelData.Split(';'), int.Parse);
            }
            set
            {
                starLevelData = String.Join(";", value.Select(s => s.ToString()).ToArray());
            }
        }
        public bool discovered { get; set; }
        int availableArt { get; set; }
    }

    public enum ArtistCategory
    {
        red,blue
    }
}
