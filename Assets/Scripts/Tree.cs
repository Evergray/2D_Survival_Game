using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IDamageable, IDestructible
{
    private float _durability;
    private Animator animator;

    public float durability {
        get => _durability;
        set => _durability = value;
    }
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        _durability = 200;
    }
    
    public void TakeDamage(float damageTaken)
    {
        if (durability > damageTaken)
        {
            animator.SetTrigger("Hit");
            durability -= damageTaken;
        }
        else
        {
            animator.SetTrigger("Fade");
        }
    }

    public void Destruct()
    {
        Destroy(gameObject);
        Debug.Log("Destruct");
    }
}
