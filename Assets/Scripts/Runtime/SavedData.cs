using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu(menuName = "SavedData")]
    public class SavedData : ScriptableObject
    {
        public delegate void ScoreChangeDelegate(float changedScore, float score);

        private ScoreChangeDelegate _onScoreChange;
        [SerializeField] private float score;

        public float Score
        {
            get => score;
            set
            {
                _onScoreChange?.Invoke(score - value, value);
                score = value;
            }
        }

        public void OnScoreChange(ScoreChangeDelegate action)
        {
            _onScoreChange += action;
        }

        public IntVariable spreadLevel;
        public IntVariable laserLevel;
        public IntVariable shieldLevel;
        public IntVariable missileLevel;
        public IntVariable lightningLevel;
    }
}