using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBook : MonoBehaviour
{
    public GameObject m_RedCanvas;

    public void Open()
    {
        m_RedCanvas.SetActive(true);
    }


    public void Close()
    {        
        gameObject.SetActive(false);
    }
}
