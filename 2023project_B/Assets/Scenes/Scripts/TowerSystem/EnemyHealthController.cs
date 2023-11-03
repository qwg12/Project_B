using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int totalHealth = 50;                    //�ʷ��ʱ� ����
    
    public void TakeDamage(int damageAmount)        
    {
        totalHealth -= damageAmount;                //�Ķ���ͷ� ���� ���� ü�¿��� �Ҹ�

        if(totalHealth <= 0)                        //0���ϸ� ���ó��
        {
            totalHealth = 0;
            Destroy(gameObject);
        }
    }
}
