using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> Pool { get; set; }
        public float _currentHealth;

        [SerializeField]
        private float _maxHealth = 100.0f;

        [SerializeField]
        private float _timeToSelfDestruct = 3.0f;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        private void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestructor());
        }

        private void OnDisable()
        {
            ResetDrone();
        }

        IEnumerator SelfDestructor()
        {
            yield return new WaitForSeconds(_timeToSelfDestruct);
            TakeDamage(_maxHealth);
        }

        private void ReturnToPool()
        {
            Pool.Release(this);
        }

        private void ResetDrone()
        {
            _currentHealth = _maxHealth;
        }

        public void AttackPlayer()
        {
            Debug.Log("Attack player!");
        }

        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0.0f)
            {
                ReturnToPool();
            }
        }
    }
}
