using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeBallCollider : MonoBehaviour
{
    private GameObject player;
    private Transform parryPoint;
    public bool noCollision = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        parryPoint = player.transform.GetChild(2);
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), gameObject.GetComponent<CircleCollider2D>(), noCollision);

        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), parryPoint.gameObject.GetComponent<PolygonCollider2D>(), noCollision);
    }
}
