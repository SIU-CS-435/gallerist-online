using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamJAMiN.GalleristComponentEntities;

namespace TeamJAMiN.Controllers.GameLogicHelpers
{
    public class SalesOfficeContext : ActionContext
    {
        public SalesOfficeContext(Game game)
            : base(game, new Dictionary<GameActionState, Type> {
                { GameActionState.ChooseLocation, typeof(ChooseLocation) },
                { GameActionState.SalesOffice, typeof(SalesOffice) },
                { GameActionState.ContractDraft, typeof(ContractDraft) },
                { GameActionState.ContractDraw, typeof(ContractDraw) },
                { GameActionState.ContractToPlayerBoard, typeof(ContractToPlayerBoard) },
                { GameActionState.Pass, typeof(Pass) }
            })
        { }
    }

    public class SalesOffice : ActionState
    {
        public PlayerLocation location = PlayerLocation.SalesOffice;
        public SalesOffice()
        {
            Name = GameActionState.SalesOffice;
            TransitionTo = new HashSet<GameActionState> { GameActionState.ContractDraw, GameActionState.ContractDraft };
        }

        public override void DoAction<SalesOfficeContext>(SalesOfficeContext context)
        {
            var game = context.Game;
            game.CurrentActionState = Name;
            var kickedPlayer = game.Players.FirstOrDefault(p => p.GalleristLocation == location);
            if (kickedPlayer != null)
            {
                game.KickedOutPlayerId = kickedPlayer.Id;
            }
            game.CurrentPlayer.GalleristLocation = location;
        }
        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (TransitionTo.Contains(action))
            {
                return true;
            }

            return false;
        }
    }
    public class ContractDraw : ActionState
    {
        public ContractDraw()
        {
            Name = GameActionState.ContractDraw;
            TransitionTo = new HashSet<GameActionState> { GameActionState.ContractDraft, GameActionState.Pass };
        }

        public override void DoAction<SalesOfficeContext>(SalesOfficeContext context)
        {
            var game = context.Game;
            game.CurrentActionState = Name;
            context.Game.DrawContracts();
        }
        //todo add check if the player can take a contract
        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (TransitionTo.Contains(action))
            {
                return true;
            }

            return false;
        }
    }
    public class ContractDraft : ActionState
    {
        public ContractDraft()
        {
            Name = GameActionState.ContractDraft;
            TransitionTo = new HashSet<GameActionState> { GameActionState.ContractToPlayerBoard };
        }
        public override void DoAction<SalesOfficeContext>(SalesOfficeContext context)
        {
            var game = context.Game;
            game.CurrentActionState = Name;
            var location = (GameContractLocation)Enum.Parse(typeof(GameContractLocation), context.Game.CurrentActionLocation);
            var contracts = context.Game.GetContractDecks();
            var contract = contracts[location].First();
            if(context.Game.IsContractLocationEmpty(location))
            {
                context.Game.ReplaceContract(location);
            }
            contract.Location = GameContractLocation.ChooseLocation;
            context.Game.CurrentPlayer.Contracts.Add(contract);
        }
        //todo override validate method to check for valid contract location
        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (TransitionTo.Contains(action))
            {
                return true;
            }

            return false;
        }
    }
    public class ContractToPlayerBoard : ActionState
    {
        public ContractToPlayerBoard()
        {
            Name = GameActionState.ContractToPlayerBoard;
            TransitionTo = new HashSet<GameActionState> { GameActionState.Pass };
        }
        public override void DoAction<SalesOfficeContext>(SalesOfficeContext context)
        {
            var location = (GameContractLocation)Enum.Parse(typeof(GameContractLocation), context.Game.CurrentActionLocation);
            var player = context.Game.CurrentPlayer;
            var contract = player.Contracts.First(c => c.Location == GameContractLocation.ChooseLocation);
            if(context.Game.IsContractLocationEmpty(location))
            {
                //todo give ticket
            }
            else
            {
                //todo discard the current contract and possibly send visitor back to office.
            }
            contract.Location = location;
            //todo replace below with a pass button or something.
            context.DoAction(GameActionState.Pass);
        }
        //todo override validate method to check for valid contract location
        //and to check if the location has a contract that can be replaced
        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (TransitionTo.Contains(action))
            {
                return true;
            }

            return false;
        }
    }
    public class SellChooseArt : ActionState
    {
        public override void DoAction<SalesOfficeContext>(SalesOfficeContext context)
        {

        }
        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (TransitionTo.Contains(action))
            {
                return true;
            }

            return false;
        }
    }
    public class SellChooseVisitor : ActionState
    {
        public override void DoAction<SalesOfficeContext>(SalesOfficeContext context)
        {

        }
        public override bool CanTransitionTo<ActionContext>(GameActionState action, ActionContext context)
        {
            if (TransitionTo.Contains(action))
            {
                return true;
            }

            return false;
        }
    }
}