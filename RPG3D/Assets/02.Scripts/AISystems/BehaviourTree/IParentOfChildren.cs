using System.Collections.Generic;

namespace RPG.AISystems.BehaviourTree
{
    public interface IParentOFChildren
    {
        List<Node> children { get; set; }
    }
}
