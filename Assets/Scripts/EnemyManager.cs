using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//오브젝트 풀을 만들어 관리 - 오브젝트 풀 크기, 오브젝트 풀 배열, SpawnPoint

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    public float createTime = 1;
    public GameObject enemyFactory;

    public int poolSize = 10; //오브젝트 풀

    //GameObject[] enemyObjectPool; //배열->리스트로 교체
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    // 오브젝트 풀에 에너미를 생성해서 넣기(태어날 때), 총알과 동일

    void Start()
    {
        createTime = Random.Range(1.0f, 1.3f); //생성 시간을 1~5사이의 랜덤값으로 지정

        enemyObjectPool = new List<GameObject>();
        //enemyObjectPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            //enemyObjectPool[i] = enemy;
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }
    void Update()
    {
        currentTime += Time.deltaTime; //지속적으로 시간이 증가

        if (currentTime > createTime) //랜덤하게 지정된 생성 시간보다 커질 경우 생성
        {
            GameObject enemy = enemyObjectPool[0];

            if(enemyObjectPool.Count > 1)
            {
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
                int index = Random.Range(0, spawnPoints.Length); //랜덤하게 스폰포인트 선정(배열=인덱스
                enemy.transform.position = spawnPoints[index].position;
            }

            createTime = Random.Range(1.0f, 1.3f);
            currentTime = 0; //시간 초기화

            /*
            for(int i = 0; i < poolSize; i++)
            {
                GameObject enemy = enemyObjectPool[i];
                if (enemy.activeSelf == false)
                {
                    enemy.SetActive(true);

                    int index = Random.Range(0, spawnPoints.Length); //spawnpoint 랜덤으로 선택
                    enemy.transform.position = spawnPoints[index].position;

                    break;
                }
            } */
        }
    }
}
