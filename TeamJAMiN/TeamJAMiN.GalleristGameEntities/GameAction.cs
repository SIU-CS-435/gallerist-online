namespace TeamJAMiN.GalleristComponentEntities
{
    public class GameAction
    {
        public GameAction Parent { get; set; }
        public GameActionPriority Priority { get; set; }
        public GameActionState State { get; set; }
        public string Location { get; set; }
        public bool IsExecutable { get; set; }
        public bool IsComplete { get; set; }
        public int Order { get; set; }
    }
}