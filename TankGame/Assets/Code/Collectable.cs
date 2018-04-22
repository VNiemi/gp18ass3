using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class Collectable : MonoBehaviour
    {
        [Tooltip("The amount of score from collecting this object.")]
        public int _score;

        public void OnCollisionEnter(Collision collision)
        {
            
            GameManager.Instance.AddScore(_score);
            
            Spawner.Instance.Recycle(this);

        }
    }
}
