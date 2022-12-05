using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_ : MonoBehaviour
{

    public int zombieATK = 20;
    public int zombieHP = 100;
    public Transform target;
    NavMeshAgent nav;
    

    public Zombie_(int hp, int atk)
    {
        zombieHP = hp;
        zombieATK = atk;
    }

    private void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        nav.SetDestination(target.position);
    }

    public void Die()
    {
        zombieHP = 0;
        Destroy(gameObject);
        PlayerManager.player1.Kill = PlayerManager.player1.Kill + 1;
    }
}
