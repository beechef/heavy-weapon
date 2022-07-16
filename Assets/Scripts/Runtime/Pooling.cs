using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets.Pooling;

namespace Runtime
{
    public class Pooling : MonoBehaviour
    {
        private AddressableGameObjectPoolerManager _spawner;

        private void Awake()
        {
            _spawner = FindObjectOfType<AddressableGameObjectPoolerManager>();
        }

        public async UniTask<GameObject> GetAsync(string gameObjectName, Vector3 pos, Quaternion quaternion)
        {
            GameObject go = await _spawner.GetAsync(gameObjectName);
            go.transform.position = pos;
            go.transform.rotation = quaternion;
            go.SetActive(true);
            return go;
        }


        public async UniTask Return(GameObject go, float delay = 0f)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(delay));
            go.SetActive(false);
            _spawner.Return(go);
        }
    }
}