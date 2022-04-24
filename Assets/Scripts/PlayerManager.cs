using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    int sceneNumber = 0;


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

        if (PhotonNetwork.NickName == players[0].NickName) // 0번째 플레이어와 1번째 플레이어의 스폰 위치 지정
        {
            pos = RoomManager.Instance.spawnPoint[0];
        }
        else
        {
            pos = RoomManager.Instance.spawnPoint[1];
        }

        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), pos, Quaternion.identity);
        Debug.Log("Instantiated Player Controller");
    }
}
