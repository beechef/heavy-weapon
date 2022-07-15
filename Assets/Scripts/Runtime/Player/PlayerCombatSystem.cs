using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Runtime.Enemies.Animations;
using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerCombatSystem : MonoBehaviour, IVulnerable
    {
        [SerializeField] private PlayerStatsSystem statsSystem;
        [SerializeField] private PlayerAnimation anim;
        [SerializeField] private Pooling pooling;
        [SerializeField] private Collider2D coll;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip deathClip;
        [SerializeField] private AnimationEvents animationEvents;
        [SerializeField] private GameObject barrel;
        [SerializeField] private List<Transform> attackPoints;
        [SerializeField] private string bulletPrefab;
        [SerializeField] private string casingPrefab;
        [SerializeField] private string playerDeathPrefab;

        private PlayerStats _stats;
        private float _lastAttack;
        private bool _isDeath;

        private void Start()
        {
            _stats = statsSystem.Stats;
            GODictionary.AddVulnerableGO(gameObject, this);
            animationEvents.OnDeath(() => { gameObject.SetActive(false); });
        }

        private void OnEnable()
        {
            OnInit();
        }

        private void OnInit()
        {
            _isDeath = false;
            coll.enabled = true;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
            barrel.SetActive(true);
        }

        protected void PlaySound(AudioClip audioClip)
        {
            if (audioClip == null) return;
            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        private async void Death()
        {
            _stats.lives--;
            _isDeath = true;
            coll.enabled = false;
            PlaySound(deathClip);
            anim.Death();
            barrel.SetActive(false);
            ScreenEffects.Instance.Blink(Color.white, .25f);

            GameObject go = await pooling.GetAsync(playerDeathPrefab, transform.position,
                Quaternion.Euler(-90f, 0f, 0f));
            pooling.Return(go, 2f).Forget();
            if (_stats.lives <= 0)
            {
                Debug.Log("Lose!");
            }
            else
            {
                Reborn();
            }
        }

        private async void Reborn()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3.5f));
            gameObject.SetActive(true);
            statsSystem.RestoreFullHealth();
        }

        public void TakeDamage(float damage)
        {
            if (_isDeath) return;
            anim.Hit();
            if (statsSystem.TakeDamage(damage))
            {
                Death();
            }
        }

        public bool IsCanAttack()
        {
            return Time.time - _lastAttack >= 1f / _stats.attackSpeed;
        }


        public async void Attack()
        {
            if (!IsCanAttack()) return;
            _lastAttack = Time.time;
            for (int i = 0; i < _stats.amountAttackPoint; i++)
            {
                if (i >= attackPoints.Count) break;
                var attackPoint = attackPoints[i];
                var position = attackPoint.position;
                var rotation = attackPoint.rotation;
                GameObject go = await pooling.GetAsync(bulletPrefab, position,
                    rotation);
                GODictionary.BasicBulletStatsSystemGOs[go].IncreaseAttack(_stats.attack);
                pooling.GetAsync(casingPrefab, position, rotation).Forget();
            }
        }
    }
}