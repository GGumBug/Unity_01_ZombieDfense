using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private bool isReload = false;

    public GunUI gunUi;
    public Gun glock;
    public GameObject bullet;

    private void Awake() {
        GameObject gunUiGameObject = GameObject.FindGameObjectWithTag("UIGun");
        gunUi = gunUiGameObject.GetComponent<GunUI>();
}

    public void Shoot()
    {
        if (isReload == true)
        {
            PlayerManager.player1.playerInfo.text = "재장전중입니다.";
            return;
        }
        else if (glock.currentBulletCount <= 0)
        {
            PlayerManager.player1.playerInfo.text = "재장전을 하십시오.";
            return;
        }
        else
        {
        bullet = Resources.Load<GameObject>("Bullet");
        GameObject bulletGameObject = Instantiate(bullet, glock.firePos.transform.position, glock.firePos.transform.rotation);
        bulletGameObject.GetComponent<Bullet>().SetBullet(glock);
        Destroy(bulletGameObject, 2);
        glock.currentBulletCount--;
        gunUi.CurrentBulletCount();
        PlayerManager.player1.playerInfo.text = "";
        }
    }

    public void TryReload()
    {
        if (isReload == false)
        {
            StartCoroutine("Reload");
        }
        else
        PlayerManager.player1.playerInfo.text = "재장전중입니다.";
    }

    IEnumerator Reload()
    {
        isReload = true;
        yield return new WaitForSeconds(glock.reloadTime);
        glock.currentBulletCount = glock.maxBulletCount;
        gunUi.CurrentBulletCount();
        PlayerManager.player1.playerInfo.text = "재장전이 완료됐습니다.";
        isReload = false;
    }
}
