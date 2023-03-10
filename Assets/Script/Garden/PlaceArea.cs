using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceArea : MonoBehaviour, IDropHandler
{
    bool havePlant;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null){

            if (eventData.pointerDrag.tag == "Fertilizer" && havePlant){
                Destroy(eventData.pointerDrag.gameObject);
            }

            if(eventData.pointerDrag.tag == "Plants" && !havePlant)
            {
                RectTransform drager = eventData.pointerDrag.GetComponent<RectTransform>();
                drager.SetParent(transform);
                drager.localPosition = Vector3.zero;

                havePlant = true;
            }

            if (eventData.pointerDrag.tag == "Shovel" && havePlant)
            {
                foreach (Transform item in transform)
                {
                    Destroy(item.gameObject);
                }
            }
           
        }
    }
}
