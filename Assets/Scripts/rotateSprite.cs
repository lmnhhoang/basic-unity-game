using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSprite : MonoBehaviour
{
    public float m_rotSpeed;
    
    void Update()
    {
        transform.Rotate(new Vector3(0,0,-m_rotSpeed));
    }
}
