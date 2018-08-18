using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : MonoBehaviour {
    
	[SerializeField]
	GameObject unityChanPrefab;

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
            unityChanPrefab.name,
            new Vector3(0f, 1f, 0f),
            Quaternion.identity,
            0
         );
#if UNITY_STANDALONE
        GameObject pcCamera = GameObject.FindWithTag("PCCamera");
        pcCamera.GetComponent<Camera>().enabled = true;
#elif UNITY_IOS
		GameObject smartPhoneCamera = GameObject.Find("SmartPhoneCamera");
		smartPhoneCamera.GetComponent<Camera>().enabled = true;
#endif
    }
}
