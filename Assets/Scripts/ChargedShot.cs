using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedShot : MonoBehaviour
{
    //the purpose of this script is to play the particles when the player has a charged shot ready


    float countTime = 0.0f;
    public ParticleSystem chargedParticles;
    BallHandles ball;
    bool holdingBall, playedParticles;

    // Start is called before the first frame update
    void Start()
    {
        chargedParticles.Stop();
        ball = this.gameObject.GetComponent<BallHandles>();
        playedParticles = false;
    }

    // Update is called once per frame
    void Update()
    {
        holdingBall = ball.hasBall;


        if (Input.GetButton("Fire1") && holdingBall)
        {


            countTime += Time.deltaTime;
            if (countTime > 2.3f && playedParticles == false)
            {
                chargedParticles.Play();
                playedParticles = true;
                //PlayParticles();

            }

        }
        if (Input.GetButtonUp("Fire1"))
        {
            countTime = 0;
            playedParticles = false;
        }

        
    }

    void PlayParticles()
    {
        chargedParticles.Play();
        //countTime = 0;
        holdingBall = false;
    }
}
