using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Skeleton : Enemy
    {
        private Vector2 lookDirection;
        private bool playerIsOnSight = false;
        private Rigidbody2D rigidBody;
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
            durability = 30f;
            damageType = "Melee";
            damageAmount = 2f;
            speedRate = 2f;
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                Attack();
                TakeDamage(10f);
                //Player.player.TakeDamage(20f);
                Debug.Log("Skeleton hp -> " + this.durability);
                //Debug.Log("Player hp -> " + Player.player.durability);
            }
            /* TODO:
             * When it collide with non-player object 
             * it should push away from object so it can move further
             */
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Debug.Log("I SEE YOU");
                playerIsOnSight = true;
            }
        }

        private void FixedUpdate()
        {
            if (playerIsOnSight)
            {
                lookDirection = (Player.player.transform.position - transform.position).normalized;
                Vector2 position = transform.position;
                position.x += speedRate * lookDirection.x * Time.deltaTime;
                position.y += speedRate * lookDirection.y * Time.deltaTime;
                rigidBody.MovePosition(position);
            }
        }
    }
}
