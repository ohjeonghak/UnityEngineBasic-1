

using System;

namespace RPG.AISystems.BehaviourTree
{
    public class COndition : Node, IParentOFChild
    {
        public Node child { get; set; }
        private Func<bool> _func;

        public COndition(Func<bool> func)
        {
            _func = func;
        }

        public override Result Invoke()
        {
            if (_func.Invoke())
            {
                return child.Invoke();
            }
            return Result.Failure;

        }
    }
}