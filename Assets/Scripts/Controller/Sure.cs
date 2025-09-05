using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sure : MonoBehaviour
{
    public bag PlayerBag;
    public NewMonster monster;
    public materials materials;
    public SetLevelMateral set;

    public void IfClicked() 
    { 
        for (int i = 0; i < 3; i++)
        {
            if (materials.UsedMaterials[i] != null) {
                PlayerBag.itemList.Find(item => item == materials.UsedMaterials[i])._num -= materials.FinalMaterialsNum[i];
                if (PlayerBag.itemList.Find(item => item == materials.UsedMaterials[i])._num <= 0) {
                    PlayerBag.itemList.Find(item => item == materials.UsedMaterials[i])._num = 1;
                    PlayerBag.itemList.Remove(PlayerBag.itemList.Find(item => item == materials.UsedMaterials[i]));
                    PlayerBag.itemList.Add(null);
                }
                }
        }

        monster.Level += materials.AddLevel;
        set.ClickToShow();
        gameObject.SetActive(false);
    }



}
