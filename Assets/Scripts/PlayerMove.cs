using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour //플레이어 이동 스크립트
{
    public float speed = 5;
    // Start is called before the first frame update
    //Start: 시작, 1회 발생
    //Update 지속적 행동
    //OnDestroy: 종료, 1회

    public static int playerHeart;

    void Start()
    {
        playerHeart = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        print("h : " + h + " v : " + v); //키보드 입력 wasd, 콘솔창에 출력(-1~0~1)

        Vector3 dir = Vector3.right * h + Vector3.up * v; // dir변수에 입력값 대입
        //transform.Translate(dir * speed * Time.deltaTime); //dir만큼 이동

         //P(도착점) = P0(출발점) + v(속도) * t(시간)
         //v = v0 + a(가속도) * t, F(힘) = m(질량) * a(가속도)

        transform.position += dir * speed * Time.deltaTime; //공식 변환 코드, transform의 position 에 입력값*속도*시간을 더해서 대입

    }
}
