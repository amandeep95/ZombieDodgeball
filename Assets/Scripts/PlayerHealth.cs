using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //kill player
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            enemy = col.gameObject;
            int damage = enemy.GetComponent<EnemyDamage>().damageFactor;
            playerHealth -= (1 * damage);
            //playerHealth--;
        }
    }
}
