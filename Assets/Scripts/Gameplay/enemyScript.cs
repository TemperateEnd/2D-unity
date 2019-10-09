using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject player;
    public static float moveSpeed;
    public int damage;

    void Start()
    {
        moveSpeed = 0.05f;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.transform);

        if(Vector2.Distance(transform.position, player.transform.position) > 5)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        else if (Vector2.Distance(transform.position, player.transform.position) > 5 && Vector2.Distance(transform.position, player.transform.position) < 2)
        {
            InvokeRepeating("Attack", 5, 5);
        }
    }

    void Attack()
    {
        //player.
    }
}
