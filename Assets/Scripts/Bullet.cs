using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표: 위로 계속 이동하기
//속성: 이동 속도
//1. 방향 구하기, 2. 이동하기

public class Bullet : MonoBehaviour

{
    public float speed = 8;

    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
