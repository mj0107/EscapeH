using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalButtonController : MonoBehaviour
{
    [SerializeField] bool[] correctAnswer = { true, true, false, false, true, false, true };
    [SerializeField] bool[] userAnswer = { false, false, false, false, false, false, false };
    public bool isAnswer = false;

    [SerializeField] GameObject[] display;

    private int userAnsIndex = 0;

    public void IsCorrectAnswer()
    {
        int correct = 0;

        for (int i = 0; i < 7; i++)
        {
            if (userAnswer[i] == true && correctAnswer[i] == userAnswer[i])
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
        GameController.Instance.roomAGimic[1] = true;
    }




    // btnColor : 버튼 색 (B O Y N R G P, S(RESET))
    public void pressButton(char btnColor)
    {
        if (btnColor == 'S') // SUBMIT
        {
            IsCorrectAnswer();
        }

        if (btnColor == 'T') // RESET
        {
            for (int i = 0; i < 4; i++)
            {
                display[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0.5f);
            }
            for (int i = 0; i < 7; i++)
            {
                userAnswer[i] = false;
            }
            userAnsIndex = 0;
        }
        
        if (userAnsIndex < 4)
        {
            if (btnColor == 'B' && userAnswer[0] != true)
            {
                userAnswer[0] = true;
                display[userAnsIndex++].GetComponent<Renderer>().material.color = new Color(0, 0.33f, 1f, 0.5f);
            }
            else if (btnColor == 'O' && userAnswer[1] != true)
            {
                userAnswer[1] = true;
                display[userAnsIndex++].GetComponent<Renderer>().material.color = new Color(1f, 0.32f, 0, 0.5f);
            }
            else if (btnColor == 'Y' && userAnswer[2] != true)
            {
                userAnswer[2] = true;
                display[userAnsIndex++].GetComponent<Renderer>().material.color = new Color(1f, 0.78f, 0, 0.5f);
            }
            else if (btnColor == 'N' && userAnswer[3] != true)
            {
                userAnswer[3] = true;
                display[userAnsIndex++].GetComponent<Renderer>().material.color = new Color(0.24f, 0.02f, 0.6f, 0.5f);
            }
            else if (btnColor == 'R' && userAnswer[4] != true)
            {
                userAnswer[4] = true;
                display[userAnsIndex++].GetComponent<Renderer>().material.color = new Color(1f, 0, 0, 0.5f);
            }
            else if (btnColor == 'G' && userAnswer[5] != true)
            {
                userAnswer[5] = true;
                display[userAnsIndex++].GetComponent<Renderer>().material.color = new Color(0.7f, 1f, 0, 0.5f);
            }
            else if (btnColor == 'P' && userAnswer[6] != true)
            {
                userAnswer[6] = true;
                display[userAnsIndex++].GetComponent<Renderer>().material.color = new Color(0.58f, 0, 0.97f, 0.5f);
            }
        }
    }
}
