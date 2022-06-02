using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshARoomChessGame : MonoBehaviour
{
    static public cshARoomChessGame Instance;

    [SerializeField] GameObject[] ARoomChess = new GameObject[4];

    public GameObject[] ARoomChessAnswer = new GameObject[4];

    public int ARoomChessCount = 0;

    private void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(ARoomChessCount == 4)
        {
            CorrectAnswers();
        }
    }

    private void CorrectAnswers()
    {
        if(ARoomChess[0] == ARoomChessAnswer[0] &&
            ARoomChess[1] == ARoomChessAnswer[1] &&
            ARoomChess[2] == ARoomChessAnswer[2] &&
            ARoomChess[3] == ARoomChessAnswer[3] )
        {
            Debug.Log("Clear ARoom Chess Gimic");
            GameController.Instance.roomAGimic[2] = true;
            GameObject.Find("Image3").GetComponent<Image>().color = new Color(1f, 0, 0, 0.5f);
            /*
             * A Room Player가 Chess Gimic을 수행했다는 정보를 
             * GameManager에게 알려야 함.
             */
        }
    }

    public void CorrectAnswer()
    {
        ARoomChessCount++;
    }

    public void IncorrectAnswer()
    {
        ARoomChessCount--;
    }
}
