using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text text;


    Player player; // Photon.Realtime : using 해야 Player 선언 가능


    public void SetUp(Player _player)
    {
        player = _player;
        text.text = _player.NickName; // 플레이어 이름 받아서 그 사람 이름이 목록에 뜨도록
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) // 플레이어가 방을 떠났을 때
    {
        if (player == otherPlayer) // 플레이어가 나면 이름표 삭제
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject); // 이름표 삭제
    }
}
