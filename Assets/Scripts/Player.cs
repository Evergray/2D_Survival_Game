using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IDestructible
{

    public Player():base()
    {
        if(player) return;
    }
    
    public float durability { get; set; }

    public static Player player;

    private void Awake()
    {
        player = this;
    }

    public void TakeDamage(float damageTaken)
    {
        
    }

    public void Destruct()
    {
        
    }
}
