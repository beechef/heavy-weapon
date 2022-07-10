using Runtime.Enemy;
using UnityEngine;

public class UpdatePosition : MonoBehaviour
{
    [SerializeField] private PlayerPosition pos;

    void Update()
    {
        pos.SetPosition(transform.position);
    }
}