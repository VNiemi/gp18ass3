using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class Spawner : MonoBehaviour
    {

        public Collectable _prefab;
        public int maxAtOnce = 10;

        public float _spawnInterval = 5f;

        public float _minX, _maxX, _minZ, _maxZ;

        private Stack<Collectable> _store;

        private static Spawner _instance;

        public static Spawner Instance { get { return _instance; }  }

        internal void Recycle(Collectable collectable)
        {
            collectable.gameObject.SetActive(false);
            _store.Push(collectable);
        }

        // Use this for initialization
        void Awake()
        {
            _store = new Stack<Collectable>();
            _instance = this;

            // Pregenerate the objects as inactive.
            for(int i = 1; i<=maxAtOnce; i++)
            {
                Collectable c = Instantiate(_prefab);
                c.gameObject.SetActive(false);
                _store.Push(c);
            }

            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while(!GameManager.IsClosing)
            {
                yield return new WaitForSeconds(_spawnInterval);

                // Actually checks if the max number is already active.
                if(_store.Count > 0)
                {
                    Collectable c = _store.Pop();
                    c.transform.position = GetRandomPosition();
                    c.gameObject.SetActive(true);
                }

            }
        }

        private Vector3 GetRandomPosition()
        {            
            return new Vector3(UnityEngine.Random.Range(_minX, _maxX), 1, UnityEngine.Random.Range(_minZ, _maxZ));
        }

        // Visualize the bounds of the random spawn.
        protected void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;

            // Note that I am assuming the coords are in the right order. I could validate this in editor but I started doing this just a few hours before deadline...
            Gizmos.DrawWireCube(new Vector3((_minX + _maxX) / 2, 0, (_minZ + _maxZ) / 2), new Vector3(_maxX - _minX, 10, _maxZ - _minZ));
        }
    }
}
