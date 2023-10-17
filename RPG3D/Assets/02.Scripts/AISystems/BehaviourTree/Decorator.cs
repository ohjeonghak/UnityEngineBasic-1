

using System;

namespace RPG.AISystems.BehaviourTree
{
    public abstract class Decorator : Node, IParentOFChild
    {
        public Node child { get; set; }

        protected Decorator(BlackBoard blackBoard, Func<bool> func) : base(blackBoard)
        { 
        }


        public override Result Invoke()
        {
            return Decorate();
        }

        public abstract Result Decorate();
        

        
              
    }
}