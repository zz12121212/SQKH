using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToB : MonoBehaviour
{
    public int ChangBlood;
    public GameObject record;
    public bool isChange;
    public Animator anim;
    public new Rigidbody2D rigidbody;
    public Vector2 direction;
    public float force;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();  
        rigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        direction = rigidbody.gameObject.GetComponent<CatController>().direction;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            record.GetComponent<setMBE>().AddB(ChangBlood);
            record.GetComponent<setMBE>().SetValue();
            direction = rigidbody.gameObject.GetComponent<CatController>().direction;
            isChange = true;
            anim.SetBool("Attacked",true);
            StartCoroutine(changing());
        }
    }

    IEnumerator changing() {
        yield return new WaitForSeconds(0.2f);
        isChange = false;
        anim.SetBool("Attacked", false);
    }
}
