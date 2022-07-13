using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Enemy
{
    [CreateAssetMenu(menuName = "Player Position", fileName = "New Player Position")]
    public class PlayerPosition : ScriptableObject
    {
        private static readonly List<PlayerPosition> PlayerPositions = new List<PlayerPosition>();

        public static void AddPlayerPosition(PlayerPosition playerPosition)
        {
            PlayerPositions.Add(playerPosition);
        }

        public static Vector3 GetNearestPlayerPosition(Transform enemyTransform)
        {
            Vector3 nearestPlayerPosition = enemyTransform.up;
            Vector3 enemyPosition = enemyTransform.position;
            float nearestDistance = float.MaxValue;
            foreach (var player in PlayerPositions)
            {
                Vector3 playerPosition = player.Position;
                float distance = Vector3.Distance(playerPosition, enemyPosition);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestPlayerPosition = playerPosition;
                }
            }

            return nearestPlayerPosition;
        }

        public Vector3 Position { get; private set; }

        public PlayerPosition()
        {
            AddPlayerPosition(this);
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }
    }
}