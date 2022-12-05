using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    public Text[] playerTextSpace;
    public Slider[] playerSlider;

    public Player player;

    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        player = playerGameObject.GetComponent<Player>();
        playerTextSpace = GetComponentsInChildren<Text>();
        playerSlider = GetComponentsInChildren<Slider>();
        PlayerStatus();
        HPBarStatus();
    }

    public void PlayerStatus()
    {
        playerTextSpace[1].text = "SCORE : " + player.score;
        playerTextSpace[2].text = "GOLD : " + player.playerGold;
    }

    public void HPBarStatus()
    {
        playerSlider[0].value = player.playerHp;
    }

    public void GetScoreGold(int score, int gold)
    {
        player.score += score;
        player.playerGold += gold;
    }



}
