using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Bag",menuName = " add@/New Bag")]
public class bag : ScriptableObject
{
public List<Items>  itemList = new List<Items>();
}


