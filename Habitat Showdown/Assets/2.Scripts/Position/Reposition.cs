using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using Random = UnityEngine.Random;

public class Reposition : MonoBehaviour
{
    [SerializeField]
    private int tileSize = 40;

    private Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);
        
        Vector3 playerDir = GameManager.Instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        
        switch (transform.tag)
        {
            case "Ground":
                {
                    if (diffX > diffY)
                    {
                        transform.Translate(dirX * tileSize, 0, 0);
                    } 
                    else if (diffX < diffY) 
                    {
                        transform.Translate(0, dirY * tileSize, 0);
                    }
                    else
                    {
                        transform.Translate(dirX * tileSize, dirY * tileSize, 0);
                    }
                }
                break;
            case "Enemy" :
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 40 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
                }
                break;
        }
    }
}
