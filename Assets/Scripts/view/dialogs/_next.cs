using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _next : MonoBehaviour
{
    private Dialog[] dialogs;
    public GameObject EndAction;
    public Text _Name;
    public Text _dialog;
    public Image _headImage;
    int i = 1;



    private void OnEnable()
    {
        dialogs = gameObject.transform.parent.parent.GetComponent<bg>().dialogs;
        ReStartDialog();
    }


    public void ReStartDialog()
    {
        _Name.text = dialogs[0].Name;
        _dialog.text = dialogs[0].dialog;
        _headImage.sprite = dialogs[0].headImage;
    }






    public void NextDialog()
    {
        if (i < dialogs.Length)
        {
            _Name.text = dialogs[i].Name;
            _dialog.text = dialogs[i].dialog;
            _headImage.sprite = dialogs[i].headImage;
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
