using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item" , menuName =" add@ /New Item")]
public class Items : ScriptableObject
{
    public GameObject prefab;
    public string  _name;
    public Sprite _image;
    public int  _num;
    public int Money;
    [TextArea]
    public string  _Info;

    public bool canPut;
    public bool canEat;
    public bool medicine;
    public bool pill;

}
