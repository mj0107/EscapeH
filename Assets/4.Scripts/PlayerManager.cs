using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;


    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Player[] players = PhotonNetwork.PlayerList;
        Vector3 pos = new Vector3();

        if (SceneManager.GetActiveScene().name == "BackGroundScene") // BackGround Scene
        {
            if (PhotonNetwork.NickName == players[0].NickName) // 0번째 플레이어와 1번째 플레이어의 스폰 위치 지정
            {
                pos = RoomManager.Instance.spawnPoint[0];
            }
            else
            {
                pos = RoomManager.Instance.spawnPoint[1];
            }
        }
        else if (SceneManager.GetActiveScene().name == "GameScene") // Game Scene
        {
            if (PhotonNetwork.NickName == players[0].NickName) // 0번째 플레이어와 1번째 플레이어의 스폰 위치 지정
            {
                pos = RoomManager.Instance.spawnPoint[2];
            }
            else
            {
                pos = RoomManager.Instance.spawnPoint[3];
            }
        }

        

        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), pos, Quaternion.identity);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), pos, Quaternion.identity);
        Debug.Log("Instantiated Player Controller");
    }
}
