using System;

namespace RPG.AISystems.BehaviourTree
{
    public class Root : Node, IParentOFChild
    {
        public Node child { get; set; }
        public Root(BlackBoard blackBoard) :
            base(blackBoard)
        {

        }

        public override Result Invoke()
        {
            return Result.Success;
        }
    }
}