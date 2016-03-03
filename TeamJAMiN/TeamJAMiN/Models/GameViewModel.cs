using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamJAMiN.Models
{
    public class GameViewModel
    {
        [Display(Name = "Pick a name for your game")]
        public string Name { get; set; }

        [Display(Name = "Maximum number of players")]
        [Range(1, 4, ErrorMessage = "Please enter a number between 1 and 4")]
        [DefaultValue(4)]
        public int MaxNumberOfPlayers { get; set; }

        [Display(Name = "Maximum time per turn in minutes")]
        [Range(1, 1440, ErrorMessage = "Please enter a value between 1 and 1440")]
        [DefaultValue(60)]
        public int TurnLength { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
    }
}