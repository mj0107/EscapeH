using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshCheckCollisionARoomChess : MonoBehaviour
{
    [SerializeField] int CorrectNum;

    private void OnTriggerEnter(Collider other)
    {
        cshARoomChessGame.Instance.ARoomChessAnswer[CorrectNum] = other.gameObject;
    }
}
