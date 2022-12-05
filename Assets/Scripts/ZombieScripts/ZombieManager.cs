using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    GameObject[] zombies;

    private void Start() 
    {
    }

    public void Reset() 
    {
        DestroyAllZombies();
        NomalZombieSpawn(10);
    }

    private void DestroyAllZombies()
    {
        for (int i = 0; i < zombies.Length; i++)
        {
            Destroy(zombies[i]);
        }
    }

    public void NomalZombieSpawn(int initCount)
    {
        zombies = new GameObject[initCount];

        for (int i = 0; i < initCount; i++)
        {
            float a = Random.Range(-30f,30f);
            float b = Random.Range(-30f,30f);

            Vector3 zombieRandomSpawn = new Vector3(a, 0.5f, b);

            Object zombieObject = Resources.Load("Zombie");
            GameObject zombieGameObject = (GameObject)Instantiate(zombieObject, zombieRandomSpawn, Quaternion.identity);
            Zombie_ nomalZombie = zombieGameObject.GetComponent<Zombie_>();
            nomalZombie.zombieATK = 20;
            nomalZombie.zombieHP = 100;

            zombies[i] = nomalZombie.gameObject;
        }

    }


}
