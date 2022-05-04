using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    [SerializeField] int[] answer;
    [SerializeField] GameObject[] dial;
    [SerializeField] GameObject hasp;

    public void IsCorrectAnswer()
    {
        float angle;
        int correct = 0;
        for (int i = 0; i < 4; i++)
        {
            angle = dial[i].transform.eulerAngles.y;

            if (Math.Round(angle) == answer[i] * 36f)
            {
                correct++;
            }
        }

        if (correct == 4)
        {
            OpenLock();
        }

    }

    public void OpenLock()
    {
        hasp.transform.Translate(0, 2f, 0);
    }
}
