using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class materials : MonoBehaviour
{
    public Items[] UsedMaterials = new Items[3];
    public int[] MaterialsNum = new int[3];
    public int[] FinalMaterialsNum = new int[3];
    public bag PlayerBag;
    public GameObject sure;
    public int AddLevel =1;
    public void Click1Level()
    {
        AddLevel = 1;
        for (int i = 0; i < 3; i++)
        {
            FinalMaterialsNum[i] = MaterialsNum[i];
        }
        for (int i = 0; i < 3; i++)
        {
            if (UsedMaterials[i] != null)
            {
                for (int j = 0; j < PlayerBag.itemList.Count; j++)
                {

                    if (PlayerBag.itemList.Contains(UsedMaterials[i]) && PlayerBag.itemList.Find(item => item == UsedMaterials[i])._num >= FinalMaterialsNum[i])
                    {
                        sure.SetActive(true);
                    }
                    else
                    {
                        sure.SetActive(false);
                        return;
                    }
                }
            }
        }
    }

    public void Click10Level()
    {
        AddLevel = 10;
        for (int i = 0; i < 3; i++)
        {
            FinalMaterialsNum[i] = MaterialsNum[i] * 10;
        }
        for (int i = 0; i < 3; i++)
        {
            if (UsedMaterials[i] != null)
            {
                for (int j = 0; j < PlayerBag.itemList.Count; j++)
                {

                    if (PlayerBag.itemList.Contains(UsedMaterials[i]) && PlayerBag.itemList.Find(item => item == UsedMaterials[i])._num >= FinalMaterialsNum[i])
                    {
                        sure.SetActive(true);
                    }
                    else
                    {
                        sure.SetActive(false);
                        return;
                    }
                }
            }
        }
    }


    }
