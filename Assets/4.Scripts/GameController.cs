using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public bool[] roomAGimic = { false, false, false }; // 책, 화로, 체스
    public bool[] roomBGimic = { false, false, false }; // 액자, 촛불, 체스


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if ((roomAGimic[0] == true && roomAGimic[1] == true && roomAGimic[2] == true)
            || (roomBGimic[0] == true && roomBGimic[1] == true && roomBGimic[2] == true))
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        GameObject.Find("UICanvas").transform.Find("txtEnd").transform.gameObject.SetActive(true);
    }


    public void GimicSuccess(char room, int gimic)
    {
        if (room == 'A')
        {
            roomAGimic[gimic] = true;
        }
        else if (room == 'B')
        {
            roomBGimic[gimic] = true;
        }
    }
}
