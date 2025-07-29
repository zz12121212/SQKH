using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class UI_ground : MonoBehaviour
{
    public GameObject _object;//预制体
    public Tilemap tilemap;
    public bag bagList;
    public GameObject items_;//存放所有生成物体的集合

    // Start is called before the first frame update
    void Start()
    {
        tilemap = FindObjectOfType<Tilemap>();
        items_ = GameObject.FindWithTag("items");
  
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    public void Put() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0f));

        Vector3Int gridPos = tilemap.WorldToCell(worldPos);
        Vector3 snappedPos = tilemap.GetCellCenterWorld(gridPos);

       GameObject inGamePrefab = Instantiate( _object ,snappedPos, Quaternion.identity);
        inGamePrefab.transform.SetParent(items_.transform);

        for (int i = 0; i < bagList.itemList.Count; i++) {
            if (bagList.itemList[i]._name == _object.name ) {
                bagList.itemList[i]._num -= 1;
                bagManager.ReFreshItem();
                return;
            }
        }

    }


}
