using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventCandle : UnityEvent<char, int>
{

}
public class CandleGimic : MonoBehaviour
{
    public UnityEventCandle unityEvent;

    [SerializeField] GameObject button;

    [SerializeField] char SL;
    [SerializeField] int num;

    public void OnClick()
    {
        unityEvent.Invoke(SL, num);
    }
}
