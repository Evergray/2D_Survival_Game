using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, IDamageable, IDestructible
{
    private float _durability;
    [SerializeField] private GameObject stone;

    public float durability {
        get => _durability;
        set => _durability = value;
    }
    
    private void Awake()
    {
        _durability = 100;
    }
    
    public void TakeDamage(float damageTaken)
    {
        if (durability > damageTaken)
        {
            durability -= damageTaken;
        }
        else
        {
            Destruct();
        }
    }

    public void Destruct()
    {
        Resource resource = stone.GetComponent<Resource>();
        resource.Spawn(gameObject.transform.position);
        Destroy(gameObject);
    }
}
