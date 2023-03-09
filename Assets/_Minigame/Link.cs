using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Link : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData ctx)
    {
        Application.OpenURL("https://www.jnj.com/healthcare-products");
        Debug.Log("url clicked");
    }
}
