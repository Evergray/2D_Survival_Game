using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;
using Random = UnityEngine.Random;

public class Resource : MonoBehaviour,ICollectable
{
    [SerializeField]private Item _item;
    public Item item
    {
        get => _item;
    }
    private ItemPanel itemPanel;
    [SerializeField] private Count range;
    [SerializeField] private int count;

    public void Spawn(Vector3 position)
    {
        count = Random.Range(range.minimum, range.maximum + 1);
        Instantiate(gameObject, position, Quaternion.identity);
    }

    public void PickUp()
    {
        itemPanel = (itemPanel == null) ? itemPanel = ItemPanel.instance : itemPanel;
        if (itemPanel.SetItem(_item, count))
        {
            Destroy(gameObject);
        }
        else
        {
            //TODO: сделать какой-нибудь попап, когда нет места на панельке
            Debug.Log("Inventory is full!!!");
        }
            
    }
}
