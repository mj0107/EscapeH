using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGame : MonoBehaviour
{
    static public ChessGame Instance;

    [SerializeField] GameObject[] chess = new GameObject[3];
    public GameObject[] userAnswer = new GameObject[3];


    public int count = 0;


    private void Start()
    {
        Instance = this;
    }


    private void Update()
    {
        if (count == 3)
        {
            isCorrectAnswer();
            count++;
        }
    }

    private void isCorrectAnswer()
    {
        if (chess[0] == userAnswer[0] && chess[1] == userAnswer[1] && chess[2] == userAnswer[2])
        {
            Debug.Log("Correct!! godd!");
        }

    }

    public void addCount()
    {
        count++;
    }

    public void minusCount()
    {
        count--;
    }
}
