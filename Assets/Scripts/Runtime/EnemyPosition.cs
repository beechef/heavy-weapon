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

        public static TransformData GetNearestEnemyPosition(Transform playerTransform,
            List<Transform> ignoreTransforms)
        {
            ignoreTransforms ??= new List<Transform>();
            Transform minTransform = null;
            Vector3 playerPos = playerTransform.position;
            Vector3 minPos = playerTransform.up + playerPos;
            float minDistance = float.MaxValue;
            foreach (var enemyPosition in EnemyPositions)
            {
                if (ignoreTransforms.Contains(enemyPosition)) continue;
                float distance = Vector3.Distance(playerPos, enemyPosition.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minTransform = enemyPosition;
                    minPos = enemyPosition.position;
                }
            }

            TransformData transformData;
            transformData.Position = minPos;
            transformData.Transform = minTransform;
            return transformData;
        }
    }

    public struct TransformData
    {
        public Transform Transform;
        public Vector3 Position;
    }
}