using System;
using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField] private float value;

        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChange?.Invoke(value);
            }
        }

        public Action<float> OnChange;
    }
}