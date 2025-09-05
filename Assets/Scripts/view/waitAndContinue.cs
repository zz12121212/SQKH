using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitAndContinue : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnEnable() {
        StartCoroutine(WaitAndGoon());
    }

    IEnumerator WaitAndGoon() {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
