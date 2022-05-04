using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDialButtonAction : MonoBehaviour
{
    [SerializeField] GameObject[] dial;

    // 버튼 눌렸을 때 다이얼 돌리는 함수들.
    // 코드 효율적으로 써야하는데 방법이 생각안남..
    public void DialR1()
    {
        dial[0].transform.Rotate(0, 36f, 0);
    }

    public void DialR2()
    {
        dial[1].transform.Rotate(0, 36f, 0);
    }

    public void DialR3()
    {
        dial[2].transform.Rotate(0, 36f, 0);
    }

    public void DialR4()
    {
        dial[3].transform.Rotate(0, 36f, 0);
    }

    public void DialL1()
    {
        dial[0].transform.Rotate(0, -36f, 0);
    }

    public void DialL2()
    {
        dial[1].transform.Rotate(0, -36f, 0);
    }

    public void DialL3()
    {
        dial[2].transform.Rotate(0, -36f, 0);
    }

    public void DialL4()
    {
        dial[3].transform.Rotate(0, -36f, 0);
    }
}
