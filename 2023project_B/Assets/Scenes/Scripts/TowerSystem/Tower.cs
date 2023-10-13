using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3.0f;              //Ÿ�� ��Ÿ�
    public float fireRate = 1.0f;           //Ÿ�� �߻簣��
    public LayerMask IsEnemy;                //���̾� �ý������� ����

    public Collider[] colliderInRange;      //��Ÿ��� ������ collider �迭

    public List<EnemyController> enemiesInRange = new List<EnemyController>();      //��Ÿ� �ȿ� �ִ� Enemy ������Ʈ List

    public float checkCounter;              //�ð� üũ�� float
    public float checkTime = 0.2f;          //0.2�ʸ��� ����

    public bool enemiesUpdate;

    // Start is called before the first frame update
    void Start()
    {
        checkCounter = checkTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdate = false;

        checkCounter -= Time.deltaTime;

        if(checkCounter <= 0)
        {
            checkCounter = checkTime;

            colliderInRange = Physics.OverlapSphere(transform.position, range, IsEnemy);

            enemiesInRange.Clear();

            foreach(Collider col in colliderInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }

            enemiesUpdate = true;

        }
    }
}
