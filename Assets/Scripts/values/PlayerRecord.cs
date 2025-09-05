using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "record /PlayerData")]
public class PlayerRecord : ScriptableObject
{
  public  int Money;
    public Vector2[] position = new Vector2 [15];
}
