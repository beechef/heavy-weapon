using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.UI
{
    public class ChangeCursorHover : MonoBehaviour, IPointerMoveHandler
    {
        // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        // private static void Initial()
        // {
        //     Cursor.lockState = CursorLockMode.Confined;
        // }

        [SerializeField] private Texture2D cursor;

        public void OnPointerMove(PointerEventData eventData)
        {
            Cursor.visible = true;

            Cursor.SetCursor(cursor, new Vector2(cursor.width / 2f, cursor.height / 2f), CursorMode.Auto);
        }
    }
}