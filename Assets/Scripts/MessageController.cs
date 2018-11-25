using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour {

	//　MessageUIに設定されているMessageスクリプトを設定
	[SerializeField]
	private MessageScript msgScript;

	[SerializeField]
	private bool testFlg = false;
//　表示させるメッセージ
	private string message = "あなたは，自分の仕事の疲れからいつの間にか寝てしまっていました。\n" +
		"そしてあなたは誰もいない自分の職場で目を覚ましました。\n" +
		"メッセージを次に飛ばすには手元のコントローラーの親指当たりのボタンを押してね！\n";
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown(OVRInput.RawButton.A) && testFlg) {
			msgScript.SetMessagePanel (message);
		}
	}
}
