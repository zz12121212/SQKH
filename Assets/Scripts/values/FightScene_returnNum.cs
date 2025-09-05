using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScene_returnNum : MonoBehaviour
{

    private int ReturnNum() {
        for (int i = 0; i < transform.parent.childCount; i++) {
            if (transform.parent.GetChild(i) == transform)
            {
                return i;
            }
        }
        return 0;
    }

    public void ClickToUseMedic() {
        transform.parent.parent.GetComponent<BagRead>().UseMedic(ReturnNum());
    }
    public void ClickToUsePill()
    {
        transform.parent.parent.GetComponent<BagRead>().UsePill(ReturnNum());
    }
}
