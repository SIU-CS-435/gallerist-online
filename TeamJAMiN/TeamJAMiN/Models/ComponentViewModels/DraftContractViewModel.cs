using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;
using TeamJAMiN.Models.GameViewHelpers;

namespace TeamJAMiN.Models.ComponentViewModels
{
    public class DraftContractViewModel
    {
        public DraftContractViewModel(GameContract contract, GameContractLocation location)
        {
            Contract = contract;
            BonusClass = IconCss.BonusClass[contract.Bonus];
            State = GameActionState.ContractDraft;
            Location = location;
        }

        public GameActionState State { get; private set; }
        public GameContractLocation Location { get; private set; }

        public GameContract Contract { get; private set; }
        public string BonusClass { get; private set; }
    }
}