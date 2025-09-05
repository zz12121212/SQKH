using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _next : MonoBehaviour
{
    private string[] dialogs;
    public GameObject EndAction;
    public Text _dialog;
    int i = 1;



    private void OnEnable()
    {
        dialogs = gameObject.transform.parent.parent.GetComponent<bg>().dialogs;
        ReStartDialog();
    }


    public void ReStartDialog()
    {
        _dialog.text = dialogs[0];
    }






    public void NextDialog()
    {
        if (i < dialogs.Length)
        {
            _dialog.text = dialogs[i];
            i++;
            return;
        }
        if (i >= dialogs.Length)
        {
            if (EndAction != null)
            {
                EndAction.SetActive(true);
            }
            transform.parent.parent.gameObject.SetActive(false);
            ReStartDialog();
            i = 1;
            return;
        }
    }
}
