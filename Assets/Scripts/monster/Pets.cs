using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pets : MonoBehaviour
{
    public GameObject[] pet;
    public GameObject grid;
    public GameObject DeskDiet;
    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.Q))
        {
            DeskDiet.SetActive(true);
        }
    }


}
