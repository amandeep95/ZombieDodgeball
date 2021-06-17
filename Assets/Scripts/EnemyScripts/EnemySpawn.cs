using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private float countDownTimer;
    public float randMin, randMax;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = Random.Range(3f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        countDownTimer -= Time.deltaTime;
        if (countDownTimer <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            countDownTimer = Random.Range(randMin, randMax);
        }
    }
}
