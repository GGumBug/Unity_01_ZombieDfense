using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string gunName = "Glock_Gun";
    public float range;
    public float fireRate = 1f;
    public float reloadTime = 3f;
    public int damage = 20;
    public int reoladBulletCount = 25;
    public int currentBulletCount = 25;
    public int maxBulletCount = 25;


    
    public Transform firePos; 
    public ParticleSystem muzzleFlash;
    public GunUI gunUi;
    public GunController gunController;

    private void Awake() {

    }



    private void Update() {

        
        if (Input.GetMouseButtonDown(0))
        {
            gunController.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gunController.TryReload();
        }
    }

    public void Reset() 
    {
        currentBulletCount = maxBulletCount;
        gunUi.CurrentBulletCount();
    }

    public void SetGun()
    {
        GameObject gunUiGameObject = GameObject.FindGameObjectWithTag("UIGun");
        gunUi = gunUiGameObject.GetComponent<GunUI>();
        gunController = PlayerManager.player1.GetComponent<GunController>();
    }

    

}
