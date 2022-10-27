using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    public float m_jumpHeight = 10;
    
    private void OnTriggerEnter2D( Collider2D other )
    {
	    if ( other.gameObject.tag == "Player" ) 
	    {
	            other.gameObject.transform.Translate(Vector3.up * 7f * Time.deltaTime);
	            
    			var animator = GetComponent<Animator>();
                
    			animator.Play( "Jump" );
                
	    }
	}
}
