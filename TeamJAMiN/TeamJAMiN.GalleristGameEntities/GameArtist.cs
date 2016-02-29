﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class GameArtist
    {
        public int Id { get; set; }
        public ArtistCategory Category { get; set; }
        public ArtType ArtType { get; set; }
        public int Fame { get; set; }
        public int Promotion { get; set; }
        public string StarLevelData { get; set; }
        public int[] StarLevels
        {
            get
            {
                return Array.ConvertAll(StarLevelData.Split(';'), int.Parse);
            }
            set
            {
                StarLevelData = String.Join(";", value.Select(s => s.ToString()).ToArray());
            }
        }
        public bool IsDiscovered { get; set; }
        int AvailableArt { get; set; }
    }
}
