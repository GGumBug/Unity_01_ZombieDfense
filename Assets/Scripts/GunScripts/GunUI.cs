using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour
{
    public Slider reloadBar;
    public Text bulletCount;

    Gun glock;

    public void SetGun()
    {
        glock = PlayerManager.player1.gunContoller.glock;
        reloadBar = GetComponentInChildren<Slider>();
        reloadBar.maxValue = glock.maxBulletCount;
        CurrentBulletCount();
    }

    public void CurrentBulletCount()
    {
        if (glock.currentBulletCount > 5)
        {
            bulletCount.color = Color.black;
        }
        if (glock.currentBulletCount <= 5)
        {
            bulletCount.color = Color.red;
        }
        bulletCount.text = glock.currentBulletCount.ToString();
        reloadBar.value = glock.currentBulletCount;
    }
}
