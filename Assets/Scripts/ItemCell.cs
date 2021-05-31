using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField]private Image itemImage;
    [SerializeField]private Text itemText;

    public void DrawItem(Sprite sprite, String text)
    {
        //Draw item icon
        itemImage.sprite = sprite;
        itemImage.gameObject.SetActive(true);
        
        //Set item count text
        itemText.text = text;
        itemText.gameObject.SetActive(true);
    }

    public void DisposeItem()
    {
        itemImage.gameObject.SetActive(false);
        itemText.gameObject.SetActive(false);
    }
}
