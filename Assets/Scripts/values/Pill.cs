using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pill : MonoBehaviour
{
    public int odds;

    public bool canHave() {
     int a = Random.Range(0, 100);
        if (a >= odds) { return true; }
        else { return false; }
    }
}
