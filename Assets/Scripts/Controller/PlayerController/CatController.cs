using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float Speed;
    private Animator anim;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        anim =GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(moveX, moveY).normalized;

        rb.velocity = direction * Speed;

        anim.SetFloat("ve",moveX);
        anim.SetFloat("ho", moveY);
        if (moveX != 0 || moveY != 0)
        {
            anim.SetBool("move", true);
        }
        else {
            anim.SetBool("move",false);
        }
    }
}
