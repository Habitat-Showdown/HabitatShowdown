using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    private Enemy state = Enemy.Alive;

    private Rigidbody2D rb;
    private SpriteRenderer spriter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case Enemy.Alive :
                {
                    Vector2 dirVec = target.position - rb.position;
                    Vector2 nextVec = dirVec.normalized * (speed * Time.fixedDeltaTime);
                    rb.MovePosition(rb.position + nextVec);
                    rb.velocity = Vector2.zero;
                }
                break;
        }
    }

    private void LateUpdate()
    {
        spriter.flipX = rb.position.x > target.position.x;
    }

    private void OnEnable()
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
    }
}