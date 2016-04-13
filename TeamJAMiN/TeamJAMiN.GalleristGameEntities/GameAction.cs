namespace TeamJAMiN.GalleristComponentEntities
{
    public class GameAction
    {
        public GameActionPriority Priority { get; set; }
        public GameActionState State { get; set; }
        public string Location { get; set; }
        public bool isExecutable { get; set; }
        public bool isComplete { get; set; }
    }
}