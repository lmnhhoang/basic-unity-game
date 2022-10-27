using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public GameObject m_prefabBullet;
    public Transform m_shootPoint;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (m_prefabBullet == null)
            {
                Debug.Log("No prefab set");
            }
            else
            {
                Instantiate(m_prefabBullet, m_shootPoint.position, transform.rotation);
            }
        }
    }
}
