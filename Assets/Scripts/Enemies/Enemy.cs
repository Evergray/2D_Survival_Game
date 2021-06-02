using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour, IDamageable, IDestructible
    {
        public string damageType = "Melee";
        public float damageAmount = 10f;
        public float speedRate = 1f;

        private float _durability;
        public  float durability
        {
            get => _durability;
            set => _durability = value;
        }

        public virtual void Attack()
        {
            Debug.Log("Vkysno");
        }
        public virtual void Destruct()
        {
            Debug.Log("Smertb Enemy");
            Destroy(gameObject);
        }

        public virtual void TakeDamage(float damageTaken)
        {
            if (_durability > damageTaken)
                _durability -= damageTaken;
            else Destruct();
        }
    }
}
