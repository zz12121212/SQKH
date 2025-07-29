using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressR : MonoBehaviour
{
    [SerializeField] private Canvas pressR;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && pressR != null) // 先检查是否为 null
        {
            pressR.gameObject.SetActive(true);
        }
    }
}