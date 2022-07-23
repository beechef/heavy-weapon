using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu(menuName = "SavedData")]
    public class SavedData : ScriptableObject
    {
        public IntVariable totalScores;
        public IntVariable currentMission;
        public IntVariable spreadLevel;
        public IntVariable laserLevel;
        public IntVariable shieldLevel;
        public IntVariable missileLevel;
        public IntVariable lightningLevel;
        public IntVariable pointsRemaining;
    }
}