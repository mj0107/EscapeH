using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventNormalButton : UnityEvent<char>
{

}

public class NormalButton : MonoBehaviour
{
    public UnityEventNormalButton unityEvent;

    [SerializeField] GameObject button;
    [SerializeField] char btnColor; // 버튼 색

    public void OnClick()
    {
        unityEvent.Invoke(btnColor);
    }
}
