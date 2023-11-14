using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG.DataModel
{
    [Serializable]
    public struct SlotData : IEquatable<SlotData>
    {
        public int itemID; 
        public int itmeNum;

        public SlotData(int itemID, int itmeNum)
        {
            this.itemID = itemID;
            this.itmeNum = itmeNum;
        }

        public bool Equals(SlotData other)
        {
            return (itemID == other.itemID &&
                    itmeNum == other.itmeNum);    
        }
    }

    [Serializable]
    public class Inventory : DataModelBase<SlotData>
    {
        public override void SetDefaultItems()
        {
            m_items = new List<Pair<SlotData>>();
           for (int i = 0; i < 32; i++)
            {
                m_items.Add(new Pair<SlotData>(i, new SlotData(0, 0)));
            }

            m_items.Add(new Pair<SlotData>(0, new SlotData(1, 5)));
        }
    }
}