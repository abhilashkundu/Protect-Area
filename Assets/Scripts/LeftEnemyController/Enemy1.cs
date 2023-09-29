using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform[] Rnode1;
    [SerializeField] float nearToNode = 0.02f;
    [SerializeField] int indexNo = 0;
    public Rigidbody2D enemy;
    public float EnemyMoveSpeed = 3.3f;
    private void Update()
    {
        if (Vector2.Distance(Rnode1[indexNo].position, transform.position) <= nearToNode && indexNo!=Rnode1.Length-1)
        {
            indexNo++;
        }
    }

    private void FixedUpdate()
    {
        Vector2 Dir = (Rnode1[indexNo].position - transform.position).normalized;

        enemy.velocity = Dir * EnemyMoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "base")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
