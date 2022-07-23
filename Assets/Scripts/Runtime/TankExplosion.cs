using UnityEngine;
using UnityEngine.Events;

namespace Runtime
{
    public class TankExplosion : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionEffect;
        [SerializeField] private AudioSource explosionAudio;
        [SerializeField] private SpriteRenderer tankMesh;
        [SerializeField] private GameObject tankBarrel;
        [SerializeField] private UnityEvent tankExplosionEvent;
    
        public void ExplosionByPress()
        {
            tankExplosionEvent.Invoke();
        }

        public void ExplsionEffect()
        {
            tankBarrel.SetActive(false);
            tankMesh.enabled = false;
            //explosionEffect.Play();
            explosionAudio.Play();
        }
    }
}
