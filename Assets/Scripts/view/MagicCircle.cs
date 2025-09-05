using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagicCircle : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {
        anim.SetBool("HavePlayer",true);
        _time.SaveTimeData();
        SceneManager.LoadScene("Street"); }

    }
}
