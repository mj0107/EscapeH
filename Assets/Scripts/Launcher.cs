using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    [SerializeField] TMP_InputField nicknameInputField; // 닉네임 입력 필드

    [SerializeField] TMP_InputField roomNameInputField; // CreateRoom 입력 필드
    [SerializeField] TMP_Text errorText; // ErrorMenu 에러 텍스트 필드
    [SerializeField] TMP_Text roomNameText; // RoomMenu 방 이름 텍스트 필드
    [SerializeField] GameObject startGameButton; // 게임시작 버튼

    [SerializeField] Transform roomListContent; // 룸 목록이 들어갈 위치
    [SerializeField] GameObject roomListItemPrefab; // 룸 목록에 들어갈 프리펩

    [SerializeField] Transform playerListContent; // 룸에 플레이어 목록이 들어갈 위치
    [SerializeField] GameObject playerListItemPrefab; // 플레이어 목록이 들어갈 프리펩


    //===================================================================================

    private void Awake()
    {
        Instance = this;
    }

    //===================================================================================

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // 설정한 포톤 서버에 따라 마스터 서버 연결
        Debug.Log("Connection to Master");
    }

    public override void OnConnectedToMaster() // 마스터서버 연결했을 때
    {
        PhotonNetwork.JoinLobby(); // 마스터 서버 연결시 로비로 연결
        Debug.Log("Connected to Master");

        PhotonNetwork.AutomaticallySyncScene = true; // 자동으로 모든 사람들의 scene 통일
    }

    public override void OnJoinedLobby() // 로버 연결했을 때
    {
        /* 로그인창 사용 X
        if (nicknameInputField.text == "") // 닉네임 입력칸이 공백이면 로그인
        {
            MenuManager.Instance.OpenMenu("login");
        }
        else
        {
        */
            MenuManager.Instance.OpenMenu("title"); // 로비에 들어오면 타이틀 메뉴 오픈
            Debug.Log("Joined Lobby");

            // 들어온 사람 이름을 Player + 랜덤 4자리 숫자 붙여서 정해주기
            PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
        //}
    }

    public void login()
    {
        if (string.IsNullOrEmpty(nicknameInputField.text))
        {
            return;
        }
        PhotonNetwork.NickName = nicknameInputField.text;
        MenuManager.Instance.OpenMenu("loading");
    }

    //===================================================================================

    public void CreateRoom() // 방 만들기
    {
        //if (string.IsNullOrEmpty(roomNameInputField.text)) // 빈값이면 만들어지지 않음
        //{
        //    return;
        //}

        PhotonNetwork.CreateRoom(roomNameInputField.text); // 포톤 네트워크 기능 : 방 만들기
        MenuManager.Instance.OpenMenu("loading"); // 로딩창 열기
    }

    public override void OnCreateRoomFailed(short returnCode, string message) // 방 만들기 실패
    {
        errorText.text = "Room Creation Failed: " + message;
        MenuManager.Instance.OpenMenu("error");
    }

    //===================================================================================

    public override void OnJoinedRoom() // roomMenu 입장시
    {
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name; // 들어간 방 이름 표시

        Player[] players = PhotonNetwork.PlayerList;

        if (players.Count() >= 2) // 2명 이상이 되면 방 숨김
        {
            PhotonNetwork.CurrentRoom.IsVisible = false;
        }

        if (players.Count() >= 3) // 3명 이상이 되면 leaveRoom
        {
            PhotonNetwork.LeaveRoom();
            errorText.text = "This room is full now.";
            MenuManager.Instance.OpenMenu("error");
        }

        foreach (Transform child in playerListContent) // 방에 들어가면 기존 이름표 삭제
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++) // 방에 들어가면 방에 있는 사람 목록만큼 이름표 생성
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
        startGameButton.SetActive(PhotonNetwork.IsMasterClient); // 방장만 게임시작 버튼 누를 수 있음
    }

    public void JoinRoom(RoomInfo info) // 방 입장시
    {
        PhotonNetwork.JoinRoom(info.Name); // 포톤 네트워크 기능 : 해당 이름 가진 방으로 접속
        MenuManager.Instance.OpenMenu("loading");
    }

    //===================================================================================

    public void LeaveRoom() // 방 떠날 때
    {
        PhotonNetwork.CurrentRoom.IsVisible = true; // 방 다시 보이게

        PhotonNetwork.LeaveRoom(); // 포톤 네트워크 기능 : 방 떠나기
        MenuManager.Instance.OpenMenu("loading"); // 로딩창 열기
    }

    public override void OnLeftRoom() // 방 떠나면 호출
    {
        MenuManager.Instance.OpenMenu("title"); // 방 떠나기 성공시 타이틀 메뉴 호출
    }

    public override void OnMasterClientSwitched(Player newMasterClient) // 방장이 나가서 바뀔 때
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    //===================================================================================

    public override void OnRoomListUpdate(List<RoomInfo> roomList) // 룸 리스트가 변경 될 때
    {
        foreach (Transform trans in roomListContent) // 업데이트 때마다 현재 모든 리스트 삭제
        {
            Destroy(trans.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++) // 존재하는 모든 룸을 룸리스트에 추가하고 해당 위치에 생성
        {
            if (!roomList[i].RemovedFromList) // 제거되지 않은 방만 생성
            {
                Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
            }
            
        }
    }

    //===================================================================================

    public override void OnPlayerEnteredRoom(Player newPlayer) // 다른 플레이어가 방에 들어오면
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }

    //===================================================================================

    public void StartGame()
    {
        PhotonNetwork.CurrentRoom.IsVisible = false; // 게임시작하면 방 숨김
        PhotonNetwork.LoadLevel(1); // 메뉴 씬이 0, 게임 씬이 1
    }

    //===================================================================================

    public void EndGame() // 게임 종료버튼 기능
    {
        Application.Quit();
    }


}
