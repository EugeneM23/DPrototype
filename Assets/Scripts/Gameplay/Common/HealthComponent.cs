using System;
using System.Collections.Generic;
using Gameplay.BehComponents;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class HealthComponent : MonoBehaviour, IDamagable
    {
        public event Action OnDeath;

        [SerializeField] private GameObject _ragdollPartOne;
        [SerializeField] private GameObject _deathEffect;
        [SerializeField] private int _health;

        [Inject] private readonly EnemyConditions _conditions;
        private float impulseForce = 50;

        private void OnEnable()
        {
            _health = 10;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                GameObject go = Instantiate(_deathEffect);
                Quaternion qwe = transform.rotation;

                GameObject rag1 = Instantiate(_ragdollPartOne, transform.position, qwe);
                Vector3 pos = Random.insideUnitCircle / 2;

                ApplyRagdollImpulse(-transform.forward + pos, rag1);

                go.transform.position = transform.position + new Vector3(0, 1, 0);
                OnDeath?.Invoke();

                _conditions.IsAttaking = false;
                _conditions.IsOnAnimation = false;
                _conditions.IsAidling = false;
                _conditions.IsChasing = false;
                _conditions.IsPatroling = false;
            }
        }

        public void ApplyRagdollImpulse(Vector3 direction, GameObject ragdoll)
        {
            IEnumerable<Rigidbody> ragdollRigidbodies = ragdoll.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in ragdollRigidbodies)
            {
                if (rb != null)
                {
                    rb.AddForce(direction * impulseForce, ForceMode.Impulse);
                    rb.AddTorque(direction * impulseForce * 10, ForceMode.Impulse);
                }
            }
        }
    }
}