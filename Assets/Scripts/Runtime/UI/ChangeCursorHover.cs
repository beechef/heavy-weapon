using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.UI
{
    public class ChangeCursorHover : MonoBehaviour, IPointerMoveHandler
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Initial()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        [SerializeField] private Texture2D cursor;

        public void OnPointerMove(PointerEventData eventData)
        {
            Cursor.SetCursor(cursor, new Vector2(cursor.width / 2f, cursor.height / 2f), CursorMode.ForceSoftware);
        }
    }
}