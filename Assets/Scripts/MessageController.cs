using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour {

	//　MessageUIに設定されているMessageスクリプトを設定
	[SerializeField]
	private MessageScript msgScript;
//　表示させるメッセージ
	private string message = "かかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかかか"
		+ "ききききききききききききききききききききききききききききききききききききききききききききききききききききききき\n"
		+ "くくくくく\n"
		+ "けけけけけけけけけけけけ";
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown(OVRInput.RawButton.A)) {
			msgScript.SetMessagePanel (message);
		}
	}
}
