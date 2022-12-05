using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    public UIShopItem uiShopItem;
    GameObject item;
    GameObject glock_gun;
    Gun gun;
    GunUI gunUi;
    UIPlayer uiPlayer;
    private void Start() {
        SetShopItemUI();
        uiShopItem.buyButton.onClick.AddListener(BuyItem);

    }

    public void SetShopItemUI()
    {
        GameObject itemList = GameObject.FindGameObjectWithTag("ItemList");
        GameObject itemGo = Resources.Load<GameObject>("Item");
        item = Instantiate(itemGo, itemList.transform);
        uiShopItem = item.GetComponent<UIShopItem>();
        uiShopItem.SetReference();

        uiPlayer = PlayerManager.player1.uiPlayer;

        gunUi = PlayerManager.player1.gunContoller.gunUi;
    }

    public void BuyItem()
    {
        if (PlayerManager.player1.playerGold < ShopManager.ItemList[0].price)
        {
            Debug.Log("돈이 부족합니다.");
        }
        else
        ShopBuyGun();
        uiPlayer.PlayerStatus();

    }

    public void ShopBuyGun()
    {
        PlayerManager.player1.playerGold -= ShopManager.ItemList[0].price;
        GameObject glock_gunGo = Resources.Load<GameObject>("Glock_Gun");
        glock_gun = Instantiate(glock_gunGo, PlayerManager.player1.transform);
        gun = glock_gun.GetComponent<Gun>();
        PlayerManager.player1.gunContoller.glock = gun;
        
        gun.SetGun();
        gunUi.SetGun();        
    }
}
