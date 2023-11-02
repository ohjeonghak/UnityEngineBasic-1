using UnityEngine;
using TMPro;

namespace RPG.UI
{
    public class WarningWindowUI : UIMonoBehaviuor
    {
        [SerializeField] private TMP_Text _content;

        public void Show(string content)
        {
            _content.text = content;
            Show();
        }
    }
}