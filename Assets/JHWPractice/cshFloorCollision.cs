using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshFloorCollision : MonoBehaviour
{
    public GameObject m_QueenArea;
    public GameObject m_KingArea;
    public GameObject m_KnightArea;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Chess")
        {
            if(collision.gameObject.name == "Queen")
            {
                collision.transform.position = m_QueenArea.transform.position;
            }
            else if(collision.gameObject.name == "King")
            {
                collision.transform.position = m_KingArea.transform.position;
            }
            else if(collision.gameObject.name == "Knight")
            {
                collision.transform.position = m_KnightArea.transform.position;
            }
        }
    }

}
