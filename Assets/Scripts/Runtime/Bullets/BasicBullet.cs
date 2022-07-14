using Cysharp.Threading.Tasks;
using Runtime.Bullets.Animations;
using Runtime.Bullets.StatsSystems;
using Runtime.Interfaces;
using UnityEngine;
using BasicStats = Runtime.Bullets.Stats.BasicStats;

namespace Runtime.Bullets
{
    [RequireComponent(typeof(Collider2D))]
    public class BasicBullet : MonoBehaviour, IVulnerable
    {
        [SerializeField] private BasicAnimation anim;
        [SerializeField] private BasicStatsSystem statsSystem;
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected AudioClip startClip;
        [SerializeField] protected AudioClip deathClip;
        [SerializeField] protected Collider2D coll;
        [SerializeField] protected Pooling pooling;
        public BasicStats Stats { get; protected set; }

        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void Start()
        {
            GODictionary.AddVulnerableGO(gameObject, this);
        }

        protected virtual void OnInit()
        {
            coll.enabled = true;
            Stats = statsSystem.Stats;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
            PlayAudio(startClip);
        }

        protected void PlayAudio(AudioClip audioClip)
        {
            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        protected virtual void OnCollision(Collider2D other)
        {
            if (GODictionary.VulnerableGOs.TryGetValue(other.gameObject, out var vulnerable))
            {
                vulnerable.TakeDamage(Stats.attack);
            }
        }

        protected virtual void Death()
        {
            coll.enabled = false;
            anim.Death();
            PlayAudio(deathClip);
            pooling.Return(gameObject, .2f).Forget();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision(other.collider);
            if (other.gameObject.CompareTag(TagName.Ground) || other.gameObject.CompareTag(TagName.Player) ||
                other.gameObject.CompareTag(TagName.Enemy))
                Death();
        }

        public void TakeDamage(float damage)
        {
            anim.Hit();
            if (statsSystem.TakeDamage(damage))
            {
                Death();
            }
        }
    }
}