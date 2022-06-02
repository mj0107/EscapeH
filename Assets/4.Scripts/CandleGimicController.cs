using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleGimicController : MonoBehaviour
{
    [SerializeField] GameObject[] shortCandle = new GameObject[6];
    [SerializeField] GameObject[] longCandle = new GameObject[4];

    private bool[] sIsOn = new bool[6];
    private bool[] lIsOn = new bool[4];

    int shortCandleCount = 0;
    int longCandleCount = 0;


    // 종료함수
    private void Update()
    {
        if (shortCandleCount == 1 && longCandleCount == 1)
        {
            OpenLock();
            shortCandleCount = 100;
            longCandleCount = 100;
        }
    }


    // 종료행동함수
    public void OpenLock()
    {
        GameController.Instance.roomBGimic[1] = true;
        GameObject.Find("Image2").GetComponent<Image>().color = new Color(1f, 0, 0, 0.5f);
    }



    private void OnClickCandle(int i, char c)
    {
        if (c == 'S')
        {
            if (sIsOn[i])
            {
                shortCandle[i].GetComponentInChildren<ParticleSystem>().Stop();
                sIsOn[i] = false;
                shortCandleCount--;
            }
            else
            {
                shortCandle[i].GetComponentInChildren<ParticleSystem>().Play();
                sIsOn[i] = true;
                shortCandleCount++;
            }
        }
        else
        {
            if (lIsOn[i])
            {
                longCandle[i].GetComponentInChildren<ParticleSystem>().Stop();
                lIsOn[i] = false;
                longCandleCount--;
            }
            else
            {
                longCandle[i].GetComponentInChildren<ParticleSystem>().Play();
                lIsOn[i] = true;
                longCandleCount++;
            }
        }
    }


    // btnColor : 버튼 색 (B O Y N R G P, S(RESET))
    public void pressButton(char SL, int num)
    {
        OnClickCandle(num, SL);
    }
}
