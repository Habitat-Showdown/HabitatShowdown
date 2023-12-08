using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    private Rigidbody2D rb;
    private SpriteRenderer spriter;
    private Animator anim;
    
    private void Awake()
    {
        #region Component
            rb = GetComponent<Rigidbody2D>();
            spriter = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
        #endregion
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * (speed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + nextVec);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
