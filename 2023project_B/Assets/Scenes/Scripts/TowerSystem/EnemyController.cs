using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speedMod = 1.0f;
    public float timeSinceStart = 0.0f;
    public bool modeEnd = true;

    public float moveSpeed;

    private EnemyPath thePath;
    private int currentPoint;
    private bool reacheEnd;


    // Start is called before the first frame update
    void Start()
    {
        if (thePath == null)
        {
            thePath = FindAnyObjectByType<EnemyPath>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(modeEnd == false)
        {
            timeSinceStart -= Time.deltaTime;

            if(timeSinceStart <= 0.0f)
            {
                speedMod = 1.0f;
                modeEnd = true;
            }
        }

        if(reacheEnd == false)
        {
            transform.LookAt(thePath.points[currentPoint]);

            transform.position =
                Vector3.MoveTowards(transform.position, thePath.points[currentPoint].position, moveSpeed * Time.deltaTime * speedMod);

            if(Vector3.Distance(transform.position , thePath.points[currentPoint].position) < 0.01f)
            {
                currentPoint += 1;
                if(currentPoint >= thePath.points.Length)
                {
                    reacheEnd = true;
                }
            }
        }

        

    }

    public void SetMode(float Value)
    {
        modeEnd = false;
        speedMod = Value;
        timeSinceStart = 2.0f;
    }

}
