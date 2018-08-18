using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : MonoBehaviour {
    public GameObject player;

    void Start(){
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    void OnJoinedLobby(){
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed(){
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom(){
        PhotonNetwork.Instantiate(
            player.name,
            new Vector3(0f, 1f, 0f),
            Quaternion.identity,
            0
         );

        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        mainCamera.GetComponent<ThirdPersonCamera>().enabled = true;
    }
}
