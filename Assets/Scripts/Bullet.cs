using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ: ���� ��� �̵��ϱ�
//�Ӽ�: �̵� �ӵ�
//1. ���� ���ϱ�, 2. �̵��ϱ�

public class Bullet : MonoBehaviour

{
    public float speed = 8;

    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
