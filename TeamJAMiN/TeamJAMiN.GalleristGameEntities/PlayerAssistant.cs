﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamJAMiN.GalleristComponentEntities
{
    public class PlayerAssistant
    {
        public int Id { get; set; }
        public PlayerAssistantLocation Location { get; set; }
        public Player Player;
    }
}