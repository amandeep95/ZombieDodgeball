using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed, runMultiplier;
    private float setSpeed, setVelo;
    public bool canRun;

    private Rigidbody2D player;

    public float maxRunTime;
    public float velo;

    public float dashDistance;
    bool isDashing;

    Vector3 moveDir;
    RaycastHit2D hit;

    [SerializeField] private Transform dashEffect;

    // Start is called before the first frame update
    void Start()
    {
        setSpeed = speed;
        setVelo = velo;
        player = gameObject.GetComponent<Rigidbody2D>();
        //dashDistance *= 5000f;
    }

    private void FixedUpdate()
    {


        player.velocity = new Vector2(Input.GetAxis("Horizontal") * velo, Input.GetAxis("Vertical") * velo);

        if (TryMove(moveDir, velo * Time.deltaTime))
        {

        }


    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3(player.velocity.x, player.velocity.y).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (player.velocity.x != 0 || player.velocity.y != 0)
            {
                //print("dash");

                StartCoroutine(Dash(player));
            }

        }


        


        //if (canRun)
        //{
        //    if (Input.GetKeyDown(KeyCode.LeftShift))
        //    {
        //        speed = setSpeed * runMultiplier;
        //        velo = setVelo * runMultiplier;
        //        //start timer

        //        //canRun is false after timer runs out
        //    }
        //    else if (Input.GetKeyUp(KeyCode.LeftShift))
        //    {
        //        speed = setSpeed;
        //        velo = setVelo;
        //        //stop / replenish timer
        //    }
        //}

        //print(speed);
    }


    private bool CanMove(Vector2 dir, float dist)
    {
        return Physics2D.Raycast(transform.position, player.velocity, dist).collider == null;
    }

    private bool TryMove(Vector3 baseMoveDir, float dist)
    {
        bool canMove = CanMove(baseMoveDir, dist);
        if (!canMove)
        {
            //cannot move diagonally
            baseMoveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = baseMoveDir.x != 0f && CanMove(baseMoveDir, dist);
            if (!canMove)
            {
                //cant move horizonally
                baseMoveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = baseMoveDir.y != 0f && CanMove(baseMoveDir, dist);
            }
        }

        if (canMove)
        {
            player.velocity = new Vector2(Input.GetAxis("Horizontal") * velo, Input.GetAxis("Vertical") * velo);
            return true;
        } else
        {
            return false;
        }
    }


    //try this in the update method and not a corroutine
    IEnumerator Dash(Rigidbody2D rb)
    {
        //Vector3 beforePos = transform.position;



        rb.AddForce(rb.velocity * dashDistance, ForceMode2D.Force);


        //Transform dash = Instantiate(dashEffect, beforePos, Quaternion.identity );
        //Vector3 newPos = transform.position;
        //dash.rotation = Quaternion.LookRotation(Vector3.forward, player.velocity);
        //Destroy(dash.gameObject, 0.5f);
        yield return new WaitForSeconds(1f);
    }

    //useless
    void Daash()
    {
        
        transform.position += moveDir * dashDistance;

    }

}
