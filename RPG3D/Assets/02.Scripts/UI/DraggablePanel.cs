using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.UI
{
    public class DraggablePanel : MonoBehaviour, IDragHandler
    {
        [SerializeField] private bool _resetPositionEnable;
        private RectTransform _rectTransform;
        private Vector2 _origin;

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _origin = _rectTransform.localPosition;
        }

        private void OnEnable()
        {
            if (_resetPositionEnable)
                _rectTransform.localPosition = _origin;
        }
    }
}