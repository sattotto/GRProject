using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

	public GameObject VRCharacter;

	[SerializeField]
	private MessageScript msgScript;

	private float duration;

	// Use this for initialization
	void Start () {
		msgScript.SetMessagePanel("これからシステムのチュートリアルを始めます。\n" +
		"メッセージ送りにはA,B、X,Yのボタンを押してください。\n\n" +
		"\n" +

        "周りを見渡すには右のコントローラーのスティックを使います。\n" +
        "周りを見渡してテーブルを見つけてください\n\n" +
        "\n" +

        "移動には、左のコントローラーのスティックを使います。\n\n" +
        "テーブルの前まで移動してください。\n" +
		"\n" +

        "テーブルの上の箱などはつかむことができます。\n" +
        "箱をつかんで投げてみたりして操作に慣れましょう。\n" +
        "\n"　+
        "つかむには中指当たりのボタンを押すとつかむことができます。\n" +

        "物体に対して、投げる/置く、食べる/飲む、手に入れるなどの動作をすることができます。\n" +
        "投げる/置く ... コントローラーを振りながら握る力を弱める(中指のボタンを離す)。\n" +
        "食べる/飲む ... 食べれそうなものを自分の顔へもっていくと食べたりすることができる。\n" +
        "手に入れる　... 自分の腰の後ろに物体を回すようにするとその動作ができる。\n" +
        
        "これで操作説明は終了です！\n" +
        "物語生成フェーズに移動する際は言ってください");
		duration = 0;
	}
	
	// Update is called once per frame
	void Update () {
		duration += Time.deltaTime;
		nextStage();
	}

	private void nextStage() {
		if(VRCharacter.transform.position.y < -1 || Input.GetKeyDown(KeyCode.Return) || duration > 300) {
			SceneManager.LoadScene("Main");
		}
	}
}
