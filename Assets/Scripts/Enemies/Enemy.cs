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
        public Rigidbody2D rigidBody;
        public  float durability
        {
            get => _durability;
            set => _durability = value;
        }

        public virtual void Attack()
        {
            Player.player.TakeDamage(damageAmount);
            Debug.Log("Player dmg");
        }
        public virtual void Destruct()
        {
            Debug.Log("Smertb Enemy");
            Destroy(gameObject);
        }

        public virtual void TakeDamage(float damageTaken)
        {
            if (_durability > damageTaken)
            {
                //TODO: Сделать отталкивание от плеера при получении урона
                /*Vector2 lookDirection = (transform.position - Player.player.transform.position);
                rigidBody.AddForce(lookDirection * 200, ForceMode2D.Impulse);*/
                _durability -= damageTaken;
            }
                
            
            else Destruct();
        }
    }
}
