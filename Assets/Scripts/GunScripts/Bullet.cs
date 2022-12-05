using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject hitEffectPrefab;
    Gun glock;
    UIPlayer uiPlayer;

    private void Start() {
        GameObject uiPlayerGameObject = GameObject.FindGameObjectWithTag("UIPlayer");
        uiPlayer = uiPlayerGameObject.GetComponent<UIPlayer>();
    }
    private void Update() {
        transform.Translate(Vector3.forward * 1f);
    }

    private void OnCollisionEnter(Collision other) {
        Zombie_ zombie = other.gameObject.GetComponent<Zombie_>();
        if (other == null)
        {
            Destroy(gameObject);
            return;
        }
        else if(zombie)
        {
            if (zombie.zombieHP > glock.damage)
            {
                Ondamage(zombie);
            }
            else
            {
                Ondamage(zombie);
                uiPlayer.GetScoreGold(100, 10);
                uiPlayer.PlayerStatus();
                zombie.Die();
            }
        }
    }

    void Ondamage(Zombie_ zombie)
    {
        zombie.zombieHP -= glock.damage;
        hitEffectPrefab = Resources.Load<GameObject>("blood");
        GameObject clone = Instantiate(hitEffectPrefab, zombie.transform.position, Quaternion.identity);
        Destroy(clone, 2f);
        Destroy(gameObject);
    }

    public void SetBullet(Gun gun)
    {
        glock = gun;
    }
}
