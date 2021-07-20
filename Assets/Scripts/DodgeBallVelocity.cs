using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBallVelocity : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity;
        //print(speed.magnitude);
    }
}
