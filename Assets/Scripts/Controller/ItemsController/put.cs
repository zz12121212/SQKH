using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class put : MonoBehaviour
{
    public Items item;
    public GameObject Card;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        Card.GetComponent<Image>().sprite = item._image;
        Card.GetComponent<Card>().objectPrefab = item.prefab;
        Card.GetComponent<Card>().item= item;
    }
    private void OnDisable()
    {
        Card.GetComponent<Image>().sprite = null;
        Card.GetComponent<Card>().objectPrefab = null;
        Card.GetComponent<Card>().item = null;
    }
    // Update is called once per frame



}
