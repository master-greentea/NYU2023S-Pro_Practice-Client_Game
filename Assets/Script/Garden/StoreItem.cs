using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItem : MonoBehaviour
{
    [SerializeField] float price;
    [SerializeField] int itemId;
    [SerializeField] TMP_Text myText;

    [SerializeField] MenuManager gm;
    private void Start()
    {
        myText.text = price + "GP";
    }
    public void AddItemToInventory()
    {
        gm.BuyItem(itemId, price);
    }
}
