using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//폭발효과 추가... 1. 다른 물체와 충돌했을 때 2. 폭발효과 공장에서 폭발효과 생성 3. 폭발효과 발생

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public float speed = 5;

    public GameObject explFactory; //폭발효과 공장

    //private int playerCollisionCount = 0;

    //충돌처리
    private void OnCollisionEnter(Collision other)
    {
 
        if (other.gameObject.name == "Player") //충돌한 물체가 플레이어인지 확인, 체력
        {

            PlayerMove.playerHeart--; 

           if (PlayerMove.playerHeart == 0) // 충돌 횟수를 모두 소진한 경우 플레이어 오브젝트 제거
            {
                Destroy(other.gameObject);
            } 

        }
        //원래 여기서 오브젝트 풀 부분-부딪힌 물체가 bullet인지 판단, 비활성화 해야 하는데, 이미 플레이어로 한 번 판단했고
        //적-적은 충돌하지 않으며(레이어 설정) 적-파괴존은 enemy스크립트에서 처리하지 않음
        // -> 적과 충돌하는 경우가 오직 플레이어/총알 뿐이라고 가정, else문에서 오브젝트 풀 - 총알 비활성화 처리
        // if(other.gameObject.name.Contains("Bullet")) 

        else //플레이어가 아니면? other 둘 다 파괴
        {
            //Destroy(collision.gameObject); //other 파괴
            //3.3) 파괴->비활성화, 오브젝트 풀에 삽입
            other.gameObject.SetActive(false);

            GameObject emObject = GameObject.Find("EnemyManager");
            EnemyManager manager = emObject.GetComponent<EnemyManager>();
            manager.enemyObjectPool.Add(gameObject);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(other.gameObject);
        }

        //충돌하면 무조건 실행 - 적 파괴, 점수 증가, 폭발 효과
        GameObject explosion = Instantiate(explFactory);
        explosion.transform.position = transform.position; //폭발

        //Destroy(gameObject); //enemy 파괴
        gameObject.SetActive(false);

        ScoreManager.Instance.Score++; //충돌이 일어났으니 점수 처리

        //Debug.Log("Player Collision Count: " + playerCollisionCount);

    }

    void Start()
    {
        int randValue = UnityEngine.Random.Range(0, 10);

        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;   
    }
}

/*
    private void OnCollisionEnter(Collision other)
    {

        GameObject expl = Instantiate(explFactory);

        expl.transform.position = transform.position;

        Destroy(other.gameObject);
        Destroy(gameObject);

        //점수부분
        //Debug.Log("Collision Detected");
        //아니 점수가 왜 2점씩오르냐?충돌이 두번생기나 ㅇㅅㅇ;;

        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        sm.currentScore++;

        sm.currentScoreUI.text = "SCORE : " + sm.currentScore;
    } 


        GameObject otherObject = collision.gameObject;
        Debug.Log("Collision Detected between " + gameObject.name + " and " + otherObject.name);

        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        sm.SetScore(sm.GetScore() + 1);
        */