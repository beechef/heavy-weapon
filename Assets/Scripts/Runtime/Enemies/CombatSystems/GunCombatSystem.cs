﻿using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.CombatSystems
{
    public class GunCombatSystem : BasicCombatSystem
    {
        [SerializeField] private Transform attackPoint1;

        public override void Attack()
        {
            if (!IsCanAttack()) return;
            LastAttack = Time.time;

            SpawnBullet().Forget();

            anim.Attack();
        }

        protected override async UniTask SpawnBullet()
        {
            for (int i = 0; i < Stats.attackTimes; i++)
            {
                if (bulletPrefabs.Count == 0) return;
                var randomNumber = Random.Range(0, bulletPrefabs.Count);
                GameObject go = await pooling.GetAsync(bulletPrefabs[randomNumber], attackPoint.position,
                    attackPoint.rotation);
                GameObject go1 = await pooling.GetAsync(bulletPrefabs[randomNumber], attackPoint1.position,
                    attackPoint1.rotation);
                await UniTask.Delay(TimeSpan.FromSeconds(Stats.attackDelay));
            }
        }
    }
}