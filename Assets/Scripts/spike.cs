using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public AudioClip m_HitClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag == "Player"  )
        {
            var player = other.GetComponent<PlayerControl>();
            
            player.Dead();
            
            var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot( m_HitClip );
        }
    }
}
