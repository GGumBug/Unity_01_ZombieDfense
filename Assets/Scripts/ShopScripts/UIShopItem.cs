using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    public Button buyButton;
    public Image itemImage;
    public Text itemPrice;
    public Sprite itemSprite;

    private void Awake() {
        SetShopItemUI();
    }
    public void SetShopItemUI()
    {
        itemImage = GetComponent<Image>();
        itemPrice = GetComponentInChildren<Text>();
        buyButton = GetComponent<Button>();
    }
    public void SetReference()
    {
        itemSprite = Resources.Load<Sprite>(ShopManager.ItemList[0].itemName);
        itemImage.sprite = itemSprite;
        itemPrice.text = ShopManager.ItemList[0].price.ToString() + "G";
    }
}
