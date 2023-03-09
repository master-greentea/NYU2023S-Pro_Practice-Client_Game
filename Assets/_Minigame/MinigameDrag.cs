using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MinigameDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool isGoodItem;
    private Image _image;
    private Vector3 _startPos;

    void Start()
    {
        _image = GetComponent<Image>();
        _startPos = transform.localPosition;
    }

    private void Update()
    {
        if (MinigameManager.Instance.isGameEnded || !MinigameManager.Instance.isGameStarted)
        {
            _image.color = Color.gray;
            transform.localPosition = _startPos;
            return;
        }
        _image.color = isGoodItem ? Color.green : Color.white;
    }

    public void OnBeginDrag(PointerEventData ctx)
    {
        if (MinigameManager.Instance.isGameEnded || !MinigameManager.Instance.isGameStarted) return;
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData ctx)
    {
        if (MinigameManager.Instance.isGameEnded || !MinigameManager.Instance.isGameStarted) return;
        transform.position = ctx.position;
    }

    public void OnEndDrag(PointerEventData ctx)
    {
        if (MinigameManager.Instance.isGameEnded || !MinigameManager.Instance.isGameStarted) return;
        transform.localPosition = _startPos;
        _image.raycastTarget = true;
    }
}
