using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.LoadLevel(2);
    }
}
