using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform movableBg;
    [SerializeField] float bgMoveSpeed;

    [SerializeField] Transform inventoryList;
    [SerializeField] DragPlants plantItem;
    [SerializeField] DragPlants fertilizer;

    [SerializeField] float presentMoney = 1000f;
    [SerializeField] TMP_Text myMoney;

    private void Start()
    {
        myMoney.text = presentMoney.ToString();
    }

    public void OpenStore()
    {
        Debug.Log("Store is open");
        Vector3 targetPos = new Vector3(-1425f, 0f, 0f);
        StartCoroutine(MoveToTargetPos(targetPos));
    }


    public void OpenInventory()
    {
        Debug.Log("Inventory is open");
        Vector3 targetPos = Vector3.zero;
        StartCoroutine(MoveToTargetPos(targetPos));
    }

    IEnumerator MoveToTargetPos(Vector3 targetpos)
    {
        while (movableBg.localPosition != targetpos)
        {
            movableBg.localPosition = Vector3.MoveTowards(movableBg.localPosition, targetpos, bgMoveSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

    public void BuyItem(int ID, float price)
    {
        if (ID == 0) Instantiate(plantItem, inventoryList);
        if (ID == 1) Instantiate(fertilizer, inventoryList);

        presentMoney -= price;
        myMoney.text = presentMoney.ToString();
    }
}
