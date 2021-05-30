using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;

public class Resource : MonoBehaviour,ICollectable
{
    public Item item;
    [SerializeField] private Count range;
    private int count;
    public void Spawn(Vector3 position)
    {
        count = Random.Range(range.minimum, range.maximum + 1);
        item.count = count;
        Instantiate(gameObject, position, Quaternion.identity);
    }

    public Item PickUp()
    {
        Destroy(gameObject);
        return item;
    }
}
