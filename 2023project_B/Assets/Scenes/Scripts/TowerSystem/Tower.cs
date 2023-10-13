using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3.0f;              //타워 사거리
    public float fireRate = 1.0f;           //타워 발사간격
    public LayerMask IsEnemy;                //레이어 시스템으로 감지

    public Collider[] colliderInRange;      //사거리에 감지된 collider 배열

    public List<EnemyController> enemiesInRange = new List<EnemyController>();      //사거리 안에 있는 Enemy 컴포넌트 List

    public float checkCounter;              //시간 체크용 float
    public float checkTime = 0.2f;          //0.2초마다 검출

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
