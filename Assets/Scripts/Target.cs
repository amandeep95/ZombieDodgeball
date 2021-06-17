using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball")
        {
            print("hit");
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
