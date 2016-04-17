using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public class BonusContext : ActionContext
    {
        public BonusContext(Game game)
            : base(game, new Dictionary<GameActionState, Type> {
                { GameActionState.GetTicketVip, typeof(GetTicketVip) },
                { GameActionState.GetTicketInvestor, typeof(GetTicketInvestor) },
                { GameActionState.GetTicketCollector, typeof(GetTicketCollector) },
                { GameActionState.GetMoney, typeof(GetMoney) },
                { GameActionState.GetInfluence, typeof(GetInfluence) },
                { GameActionState.GetAssistant, typeof(GetAssistant) },
                { GameActionState.ChooseContract, typeof(ChooseLocation) },
                { GameActionState.ChooseTicketAny, typeof(ChooseLocation) },
                { GameActionState.ChooseTicketAnyTwo, typeof(ChooseLocation) },
                { GameActionState.ChooseTicketCollectorVip, typeof(ChooseLocation) },
                { GameActionState.ChooseTicketCollectorInvestor, typeof(ChooseLocation) },
                { GameActionState.ChooseTicketToThrowAway, typeof(ChooseLocation) },
                { GameActionState.ChooseVisitorFromPlaza, typeof(ArtistColony) },
                { GameActionState.ChooseVisitorFromPlazaVipInvestor, typeof(ArtistColony) },
                { GameActionState.ChooseVisitorFromBag, typeof(ArtistColony) },
                { GameActionState.ChooseArtistFame, typeof(ArtistDiscover) },
            })
        { }
        public abstract class BonusAction : ActionState
        {
            //need a solution for transition validation, possibly compile a list of places the bonus action occurs, and use base.IsValidTransition
            //possibly add a checkPendingAction method to validate transition and enforce setting a pending action after a bonus
            //possibly add a set transition method just for bonus actions that caller can use since it probably knows what happens next
            //oh we can use the set transition method for handling executive actions too? except an in memory solution doesn't really work
        }

        public abstract class GetTicket : BonusAction
        {
            public VisitorTicketType Type;
            public override void DoAction<ArtistColonyContext>(ArtistColonyContext context)
            {
                var game = context.Game;
                //todo check if ticket stack is empty before getting a ticket
                //if stack is empty add a pending ChooseTicketToThrowaway
                game.CurrentPlayer.GetTicket(Type);
                //todo check if ticket stack is newly empty after getting a ticket
                //if stack is newly empty trigger bonuses or add game end condition
            }
            public override bool IsValidGameState(ActionContext context)
            {
                var game = context.Game;

                if (game.AvailableVipTickets == 0 && game.AvailableInvestorTickets == 0 && game.AvailableCollectorTickets == 0)
                {
                    return false;
                }

                return true;
            }
        }

        public class GetTicketVip : GetTicket
        {
            public GetTicketVip()
            {
                Name = GameActionState.GetTicketVip;
                Type = VisitorTicketType.vip;
                TransitionTo = new HashSet<GameActionState> { };
            }
        }
        public class GetTicketInvestor : GetTicket
        {
            public GetTicketInvestor()
            {
                Name = GameActionState.GetTicketInvestor;
                Type = VisitorTicketType.investor;
                TransitionTo = new HashSet<GameActionState> { };
            }
        }
        public class GetTicketCollector : GetTicket
        {
            public GetTicketCollector()
            {
                Name = GameActionState.GetTicketCollector;
                Type = VisitorTicketType.collector;
                TransitionTo = new HashSet<GameActionState> { };
            }
        }

        public class GetAssistant : BonusAction
        {
            public GetAssistant()
            {
                Name = GameActionState.GetAssistant;
                TransitionTo = new HashSet<GameActionState> { };
            }
            public override void DoAction<ArtistColonyContext>(ArtistColonyContext context)
            {
                var game = context.Game;
                //todo check if this triggers a bonus
                game.CurrentPlayer.GetNewAssistant();
            }
            public override bool IsValidGameState(ActionContext context)
            {
                var game = context.Game;
                if (game.CurrentPlayer.Assistants.Count >= 10)
                {
                    return false;
                }
                return true;
            }
        }

        public class GetMoney : BonusAction
        {
            public GetMoney()
            {
                Name = GameActionState.GetMoney;
                TransitionTo = new HashSet<GameActionState> { };
            }
            public override void DoAction<ArtistColonyContext>(ArtistColonyContext context)
            {
                var player = context.Game.CurrentPlayer;
                var money = player.GetGalleryVisitorCountByType(VisitorTicketType.investor) + player.GetGalleryVisitorCountByType(VisitorTicketType.collector);
                player.Money += money;
            }
        }
        public class GetInfluence : BonusAction
        {
            public GetInfluence()
            {
                Name = GameActionState.GetInfluence;
                TransitionTo = new HashSet<GameActionState> { };
            }
            public override void DoAction<ArtistColonyContext>(ArtistColonyContext context)
            {
                var player = context.Game.CurrentPlayer;
                var influence = player.GetGalleryVisitorCountByType(VisitorTicketType.vip) + player.GetGalleryVisitorCountByType(VisitorTicketType.collector);
                player.Influence += influence;
            }
        }
        public class ChooseContract : BonusAction
        {
            public ChooseContract()
            {
                Name = GameActionState.ChooseContract;
                TransitionTo = new HashSet<GameActionState> { };
            }
            public override void DoAction<ArtistColonyContext>(ArtistColonyContext context)
            {
                var newAction = new GameAction { Location = context.Action.Location, State = GameActionState.ContractDraft, IsExecutable = true };
                context.Game.CurrentTurn.AddPendingAction(newAction);
            }
        }
    }
}