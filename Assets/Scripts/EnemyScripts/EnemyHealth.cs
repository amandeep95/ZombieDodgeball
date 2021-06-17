using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int totalHealth;

    [HideInInspector]
    public bool isDead;
    
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalHealth <= 0)
        {
            isDead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            //ball = col.gameObject;
            totalHealth--;
            print("Enemy Hit by ball");
            //check the ball is moving above a certain velocity and is not held by player
            //if (ball.GetComponent<Rigidbody2D>().velocity.x >= 1.8f || ball.GetComponent<Rigidbody2D>().velocity.y >= 1.8f)
            //{
            //    print("Enemy Hit by ball");
            //}

        }
    }
}
