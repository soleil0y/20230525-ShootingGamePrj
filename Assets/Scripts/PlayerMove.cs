using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour //�÷��̾� �̵� ��ũ��Ʈ
{
    public float speed = 5;
    // Start is called before the first frame update
    //Start: ����, 1ȸ �߻�
    //Update ������ �ൿ
    //OnDestroy: ����, 1ȸ

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
        print("h : " + h + " v : " + v); //Ű���� �Է� wasd, �ܼ�â�� ���(-1~0~1)

        Vector3 dir = Vector3.right * h + Vector3.up * v; // dir������ �Է°� ����
        //transform.Translate(dir * speed * Time.deltaTime); //dir��ŭ �̵�

         //P(������) = P0(�����) + v(�ӵ�) * t(�ð�)
         //v = v0 + a(���ӵ�) * t, F(��) = m(����) * a(���ӵ�)

        transform.position += dir * speed * Time.deltaTime; //���� ��ȯ �ڵ�, transform�� position �� �Է°�*�ӵ�*�ð��� ���ؼ� ����

    }
}
