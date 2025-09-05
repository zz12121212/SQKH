using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPetDesk : MonoBehaviour
{
    public GameObject UI;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {
            UI.SetActive(true);
        }
    }
}
