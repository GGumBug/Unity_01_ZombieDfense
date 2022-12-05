using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static Item[] ItemList = {
        new Item("Glock" ,50)
    };
    public GameObject shop;

    private void Start() {
        shop = GameObject.FindGameObjectWithTag("Shop");
        UIShop uiShop = shop.GetComponent<UIShop>();
    }
}
