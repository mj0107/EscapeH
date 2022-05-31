using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    [SerializeField] int[] correctAnswer = { 0, 0, 0, 0 };
    [SerializeField] int[] userAnswer = { 0, 0, 0, 0 };
    [SerializeField] GameObject[] dial;
    [SerializeField] GameObject hasp;

    public void IsCorrectAnswer()
    {
        int correct = 0;

        for (int i = 0; i < 4; i++)
        {
            while (userAnswer[i] < 0)
            {
                userAnswer[i] += 10;
            }

            if (userAnswer[i] == correctAnswer[i])
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
        hasp.transform.position = new Vector3(0f, 8f, 0f);
    }




    // direction = 상하좌우 방향, procedure = 다이얼 번호(0부터 시작)
    public void rotateDial(char direction, int procedure)
    {
        switch(direction)
        {
            case 'U':
                dial[procedure].transform.Rotate(0, 36f, 0);
                userAnswer[procedure]--;
                break;
            case 'D':
                dial[procedure].transform.Rotate(0, -36f, 0);
                userAnswer[procedure]++;
                break;
            case 'L':
                dial[procedure].transform.Rotate(-36f, 0, 0);
                userAnswer[procedure]--;
                break;
            case 'R':
                dial[procedure].transform.Rotate(36f, 0, 0);
                userAnswer[procedure]++;
                break;
        } 
    }
}
