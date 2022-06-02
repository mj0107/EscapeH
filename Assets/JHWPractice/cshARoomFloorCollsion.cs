using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshARoomFloorCollsion : MonoBehaviour
{
    [SerializeField] GameObject[] m_ARoomAnswerChessesPosition;
    void Start()
    {
        m_ARoomAnswerChessesPosition = new GameObject[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Chess")
        {
            if(collision.gameObject.name == "ARoomAnswerRock")
            {
                collision.transform.position = m_ARoomAnswerChessesPosition[0].transform.position;
            } 
            else if(collision.gameObject.name == "ARoomAnswerPawn")
            {
                collision.transform.position = m_ARoomAnswerChessesPosition[1].transform.position;
            }
            else if(collision.gameObject.name == "ARoomAnswerKing")
            {
                collision.transform.position = m_ARoomAnswerChessesPosition[2].transform.position;
            }
            else if(collision.gameObject.name == "ARoomAnswerBishop")
            {
                collision.transform.position = m_ARoomAnswerChessesPosition[3].transform.position;
            }
        }
    }

}
