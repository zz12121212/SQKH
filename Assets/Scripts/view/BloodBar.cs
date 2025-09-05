using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBar : MonoBehaviour
{

    public GameObject Pet;
    public GameObject Enemy;


    public void ChangeFillCount(float changedValue) {
        StartCoroutine(ChangingValue(changedValue));
    }

    private IEnumerator ChangingValue(float changedValue) {
        float progress = 0f;
        float FillAmount = gameObject.GetComponent<Image>().fillAmount;

        while (progress < 1f) {
            progress += Time.deltaTime / 0.5f;
            gameObject.GetComponent<Image>().fillAmount = Mathf.Lerp(FillAmount, FillAmount + changedValue, progress);
            yield return new WaitForEndOfFrame();
        }
        FillAmount +=  changedValue;
        gameObject.GetComponent<Image>().fillAmount = FillAmount;
    }



}
