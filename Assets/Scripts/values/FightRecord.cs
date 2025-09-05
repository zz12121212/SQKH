using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "record /FightSceneData")]
public class FightRecord : ScriptableObject
{
    public NewMonster Pet;
    public int Enemy;
    public float EnemyLevel;
}
