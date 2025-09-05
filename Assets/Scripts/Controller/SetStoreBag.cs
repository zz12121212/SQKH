using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStoreBag : MonoBehaviour
{
    public bag storebag;
    public GameObject HaveSomeItemDontGet;
    public GameObject GetItemsUI;

    IEnumerator SetActiveAndWait() {
        HaveSomeItemDontGet.SetActive(true);
        yield return new WaitForSeconds(1f);
        HaveSomeItemDontGet.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SetActiveAndWait());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&Input.GetKey(KeyCode.E))
        {
            GetItemsUI.SetActive(true);
        }
    }
}
