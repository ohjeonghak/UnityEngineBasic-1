using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.AISystems.BehaviourTree
{
    public class Selector : Composite
    {
        public Selector(BlackBoard blackboard) : base(blackboard)
        {
        }

        public override Result Invoke()
        {
            Result result = Result.Failure;

            for (int i = 0; i < children.Count; i++)
            {
                if (i <= currentIndex)
                    continue;


                result = children[i].Invoke();

                switch (result)
                {
                    case Result.Failure:
                        currentIndex++;
                        break;
                    case Result.Success:
                        currentIndex = 0;
                        return Result.Success;
                    case Result.Running:
                        owner.stack.Push(children[i]);
                        break;
                    default:
                        break;
                }
            }
                currentIndex = 0;
                return Result.Failure;
            
        }
    }
           
}