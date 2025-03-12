using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표: 발사 버튼을 누르면 총알 발사
//총알 생산, 총구

//3-2) 오브젝트풀 : 생성할 때 한 번에 많은 총알을 만들어 오브젝트 풀에 저장

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; //총알 공장 = 총알 파일(prefabs)
    public GameObject firePosition; //총구

    public int poolSize = 10; //오브젝트 풀에 넣을 총알의 개수
    //GameObject[] bulletObjectPool; //오브젝트 풀 배열
    //배열->리스트로 교체
    public List<GameObject> bulletObjectPool;

    // 목표: 오브젝트 풀에 총알을 넣는다
    // 태어날 때
    // 탄창(오브젝트 풀)을 생성
    // 탄창에 넣을 총알 수 만큼 반복
    //   총알 공장에서 총알 생성
    //   총알을 오브젝트 풀에 넣기

    void Start()
    {
        bulletObjectPool = new List<GameObject>();

        //bulletObjectPool = new GameObject[poolSize]; //탄창 생성 배열>리스트

        for (int i = 0; i < poolSize; i++) //넣을 총알 수 만큼 반복
        {
            GameObject bullet = Instantiate(bulletFactory); //총알 생성
            bulletObjectPool.Add(bullet); //탄창에 총알 삽입

            bullet.SetActive(false); //비활성화
        }

    }

    //오브젝트 풀(탄창)에 비활성화 된 총알을 생성해서 저장(시작하는 시점:Start, 비활성 상태)
    //오브젝트 풀에서 비활성화된 총알을 찾아 발사, 활성화
  
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
            for (int i = 0; i < poolSize; i++) //탄창 수 만큼 반복-비활성화 된 총알 탐색
            {
                GameObject bullet = bulletObjectPool[i]; 
                if (bullet.activeSelf == false) //비활성화 된 총알 찾기
                {
                    bullet.SetActive(true); //비활성화 된 총알 활성화 (비활성화: 쏠 수 있는 상태의 총알, 활성화: 발사된 총알)
                    bullet.transform.position = firePosition.transform.position;
                    break; 
                }
            }
            //오브젝트 풀 배열 */

            /*
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position; 
            //오브젝트 풀 만들기 전 */

        }
    }
}
