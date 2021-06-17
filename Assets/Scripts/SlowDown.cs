using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    private Rigidbody2D rb;
    public float slowFactor;
    Vector3 newpos;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        newpos = Vector3.Lerp(rb.velocity, Vector3.zero, slowFactor * Time.deltaTime);
        rb.velocity = newpos;

        //print("ball speed " + rb.velocity);
    }
}
