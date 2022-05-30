using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookClose : MonoBehaviour
{
    public GameObject m_CancelRedCanvas;

    void Start()
    {
       
    }

    
    void Update()
    {
        m_CancelRedCanvas.SetActive(false);
    }
}
