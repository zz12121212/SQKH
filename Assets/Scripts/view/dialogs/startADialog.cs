    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startADialog : MonoBehaviour
{

    public GameObject Dialog_bg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Dialog_bg.SetActive(true);
            }
        }
    }



}
