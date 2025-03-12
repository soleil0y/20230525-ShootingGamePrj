using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ: �߻� ��ư�� ������ �Ѿ� �߻�
//�Ѿ� ����, �ѱ�

//3-2) ������ƮǮ : ������ �� �� ���� ���� �Ѿ��� ����� ������Ʈ Ǯ�� ����

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //�Ѿ� ���� = �Ѿ� ����(prefabs)
    public GameObject firePosition; //�ѱ�

    public int poolSize = 10; //������Ʈ Ǯ�� ���� �Ѿ��� ����
    //GameObject[] bulletObjectPool; //������Ʈ Ǯ �迭
    //�迭->����Ʈ�� ��ü
    public List<GameObject> bulletObjectPool;

    // ��ǥ: ������Ʈ Ǯ�� �Ѿ��� �ִ´�
    // �¾ ��
    // źâ(������Ʈ Ǯ)�� ����
    // źâ�� ���� �Ѿ� �� ��ŭ �ݺ�
    //   �Ѿ� ���忡�� �Ѿ� ����
    //   �Ѿ��� ������Ʈ Ǯ�� �ֱ�

    void Start()
    {
        bulletObjectPool = new List<GameObject>();

        //bulletObjectPool = new GameObject[poolSize]; //źâ ���� �迭>����Ʈ

        for (int i = 0; i < poolSize; i++) //���� �Ѿ� �� ��ŭ �ݺ�
        {
            GameObject bullet = Instantiate(bulletFactory); //�Ѿ� ����
            bulletObjectPool.Add(bullet); //źâ�� �Ѿ� ����

            bullet.SetActive(false); //��Ȱ��ȭ
        }

    }

    //������Ʈ Ǯ(źâ)�� ��Ȱ��ȭ �� �Ѿ��� �����ؼ� ����(�����ϴ� ����:Start, ��Ȱ�� ����)
    //������Ʈ Ǯ���� ��Ȱ��ȭ�� �Ѿ��� ã�� �߻�, Ȱ��ȭ
  
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            if(bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool[0];

                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);

                bullet.transform.position = firePosition.transform.position;
            }

            /*
            for (int i = 0; i < poolSize; i++) //źâ �� ��ŭ �ݺ�-��Ȱ��ȭ �� �Ѿ� Ž��
            {
                GameObject bullet = bulletObjectPool[i]; 
                if (bullet.activeSelf == false) //��Ȱ��ȭ �� �Ѿ� ã��
                {
                    bullet.SetActive(true); //��Ȱ��ȭ �� �Ѿ� Ȱ��ȭ (��Ȱ��ȭ: �� �� �ִ� ������ �Ѿ�, Ȱ��ȭ: �߻�� �Ѿ�)
                    bullet.transform.position = firePosition.transform.position;
                    break; 
                }
            }
            //������Ʈ Ǯ �迭 */

            /*
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position; 
            //������Ʈ Ǯ ����� �� */

        }
    }
}
