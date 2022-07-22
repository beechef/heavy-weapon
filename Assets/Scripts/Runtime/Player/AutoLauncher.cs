using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Player
{
    public class AutoLauncher : MonoBehaviour
    {
        [SerializeField] private string missilePrefab;
        [SerializeField] private Transform attackPoint;

        [SerializeField] private IntVariable level;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float attack;
        [SerializeField] private Pooling pooling;

        [SerializeField] private bool isBlock;

        private float _lastAttack;

        [SerializeField] private List<float> levelAttackSpeedSheet = new List<float>()
        {
            0f, 0.5f, 1f, 1.5f, 2f
        };

        [SerializeField] private List<float> levelAttackSheet = new List<float>()
        {
            0f, 10f, 15f, 20f, 30f
        };

        private bool IsCanAttack => (level.Value != 0 && Time.time - _lastAttack >= 1f / attackSpeed);

        private void Awake()
        {
            var index = Mathf.Clamp(level.Value, 0, levelAttackSpeedSheet.Count);
            attackSpeed += levelAttackSpeedSheet[index];
            index = Mathf.Clamp(level.Value, 0, levelAttackSheet.Count);
            attack += levelAttackSheet[index];
        }

        private async void Update()
        {
            gameObject.SetActive(level.Value != 0);
            
            if (isBlock) return;
            if (!IsCanAttack) return;
            
            GameObject go = await pooling.GetAsync(missilePrefab, attackPoint.position, attackPoint.rotation);
            GODictionary.BasicBulletStatsSystemGOs[go].Stats.attack += attack;
            _lastAttack = Time.time;
        }
    }
}