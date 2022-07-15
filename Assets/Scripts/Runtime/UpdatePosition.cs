using Runtime.Enemy;
using UnityEngine;

namespace Runtime
{
    public class UpdatePosition : MonoBehaviour
    {
        [SerializeField] private PlayerPosition pos;

        private void OnEnable()
        {
            PlayerPosition.AddPlayerPosition(pos);
        }

        void Update()
        {
            pos.SetPosition(transform.position);
        }

        private void OnDisable()
        {
            PlayerPosition.RemovePlayerPosition(pos);
        }
    }
}