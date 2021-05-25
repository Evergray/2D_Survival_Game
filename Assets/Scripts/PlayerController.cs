using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    private float horizontal;
    private float vertical;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private Vector2 _lookDirection = new Vector2(1, 0);
    public Vector2 lookDirection
    {
        get
        {
            return _lookDirection;
        }
    }

    public static PlayerController player;

    private void Awake()
    {
        player = this;
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            _lookDirection.Set(move.x, move.y);
            _lookDirection.Normalize();
        }
        
        //Player movement animation
        animator.SetFloat("Look X", _lookDirection.x);
        animator.SetFloat("Look Y", _lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    private void FixedUpdate()
    {
        //Changing the player's position
        Vector2 position = transform.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;
        rigidbody2D.MovePosition(position);
    }
}
