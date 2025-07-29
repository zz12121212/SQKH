using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeController : MonoBehaviour
{

   [SerializeField] private  Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(PlayAnim());
    }

    private IEnumerator PlayAnim()
    {
        yield return new WaitForSeconds(15);
        anim.SetTrigger("next");
    }
    void Update()
    {
        
    }
}
