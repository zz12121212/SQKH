using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform oringinalParent;
    public int orderNum;
    public void OnBeginDrag(PointerEventData eventData)
    {
        oringinalParent = transform.parent;
        transform.SetParent(transform.parent.parent.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "iii") {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = oringinalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(oringinalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
       }
        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

        eventData.pointerCurrentRaycast.gameObject.transform.Find("other").position= oringinalParent.position;
        eventData.pointerCurrentRaycast.gameObject.transform.Find("other").SetParent(oringinalParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    
}
