using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Bag", menuName = " add@/New Monster Bag")]
public class MonsterBag : ScriptableObject
{
    public List<NewMonster> itemList = new List<NewMonster>();
}

