using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Button btnribrith;
    public static Button startButton;
    public static GameObject dieUi;
    public static GameObject clearUi;

    private void Awake() {
        GameObject shopGo = Resources.Load<GameObject>("Shop");
        Instantiate(shopGo);
        startButton = GetComponentInChildren<Button>();
        startButton.onClick.AddListener(StartButton);
        
    }
    
    public static void Die()
    {
        if (null == dieUi)
        {
        GameObject dieGameObject = Resources.Load<GameObject>("Die");
        dieUi = Instantiate(dieGameObject);
        btnribrith = dieUi.GetComponentInChildren<Button>();
        btnribrith.onClick.AddListener(Rebrith);
        }

    }

    public static void Rebrith()
    {
        if (null == dieUi)
        return;
        
        dieUi.SetActive(false);
        
        GameObject gunGameObject = GameObject.FindGameObjectWithTag("Gun");
        Gun gun = gunGameObject.GetComponent<Gun>();
        gun.Reset();
        
        GameObject zombieManager = GameObject.FindGameObjectWithTag("ZombieManager");
        ZombieManager zombieManager1 = zombieManager.GetComponent<ZombieManager>();
        zombieManager1.Reset();

        PlayerManager.player1.Reset();
    }

    public static void StartButton()
    {
        startButton.gameObject.SetActive(false);

        GameObject shopGo = GameObject.FindGameObjectWithTag("Shop");
        UIShop uiShop = shopGo.GetComponent<UIShop>();
        shopGo.SetActive(false);

        GameObject zombieManager = GameObject.FindGameObjectWithTag("ZombieManager");
        ZombieManager zombieManager1 = zombieManager.GetComponent<ZombieManager>();
        zombieManager1.NomalZombieSpawn(10);
    }


}
