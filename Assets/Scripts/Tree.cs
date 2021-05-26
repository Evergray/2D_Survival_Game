using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IDamageable, IDestructible
{
    private float _durability;
    public float durability {
        get => _durability;
        set => _durability = value;
    }
    
    public void TakeDamage(float damageTaken)
    {
        Debug.Log("Damage taken!!!!");
    }

    public void Destruct()
    {
        
    }
}
