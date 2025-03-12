using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ȿ�� �߰�... 1. �ٸ� ��ü�� �浹���� �� 2. ����ȿ�� ���忡�� ����ȿ�� ���� 3. ����ȿ�� �߻�

public class Enemy : MonoBehaviour
{
    Vector3 dir;
    public float speed = 5;

    public GameObject explFactory; //����ȿ�� ����

    //private int playerCollisionCount = 0;

    //�浹ó��
    private void OnCollisionEnter(Collision other)
    {
 
        if (other.gameObject.name == "Player") //�浹�� ��ü�� �÷��̾����� Ȯ��, ü��
        {

            PlayerMove.playerHeart--; 

           if (PlayerMove.playerHeart == 0) // �浹 Ƚ���� ��� ������ ��� �÷��̾� ������Ʈ ����
            {
                Destroy(other.gameObject);
            } 

        }
        //���� ���⼭ ������Ʈ Ǯ �κ�-�ε��� ��ü�� bullet���� �Ǵ�, ��Ȱ��ȭ �ؾ� �ϴµ�, �̹� �÷��̾�� �� �� �Ǵ��߰�
        //��-���� �浹���� ������(���̾� ����) ��-�ı����� enemy��ũ��Ʈ���� ó������ ����
        // -> ���� �浹�ϴ� ��찡 ���� �÷��̾�/�Ѿ� ���̶�� ����, else������ ������Ʈ Ǯ - �Ѿ� ��Ȱ��ȭ ó��
        // if(other.gameObject.name.Contains("Bullet")) 

        else //�÷��̾ �ƴϸ�? other �� �� �ı�
        {
            //Destroy(collision.gameObject); //other �ı�
            //3.3) �ı�->��Ȱ��ȭ, ������Ʈ Ǯ�� ����
            other.gameObject.SetActive(false);

            GameObject emObject = GameObject.Find("EnemyManager");
            EnemyManager manager = emObject.GetComponent<EnemyManager>();
            manager.enemyObjectPool.Add(gameObject);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(other.gameObject);
        }

        //�浹�ϸ� ������ ���� - �� �ı�, ���� ����, ���� ȿ��
        GameObject explosion = Instantiate(explFactory);
        explosion.transform.position = transform.position; //����

        //Destroy(gameObject); //enemy �ı�
        gameObject.SetActive(false);

        ScoreManager.Instance.Score++; //�浹�� �Ͼ���� ���� ó��

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

        //�����κ�
        //Debug.Log("Collision Detected");
        //�ƴ� ������ �� 2����������?�浹�� �ι����⳪ ������;;

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