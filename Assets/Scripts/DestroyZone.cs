using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        //������Ʈ Ǯ �������� �� ���� ��Ȱ��ȭ�ǰ� ����
        
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
