using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cover : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall")) { return; }
        float collisionY = collision.gameObject.transform.position.y;
        float playerY = transform.position.y;

        SpriteRenderer otherSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        TilemapRenderer tilemapRenderer = collision.gameObject.GetComponent<TilemapRenderer>();

        if (playerY < collisionY)
        {
            if (otherSpriteRenderer != null)
            {
                spriteRenderer.sortingOrder = otherSpriteRenderer.sortingOrder + 1;
            }
            else if (tilemapRenderer != null)
            {
                spriteRenderer.sortingOrder = 5; 
            }
        }
        else
        {
            if (otherSpriteRenderer != null)
            {
                spriteRenderer.sortingOrder = otherSpriteRenderer.sortingOrder - 1;
            }
            else if (tilemapRenderer != null)
            {
                spriteRenderer.sortingOrder = 3; 
            }
        }
    }
}