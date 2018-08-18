using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : MonoBehaviour {
    
	[SerializeField]
	GameObject unityChanPrefab;
    // [SerializeField]
    // GameObject kajitaPrefab;

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
        var player = 
            PhotonNetwork.Instantiate(
                unityChanPrefab.name,
                //kajitaPrefab.name,
                new Vector3(0f, 1f, -30f),
                Quaternion.identity,
                0
        );

#if UNITY_EDITOR
        //SetFloatで0

#elif UNITY_IOS
        //SetFloatで1
#endif
    }
}
