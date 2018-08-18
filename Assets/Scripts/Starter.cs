using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
	[SerializeField]
	Button startButton;

	// Use this for initialization
	void Start ()
	{
		startButton.onClick.AddListener(() =>
		{
			startButton.gameObject.transform.root.gameObject.SetActive(false);
			//アニメーション再生
			//音楽再生
		});
	}
}
