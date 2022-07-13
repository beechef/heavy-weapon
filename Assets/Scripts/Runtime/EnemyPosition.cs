using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public static class EnemyPosition
    {
        public static List<Transform> EnemyPositions { get; private set; } = new List<Transform>();

        public static void AddPos(Transform transform)
        {
            EnemyPositions.Add(transform);
        }

        public static void RemovePos(Transform transform)
        {
            EnemyPositions.Remove(transform);
        }

        public static Vector3 GetNearestEnemyPosition(Transform playerTransform)
        {
            Vector3 minPos = playerTransform.up;
            Vector3 playerPos = playerTransform.position;
            float minDistance = float.MaxValue;
            foreach (var enemyPosition in EnemyPositions)
            {
                float distance = Vector3.Distance(playerPos, enemyPosition.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minPos = enemyPosition.position;
                }
            }
            return minPos;
        }
    }
}