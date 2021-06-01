using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    private List<ItemCell> itemCells = new List<ItemCell>();
    private int itemsCount = 0;
    private int maxCount;
    public static ItemPanel instance;

    private void Awake()
    {
        instance = this;
        
        //Find all internal objects ItemCell and push it to a List
        foreach(Transform child in transform)
        {
            ItemCell itemCell = child.gameObject.GetComponent<ItemCell>();
            if (itemCell != null)
            {
                itemCells.Add(itemCell);
            }
        }
        
        maxCount = itemCells.Count;
    }

    public bool SetItem(Item item, int count)
    {
        if (itemsCount < maxCount)
        {
            item.count += count;
            ItemCell _itemCell = null;
            for (int i = 0; i < itemsCount; i++)
            {
                if (itemCells[i].type == item.name)
                {
                    _itemCell = itemCells[i];
                    break;
                }
            }

            if (_itemCell == null)
            {
                _itemCell = itemCells[itemsCount];
                _itemCell.type = item.name;
                itemsCount++;
            }

            _itemCell.DrawItem(item.Icon, item.count.ToString());
            return true;
        }
        return false;
    }
}
