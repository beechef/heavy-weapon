using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Enemies.CombatSystems
{
    public class Supplier : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;
        [SerializeField] private Pooling pooling;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float minDropTime;
        [SerializeField] private float maxDropTime;
        [SerializeField] private Transform dropPoint;
        [SerializeField] private List<GameObject> itemPrefabs;

        private float _time;
        private bool _isSpawn;

        private void OnEnable()
        {
            _time = Random.Range(minDropTime, maxDropTime);
            _isSpawn = false;
        }

        private void Update()
        {
            MoveForward();
            if (_time <= 0f && !_isSpawn)
            {
                _isSpawn = true;
                SpawnItem();
            }

            _time -= Time.deltaTime;
        }

        private void SpawnItem()
        {
            if (itemPrefabs.Count <= 0) return;
            int randomNumber = Random.Range(0, itemPrefabs.Count);
            Instantiate(itemPrefabs[randomNumber], dropPoint.position, dropPoint.rotation);
        }

        private void MoveForward()
        {
            Transform cachedTransform = transform;
            Vector3 pos = cachedTransform.position + cachedTransform.right * (moveSpeed * Time.deltaTime);
            rb.MovePosition(pos);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(TagName.Ground))
            {
                pooling.Return(gameObject).Forget();
                return;
            }

            animator.SetTrigger("Hit");
        }
    }
}