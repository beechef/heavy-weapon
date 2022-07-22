using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.UI
{
    public class HoverDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [TextArea] [SerializeField] private string description;
        [SerializeField] private Description descriptionZone;


        public void OnPointerEnter(PointerEventData eventData)
        {
            descriptionZone.Render(description);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            descriptionZone.RenderDefault();
        }
    }
}