using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable, IDestructible
{

    private float playerDamage = 50;
    //TODO: переменная для теста
    public Item wood;
    public Item stone;

    public Player():base()
    {
        if(player) return;
    }
    
    public float durability { get; set; }
    private float maxDurability;
    bool isInvincible = false;
    float invincibleTimer;
    float timeInvincible = 1f;

    public static Player player;

    private void Awake()
    {
        player = this;
        maxDurability = 100.0f;
        durability = maxDurability;
        
        //TODO:временное решение
        wood.count = 0;
        stone.count = 0;
    }
    //TODO: 
    /*
     * Сome up with DoSomeThing function...
     */
    public void DoSomeThing()
    {
        Debug.Log("Do smg....");
    }

    private void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0) {isInvincible = false; }
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if (isInvincible) return;
        
        if (durability > damageTaken)
        {
            isInvincible = true;
            invincibleTimer = timeInvincible;
            
            durability -= damageTaken;
            Debug.Log("durability/maxDurability " + durability/maxDurability);
            HealthBar.instance.SetValue(durability/maxDurability);
        }
        else
        {
            HealthBar.instance.SetValue(0);
            Destruct();
        }
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
        ICollectable saveItem = other.gameObject.GetComponent<ICollectable>();

        if (saveItem != null)
        {
            saveItem.PickUp();
        }
    }
}
