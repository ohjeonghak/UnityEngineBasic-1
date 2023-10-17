using UnityEngine;


namespace RPG.AISystems.BehaviourTree
{
    public class Sequence : Composite
    {

        protected Sequence(BlackBoard blackBoard) :
            base(blackBoard)
        {

        }

        public override Result Invoke()
        {
            Result result = Result.Success;
            foreach (var child in children)
            {
                result = child.Invoke();
                if(result != Result.Success)
                    return result;
            }

            return result;
        }
    }

}