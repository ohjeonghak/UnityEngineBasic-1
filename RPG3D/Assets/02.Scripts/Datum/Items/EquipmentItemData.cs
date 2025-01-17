using RPG.GameElements;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart
{
    None,
    Head,
    Top,
    Bottom,
    Feet,
    RightHand,
    LeftHand,
    TwoHand,
}


[CreateAssetMenu(fileName = "new EquipmentItemData", menuName = "RPG3D/itemData/EquipmentItem")]

public class EquipmentItemData : UsableItemData
{
    public BodyPart bodyPart;
    public int levelRequired;
    public List<StatModifier> statModifiers;
    public override void Use()
    {
    }

    public override void Use(int slotIndex)
    { 
     // todo -> equip this item
    }

}