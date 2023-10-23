
namespace RPG.AISystems.BehaviourTree
{
    public enum Result
    {
        Failure,
        Success,
        Running,
    }
    public abstract class Node
    {
        protected Tree owner;
        protected BlackBoard blackBoard;
        public Node(BlackBoard blackboard)
        {
            this.blackBoard = blackboard;
            this.owner = blackboard.owner;
        }
        public abstract Result Invoke();
    }
}
