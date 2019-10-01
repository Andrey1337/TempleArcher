using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    public float speed = 40f;
    public Rigidbody2D rb;
    public Collider2D platformCollider;

    [Range(0,60)] public int secondsToDestroy = 20;
    private bool isStuck = false;
    private DateTime stuckTime;

    void Start()
    {
        rb.velocity = transform.right * speed;   

        if (rb.velocity.x < 0)
        {
            transform.Rotate(0f, 180f, 180f);
        }

        platformCollider.enabled = false;
    }

    
    void Update()
    {
        if(isStuck)
        {
            if (DateTime.Now.Subtract(stuckTime).TotalSeconds > secondsToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isStuck)
        {
            float rotationAngular = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            rb.rotation = rotationAngular;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        isStuck = true;
        stuckTime = DateTime.Now;

        rb.bodyType = RigidbodyType2D.Static;
        platformCollider.enabled = true;
    }

}
