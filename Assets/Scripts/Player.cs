using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable, IDestructible
{

    private float playerDamage = 50;
    //TODO: ���������� ��� �����
    public Item wood;
    public Item stone;

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
        
        //TODO:��������� �������
        wood.count = 0;
        stone.count = 0;
    }
    //TODO: 
    /*
     * �ome up with DoSomeThing function...
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
        ICollectable saveItem = other.gameObject.GetComponent<ICollectable>();

        if (saveItem != null)
        {
            saveItem.PickUp();
        }
    }
}
