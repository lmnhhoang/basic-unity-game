using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    private bool m_isGoal;
    private void OnTriggerEnter2D( Collider2D other )
    {
        if ( !m_isGoal )
        {
            if ( other.tag ==   "Player" )
            {
                m_isGoal = true;
            }
        }
    }
}
