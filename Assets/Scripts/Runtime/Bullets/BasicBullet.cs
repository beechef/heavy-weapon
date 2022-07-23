using Runtime.Bullets.Animations;
using Runtime.Bullets.StatsSystems;
using Runtime.Interfaces;
using Runtime.Items;
using UnityEngine;
using BasicStats = Runtime.Bullets.Stats.BasicStats;

namespace Runtime.Bullets
{
    public class BasicBullet : MonoBehaviour, IVulnerable
    {
        [SerializeField] private BasicAnimation anim;
        [SerializeField] private BasicStatsSystem statsSystem;
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected AudioClip startClip;
        [SerializeField] protected AudioClip deathClip;
        [SerializeField] protected Collider2D coll;
        [SerializeField] protected Pooling pooling;
        [SerializeField] protected IntVariable inGameScores;
        [SerializeField] protected float fadeTime = .2f;
        [SerializeField] protected TextRenderer textRenderer;
        private bool _isHasScore;
        public BasicStats Stats => statsSystem.Stats;

        protected virtual void OnEnable()
        {
            OnInit();
        }

        protected virtual void Awake()
        {
            GODictionary.AddVulnerableGO(gameObject, this);
            _isHasScore = inGameScores != null;
        }

        protected virtual void OnInit()
        {
            coll.enabled = true;
            audioSource.loop = false;
            audioSource.playOnAwake = false;
            PlayAudio(startClip);
        }

        protected void PlayAudio(AudioClip audioClip)
        {
            if (audioClip == null) return;

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

        protected virtual async void Death()
        {
            coll.enabled = false;
            anim.Death();
            PlayAudio(deathClip);
            await pooling.Return(gameObject, fadeTime);
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision(other.collider);
            if (other.gameObject.CompareTag(TagName.Ground) || other.gameObject.CompareTag(TagName.Player) ||
                other.gameObject.CompareTag(TagName.Enemy))
                Death();
        }

        public virtual void TakeDamage(float damage)
        {
            anim.Hit();
            if (statsSystem.TakeDamage(damage))
            {
                Death();
                if (_isHasScore)
                {
                    inGameScores.Value += Stats.score;
                    textRenderer = Instantiate(textRenderer);
                    textRenderer.Render(transform.position + transform.up, Stats.score.ToString(), 2f, false);
                }
            }
        }
    }
}