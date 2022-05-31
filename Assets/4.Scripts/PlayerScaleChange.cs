using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleChange : MonoBehaviour
{
    private Vector3 usualSize = new Vector3(4.0f, 4.0f, 4.0f);

    private void Start()
    {
        Invoke("ChangeScale", 0.5f);
        
    }

    private void ChangeScale()
    {
        this.gameObject.transform.localScale = usualSize;
    }
}
