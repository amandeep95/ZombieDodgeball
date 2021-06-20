using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyDash : MonoBehaviour
{
    private GameObject player;
    private AIPath enemyPathFind;
    private bool canmove, canDash;
    public float enemyDashForce, enemyDashDuration;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyPathFind = gameObject.GetComponent<AIPath>();
        canmove = true;
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        enemyPathFind.enabled = canmove;


        //when P is pressed on keybaord stop moving and dash towards the player then turn on moving again
        if (Input.GetKeyDown(KeyCode.P))
        {
            canmove = !canmove;
        }

        float distanceToPlayer = CalcDistance(player, gameObject);
        Vector3 directionToPlayer = CalcDirection();


        if ((distanceToPlayer <= 7f) && (canDash))
        {
            //print("EnemyIsCloseNow");
            canmove = !canmove;
            StartCoroutine(DashToPlayer(gameObject.GetComponent<Rigidbody2D>(), directionToPlayer));
            canmove = !canmove;
            canDash = false;
            //return;
        }
        else if (distanceToPlayer > 7f)
        {
            canDash = true;
        }
    }

    float CalcDistance(GameObject player, GameObject enemy)
    {
        float dist = Vector2.Distance(player.transform.position, enemy.transform.position);
        return dist;
    }

    Vector3 CalcDirection()
    {
        Vector3 dir = player.transform.position - transform.position;
        return dir;
    }

    IEnumerator DashToPlayer(Rigidbody2D rb, Vector3 dir)
    {
        rb.AddForce(dir * (enemyDashForce * 100), ForceMode2D.Force);
        print("ENEMYDASHED");
        //canDash = false;
        yield return new WaitForSeconds(enemyDashDuration);
    }
}
