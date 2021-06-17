using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParry : MonoBehaviour
{
    bool cancatch;
    public BallHandles player;
    GameObject ball;
    public Transform ballHold;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)//OnTriggerEnter2D
    {
        if (collision.tag == "Ball") //if the ball is close to the player and they press Fire2
        {
            if (Input.GetButton("Fire2"))
            {
                //print("PARRYCAUGHT");
                ball = collision.gameObject;
                ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.ball = ball;
                ball.transform.position = ballHold.transform.position;


                player.holding = true;
                player.hasBall = true;



                //ball = collision.gameObject;
                //ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                ////ball.transform.position = ballHold.transform.position;
                //hasBall = true;
                //holding = true;
                ////ball.transform.parent = transform;
            }
        }


    }


}
