using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int playerHp = 100;
    public int playerGold = 50;
    public int score = 0;
    public float speed = 10f;
    public int Kill;
    GameObject playerInfoGo;
    public Text playerInfo;

    Camera charaterCamera; 

    public GunController gunContoller;
 

    public UIPlayer uiPlayer;

    public Player(int health, int _score, int gold)
    {
        playerHp = health;
        score = _score;
        playerGold = gold;
    }

    void Awake()
    {
        PlayerManager.player1 = this;
        GameObject uiPlayerGameObject = GameObject.FindGameObjectWithTag("UIPlayer");
        uiPlayer = uiPlayerGameObject.GetComponent<UIPlayer>();
        charaterCamera = GetComponentInChildren<Camera>();
        GameObject playerInfoGo = GameObject.FindGameObjectWithTag("PlayerInfo");
        playerInfo = playerInfoGo.GetComponentInChildren<Text>();

        gunContoller = GetComponent<GunController>();
    }

    void Update()
    {
        float a = Input.GetAxis("Vertical");
        float b = Input.GetAxis("Horizontal");

        transform.position += new Vector3(b, 0, a) * 0.01f * speed;

        RotateToMouseDir();

    }
 



    private void OnCollisionEnter(Collision other) 
    {
        Zombie_ zombieStatus = other.gameObject.GetComponent<Zombie_>();
        OnDamege(zombieStatus);
        uiPlayer.HPBarStatus();

    }

    public void OnDamege(Zombie_ a)
    {
        if (null == a)
            return;
        else
        {
        playerHp -= a.zombieATK;

        if (playerHp <= 0)
        {
            playerHp = 0;
            if (GameManager.dieUi != null)
            {
                GameManager.dieUi.SetActive(true);
            }
            else
            {
            GameManager.Die();
            }
        }
        }
        
    }

    void RotateToMouseDir()
    {
        // 현재 마우스 포지션에서 정면방향 * 10으로 이동한 위치의 월드좌표 구하기
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
 
        // Atan2를 이용하면 높이와 밑변(tan)으로 라디안(Radian)을 구할 수 있음
        // Mathf.Rad2Deg를 곱해서 라디안(Radian)값을 도수법(Degree)으로 변환
        float angle = Mathf.Atan2(
            this.transform.position.y - mouseWorldPosition.y,
            this.transform.position.x - mouseWorldPosition.x) * Mathf.Rad2Deg;
 
        // angle이 0~180의 각도라서 보정
        float final = -(angle + 90f);
 
        // Y축 회전
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, final, 0f));    
    }

    public void Reset() 
    {    
        playerHp = 100;
        playerGold = 50;
        score = 0;
        transform.position = new Vector3(0, 0.5f, 0); 
        
        uiPlayer.HPBarStatus();
    }
}
