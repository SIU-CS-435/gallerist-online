﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public static class ActionContextFactory
    {
        public static Dictionary<GameActionState, Type> ActionToContextType = new Dictionary<GameActionState, Type>
        {
            { GameActionState.InternationalMarket, typeof(InternationalMarketContext) },
            { GameActionState.Reputation, typeof(InternationalMarketContext) },
            { GameActionState.Auction, typeof(InternationalMarketContext) },
            { GameActionState.MediaCenter, typeof(MediaCenterContext) },
            { GameActionState.Promote, typeof(MediaCenterContext) },
            { GameActionState.Hire, typeof(MediaCenterContext) },
            { GameActionState.ArtistColony, typeof(ArtistColonyContext) },
            { GameActionState.ArtistDiscover, typeof(ArtistColonyContext) },
            { GameActionState.ArtBuy, typeof(ArtistColonyContext) },
            { GameActionState.SalesOffice, typeof(SalesOfficeContext) },
            { GameActionState.ContractDraft, typeof(SalesOfficeContext) },
            { GameActionState.ContractDraw, typeof(SalesOfficeContext) },
            { GameActionState.ContractToPlayerBoard, typeof(SalesOfficeContext) },
            { GameActionState.ChooseLocation, typeof(SetupContext) },
            { GameActionState.GameStart, typeof(SetupContext) },
            { GameActionState.Pass, typeof(SetupContext) },
            { GameActionState.UseInfluenceAsFame, typeof(SetupContext) },
            { GameActionState.UseInfluenceAsMoney, typeof(SetupContext) }
        };

        public static ActionContext GetContext(GameActionState state, Game game)
        {
            Type contextType = ActionToContextType[state];
            return (ActionContext)Activator.CreateInstance(contextType, game);
        }

    }
}