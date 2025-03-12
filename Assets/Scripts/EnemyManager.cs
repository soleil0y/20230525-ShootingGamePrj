using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ʈ Ǯ�� ����� ���� - ������Ʈ Ǯ ũ��, ������Ʈ Ǯ �迭, SpawnPoint

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    public float createTime = 1;
    public GameObject enemyFactory;

    public int poolSize = 10; //������Ʈ Ǯ

    //GameObject[] enemyObjectPool; //�迭->����Ʈ�� ��ü
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    // ������Ʈ Ǯ�� ���ʹ̸� �����ؼ� �ֱ�(�¾ ��), �Ѿ˰� ����

    void Start()
    {
        createTime = Random.Range(1.0f, 1.3f); //���� �ð��� 1~5������ ���������� ����

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
        currentTime += Time.deltaTime; //���������� �ð��� ����

        if (currentTime > createTime) //�����ϰ� ������ ���� �ð����� Ŀ�� ��� ����
        {
            GameObject enemy = enemyObjectPool[0];

            if(enemyObjectPool.Count > 1)
            {
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
                int index = Random.Range(0, spawnPoints.Length); //�����ϰ� ��������Ʈ ����(�迭=�ε���
                enemy.transform.position = spawnPoints[index].position;
            }

            createTime = Random.Range(1.0f, 1.3f);
            currentTime = 0; //�ð� �ʱ�ȭ

            /*
            for(int i = 0; i < poolSize; i++)
            {
                GameObject enemy = enemyObjectPool[i];
                if (enemy.activeSelf == false)
                {
                    enemy.SetActive(true);

                    int index = Random.Range(0, spawnPoints.Length); //spawnpoint �������� ����
                    enemy.transform.position = spawnPoints[index].position;

                    break;
                }
            } */
        }
    }
}
