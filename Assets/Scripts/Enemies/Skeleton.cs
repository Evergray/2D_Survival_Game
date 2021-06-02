using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Skeleton : Enemy
    {
        public override void TakeDamage(float damageTaken)
        {
            base.TakeDamage(damageTaken);
        }
        public override void Destruct()
        {
            base.Destruct();
        }

        public override void Attack()
        {
            base.Attack();
        }

        private void Awake()
        {
            durability = 100f;
            damageType = "Melee";
            damageAmount = 2f;
            speedRate = 2f;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                Attack();
                TakeDamage(10f);
                Player.player.TakeDamage(20f);
                Debug.Log("Skeleton hp -> " + this.durability);
                Debug.Log("Player hp -> " + Player.player.durability);
            }
        }

    }
}
