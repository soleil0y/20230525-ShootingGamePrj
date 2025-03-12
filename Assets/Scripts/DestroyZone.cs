using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        //오브젝트 풀 변경으로 이 역시 비활성화되게 변경
        
        other.gameObject.SetActive(false);

        if (other.gameObject.name.Contains("BUL"))
        {
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(other.gameObject);
        }
        else if (other.gameObject.name.Contains("ENM"))
        {
            GameObject emObject = GameObject.Find("EnemyManager");
            EnemyManager manager = emObject.GetComponent<EnemyManager>();
            manager.enemyObjectPool.Add(other.gameObject);
        }
    }
}
