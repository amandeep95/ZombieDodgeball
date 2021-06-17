using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    EnemyHealth health;
    public GameObject bloodSplat;

    // Start is called before the first frame update
    void Start()
    {
        health = this.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.isDead)
        {
            Destroy(gameObject);
            Instantiate(bloodSplat, transform.position, Quaternion.identity);
        }
    }
}
