using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceContainer : MonoBehaviour
{

    private PlayerController player;
    private Rigidbody2D playerRb;

    private void Awake()
    {
        player = PlayerController.player;
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Click");
        RaycastHit2D hit = Physics2D.Raycast(playerRb.position + Vector2.up * 0.2f, 
            player.lookDirection, 1.5f, LayerMask.GetMask("ResourceContainer"));
        if (hit.collider != null)
        {
            Destroy(gameObject);
        }
    }
}
