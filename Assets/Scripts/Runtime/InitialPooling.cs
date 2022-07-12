using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets.Pooling;

namespace Runtime
{
    public class InitialPooling : MonoBehaviour
    {
        [SerializeField] private AddressableGameObjectPoolerManager spawner;
        public bool isAsync;

        private void Start()
        {
            if (isAsync)
            {
                spawner.PrepoolAsync().Forget();
            }
            spawner.Prepool();
        }
    }
}