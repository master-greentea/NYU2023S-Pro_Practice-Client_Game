using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragPlants : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform recTransform;
    [SerializeField] Canvas myCanvas;
    CanvasGroup canvasGroup;

    [SerializeField] GameObject myItem;
    [SerializeField] GameObject bigPlant;
    [SerializeField] GridLayoutGroup grid;

    Vector3 previousPos;
    private void Awake()
    {
        recTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        bigPlant.SetActive(true);
        myItem.SetActive(false);
        canvasGroup.blocksRaycasts = false;
        // get inital pos 
        previousPos = recTransform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        recTransform.anchoredPosition += eventData.delta/ myCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // isn't placed on the pit
        if (transform.parent == grid.transform)
        {
            canvasGroup.alpha = 1f;
            bigPlant.SetActive(false);
            myItem.SetActive(true);
            canvasGroup.blocksRaycasts = true;
            // set initial pos
            recTransform.localPosition = previousPos;
        }
        // placed on the pit
        else{
            canvasGroup.alpha = 1f;
        }
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }
}
