using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandles : MonoBehaviour
{
    public GameObject ball;
    public bool hasBall, holding, cancatch;
    public Transform ballHold;
    Vector2 mousePos;
    public Camera cam;
    public GameObject player;
    private Vector2 dir;
    public float throwPower;
    public float maxPower, currentPower;

    float chargeTime = 0.0f;
    //public ParticleSystem chargedUpParticles;

    // Start is called before the first frame update
    void Start()
    {
        hasBall = false;
        holding = false;
        ballHold = this.gameObject.transform;
        //dir = player.GetComponent<RotatePlayer>().lookDir;
        //chargedUpParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - new Vector2(player.transform.position.x, player.transform.position.y);//mousePos - player.GetComponent<Rigidbody2D>().position;

        if (holding)
        {
            if (ball != null)
            {
                ball.transform.position = ballHold.transform.position;
                ball.transform.parent = transform;
            }
        }




        if (hasBall) //player is holding a ball
        {


            if (Input.GetButton("Fire1"))
            {


                chargeTime += Time.deltaTime;

            }

            //if (chargeTime >= 2)
            //{
            //    chargedUpParticles.Play();
            //}


            //throw ball
            if (Input.GetButtonUp("Fire1") && (chargeTime > 2))
            {
                chargeTime = 0;
                if (ball != null)
                {
                    holding = false;


                    ball.GetComponent<Rigidbody2D>().AddForce(dir.normalized * throwPower * 2);
                    hasBall = false;
                    holding = false;
                    ball.transform.parent = null;

                    //int seconds = (int)chargeTime % 60;
                    //print("CHARGED SHOT");
                    //chargeTime = 0;
                    //chargedUpParticles.Stop();
                }
            }
            else if (Input.GetButtonUp("Fire1") && (chargeTime < 2))
            {
                chargeTime = 0;
                if (ball != null)
                {
                    holding = false;


                    ball.GetComponent<Rigidbody2D>().AddForce(dir.normalized * throwPower);
                    hasBall = false;
                    holding = false;
                    ball.transform.parent = null;

                    //int seconds = (int)chargeTime % 60;
                    //print("NORMAL SHOT");

                }
            }

        }

        //if (chargeTime >= 2)
        //{
        //    chargedUpParticles.Play();
        //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Ball")
        //{
        //    ball = collision.gameObject;
        //    ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //    //ball.transform.position = ballHold.transform.position;
        //    hasBall = true;
        //    holding = true;
        //    //ball.transform.parent = transform;
        //}


    }

    void CaughtBall()
    {

    }


    void ThrowBall()
    {

    }
}
