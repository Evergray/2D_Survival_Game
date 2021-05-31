using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable, IDestructible
{

    private float playerDamage = 50;
    //TODO: переменная для теста
    public Item wood;

    public Player():base()
    {
        if(player) return;
    }
    
    public float durability { get; set; }

    public static Player player;

    private void Awake()
    {
        player = this;
        durability = 100.0f;
    }
    //TODO: 
    /*
     * Сome up with DoSomeThing function...
     */
    public void DoSomeThing()
    {
        Debug.Log("Do smg....");
    }

    public void TakeDamage(float damageTaken)
    {
        if (durability > damageTaken)
            durability -= damageTaken;
        else Destruct();
    }

    public void Destruct()
    {
        Debug.Log("Smertb =(");
    }

    public void Damage(IDamageable hitObject)
    {
        hitObject.TakeDamage(playerDamage);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: для теста, нужно переделать!!!
        ICollectable saveItem = other.gameObject.GetComponent<ICollectable>();
        wood.count += saveItem.item.count;
        Debug.Log(wood.count);

        if (saveItem != null)
        {
            saveItem.PickUp(wood);
        }
    }
}
