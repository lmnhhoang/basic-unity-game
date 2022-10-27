using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullte : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bulletSpeed;
    float timer;
    public float forwardTime = 1.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= forwardTime)
        {
            rb.velocity = -transform.right * bulletSpeed;
        }
        else
        {
            rb.velocity = transform.right * bulletSpeed;
        }
        
    }
}
