﻿using System;
using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu]
    public class IntVariable : ScriptableObject
    {
        [SerializeField] private int value;

        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChange?.Invoke(value);
            }
        }

        public Action<int> OnChange;
    }
}