using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int Type;
    // Start is called before the first frame update
    void Start()
    {
        anim =  GetComponent<Animator>();
    }

    public void ToStart() {
        recordPlayer.PlayerType = Type;
        anim.SetBool("Open",true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
