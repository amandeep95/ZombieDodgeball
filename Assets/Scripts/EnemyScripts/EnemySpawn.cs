using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy, enemy2;
    private float countDownTimer;
    public float randMin, randMax;
    public int spawnNumber;
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = Random.Range(3f, 15f);
        //CreateEnemy();
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {

        //countDownTimer -= Time.deltaTime;
        //if (countDownTimer <= 0)
        //{
        //    float enemyType = Random.Range(1, 3);

        //    if (enemyType % 3 == 0)
        //    {
        //        Instantiate(enemy, transform.position, Quaternion.identity);
        //        countDownTimer = Random.Range(randMin, randMax);
        //    }
        //    else if (enemyType % 3 == 1)
        //    {
        //        Instantiate(enemy2, transform.position, Quaternion.identity);
        //        countDownTimer = Random.Range(randMin, randMax);
        //    }
        //    else if (enemyType % 3 == 2)
        //    {
        //        //instantate more of enemy 1 than enemy 2 (placeholder for 3rd enemy type)
        //        Instantiate(enemy, transform.position, Quaternion.identity);
        //        countDownTimer = Random.Range(randMin, randMax);
        //    }

        //}

        countDownTimer -= Time.deltaTime;
        if (countDownTimer <= 0)
        {
            if (canSpawn)
            {
                for (int i = 0; i < spawnNumber; i++)
                {
                    //CreateEnemy();
                    //print(i);



                    float enemyType = Random.Range(1, 3);

                    if (enemyType % 3 == 0)
                    {
                        Instantiate(enemy, transform.position, Quaternion.identity);
                        countDownTimer = Random.Range(randMin, randMax);
                    }
                    else if (enemyType % 3 == 1)
                    {
                        Instantiate(enemy2, transform.position, Quaternion.identity);
                        countDownTimer = Random.Range(randMin, randMax);
                    }
                    else if (enemyType % 3 == 2)
                    {
                        //instantate more of enemy 1 than enemy 2 (placeholder for 3rd enemy type)
                        Instantiate(enemy, transform.position, Quaternion.identity);
                        countDownTimer = Random.Range(randMin, randMax);
                    }



                }
                canSpawn = false;
            }
        }
    }

    void CreateEnemy()
    {
        //for (int i = 0; i < spawnNumber; i++)
        //{
        //    //CreateEnemy();
        //    Instantiate(enemy, transform.position, Quaternion.identity);
        //    print(i);
        //}
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
