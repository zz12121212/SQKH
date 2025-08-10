using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Dialog  {
    [SerializeField] public Sprite headImage;
    [SerializeField] public string Name;
    [SerializeField] public string dialog;
}


public class bg : MonoBehaviour
{
   [SerializeField] public Dialog[] dialogs;
    

}
