using RPG.DataModel;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{
    public class InventorySlot : MonoBehaviour
    {
        public int id;

        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _num;

        public void Refresh(SlotData data)
        {
            if (data.isEmpty)
            {
                _icon.enabled = false;
                _num.enabled = false;
            }
            else
            {
                _icon.sprite = ItemDatum.Instance[data.itemID].icon;
                _num.text = data.itemNum.ToString();
                _icon.enabled = true;
                _num.enabled = true;
            }
        }
    }
}