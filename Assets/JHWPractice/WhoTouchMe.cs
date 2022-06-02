using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoTouchMe : MonoBehaviour
{
    [SerializeField] int placeNum;

    private void OnTriggerEnter(Collider other)
    {
        ChessGame.Instance.userAnswer[placeNum] = other.gameObject;
    }
}
