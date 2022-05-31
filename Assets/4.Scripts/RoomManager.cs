using Photon.Pun;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    public Vector3[] spawnPoint = new Vector3[2]; // 유저 생성할 위치

    private void Awake()
    {
        if (Instance) // 다른 룸매니저가 있다면, 현재 오브젝트 파괴
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); // 룸메니저가 나 혼자면 유지
        Instance = this;
    }


    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode load)
    {
        if (scene.buildIndex == 1) // Background 씬일 때,
        {
            // 포톤 프리펩에 있는 플레이어 매니저 생성
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }

        if (scene.buildIndex == 2) // GameScene일 때,
        {
            //PhotonNetwork.DestroyAll();
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }
}
