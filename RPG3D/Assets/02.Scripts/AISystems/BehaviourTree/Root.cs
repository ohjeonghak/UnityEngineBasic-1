namespace RPG.AISystems.BehaviourTree
{
    public class Root : Node, IParentOFChild
    {
        public Node child { get; set; }

        public override Result Invoke()
        {
            return child.Invoke();
        }
    }
}