using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GANTZTrigger : MonoBehaviour {

	[SerializeField] private Material gantzMat;
	private float time;

	
	void Update () {
		//5sec立ったらフラグを消す。
		if (GetFloatTime() - this.time > 5) {
			gantzMat.SetFloat("_Appear", 0);
			gantzMat.SetFloat("_Disappear", 0);
			gantzMat.SetFloat("_StartTime", 0);
		}
	}

	//出現エフェクト再生
	void Appear(float time) {
		gantzMat.SetFloat("_Appear", 1);
		gantzMat.SetFloat("_StartTime", time);
		this.time = time;
	}
	
	//消失エフェクト再生
	void Disappear(float time) {
		gantzMat.SetFloat("_Disappear", 1);
		gantzMat.SetFloat("_StartTime", time);
		this.time = time;
	}
	
	//現在時刻をFloatで取得
	float GetFloatTime() {
		var nowTime = System.DateTime.UtcNow;
		return nowTime.Second;
	}
}
