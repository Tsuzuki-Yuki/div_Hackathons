using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimController : Photon.MonoBehaviour
{

	float nextTime;

	bool onAppear;
	bool onDisappear;

	PhotonView _photonView;
	// Use this for initialization
	void Start ()
	{
		_photonView = GetComponent<PhotonView>();

#if UNITY_EDITOR
		//SetFloat(2.0)
#elif UNITY_IOS
		//SetFloat(0)
#endif
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!_photonView.isMine)
		{
			return;
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			var time = Time.time;
			nextTime = time + 10f;
			Debug.Log(nextTime);
		}
		
	}


	void OnPhotonSerializeView( PhotonStream i_stream, PhotonMessageInfo i_info )
    {
        if( i_stream.isWriting )
        {
            //データの送信
            i_stream.SendNext(nextTime);
			onDisappear = true;
			//SetFloat()
        }
        else
        {
            //データの受信
            float seconds = (float)i_stream.ReceiveNext();
			onAppear = false;
            //SetFloat(seconds)
        }
    }
}
