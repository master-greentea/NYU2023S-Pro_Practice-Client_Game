using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform movableBg;
    [SerializeField] float bgMoveSpeed;

    [SerializeField] Transform inventoryList;
    [SerializeField] DragPlants plantItem;
    [SerializeField] DragPlants fertilizer;

    private void Start()
    {
        // myMoney.text = presentMoney.ToString();
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

    public void BackToClinic()
    {
        SceneManager.LoadScene("Clinic");
    }

    IEnumerator MoveToTargetPos(Vector3 targetpos)
    {
        while (movableBg.localPosition != targetpos)
        {
            movableBg.localPosition = Vector3.MoveTowards(movableBg.localPosition, targetpos, bgMoveSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

    public void BuyItem(int ID, int price)
    {
        if (ID == 0) Instantiate(plantItem, inventoryList);
        if (ID == 1) Instantiate(fertilizer, inventoryList);

        // presentMoney -= price;
        if (GlobalGameManager.greenPoints < price)
        {
            GlobalGameManager.Instance.warning.text = "<size=70>Not enough Green Points!";
            StartCoroutine(GlobalGameManager.Instance.ClearWarning());
            return;
        }
        GlobalGameManager.UseGreenPoints(price);
    }
}
