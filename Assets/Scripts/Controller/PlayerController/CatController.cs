using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    public float Speed;
    private Animator anim;
    public Rigidbody2D rb;
    public Vector2 direction;
    public PlayerRecord record;
    public bool recordPosition;
    public float footTime;
    public AudioSource audioSource;
    private bool moving = false;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        anim =GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        gameObject.transform.position = record.position[SceneManager.GetActiveScene().buildIndex];
    }
    private void OnDisable()
    {

        record.position[SceneManager.GetActiveScene().buildIndex] = gameObject.transform.position;

    }
    // Update is called once per frame
    void Update()
    {   

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        direction = new Vector2(moveX, moveY).normalized;

        rb.velocity = direction * Speed;

        anim.SetFloat("ve",moveX);
        anim.SetFloat("ho", moveY);
        if (moveX != 0 || moveY != 0)
        {
            anim.SetBool("move", true);
            moving = true;
        }
        else {
            anim.SetBool("move",false);
            moving = false;
        }
        if (moving)
        {
            timer += Time.deltaTime;
            if (timer >= footTime)
            {
                audioSource.PlayOneShot(audioSource.clip);
                timer = 0;
            }
        }
        else {
            timer = 0;
        }
    }
}
