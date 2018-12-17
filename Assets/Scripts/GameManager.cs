using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private MessageScript msgScript;
    private TextWriter myTextWriter;
    public static GameObject hoge;
    private static string filePath;

    private float duration;
    private static bool endFlg = false;

    private static Dictionary<string, int> getList = new Dictionary<string, int>();
    private static Dictionary<string, int> eatList = new Dictionary<string, int>();

    private string message = "あなたは，自分の仕事の疲れからいつの間にか寝てしまっていました。\n" +
		"そしてあなたは誰もいない自分の職場で目を覚ましました。\n\n" +
		"メッセージを次に飛ばすには手元のコントローラーの親指当たりのボタンを押してね！\n" +

        "周りを見渡すには右のコントローラーのスティックを使うよ！\n" +
        "周りを見渡してプリンターを見つけよう！\n\n" +
        "プリンターを見つけたらまたボタンを押してね！\n" +

        "次はプリンターのところまで移動してみよう。\n" +
        "移動には、左のコントローラーのスティックを使うよ！\n\n" +
        "プリンターの前まで移動したらボタンを押してね。\n" +

        "プリンターからは黒い円の書かれた紙が出ている。\n" +
        "その紙をつかんでみよう！画面上に出てる手のアイコンを紙に合わせてどちらかのコントローラーを握りこもう！\n" +
        "握りこんだままで手を動かしたりしてみよう\n"　+
        "ボタンを押して次の画面に進んでね。\n" +
        
        "この黒い円は机とかの中から物を取り出すことができるよ！\n" +
        "この机に対して、紙を当てて中から物を取り出す動作をしてみよう！\n" +
        "一度どのような動作か近くのお兄さんに聞いて実践をしてみよう。\n\n" +

        "取り出した物体に対して、投げる/置く、食べる/飲む、手に入れるなどの動作をすることができるよ！\n" +
        "投げる/置く ... コントローラーを振りながら握る力を弱める(中指のボタンを離す)。\n" +
        "食べる/飲む ... 食べれそうなものを自分の顔のほうへもっていくと食べたりすることができる。\n" +
        "手に入れる　... 自分の腰の後ろに物体を回すようにするとその動作ができる。\n" +
        
        "これで操作説明は終了です！\n" +
        "この黒い円を使っていろいろと行動をしてみて自分の物語を作ろう！";
    
	// Use this for initialization
	void Start () {
        myTextWriter = new TextWriter();
        hoge = GameObject.Find("MessageUI/Fade");
        myTextWriter.writeOpening("start");
        msgScript.SetMessagePanel(message);
        duration = 0;
	}

    // Update is called once per frame
    void Update() {
        duration += Time.deltaTime;
        
        if (duration > 300 && !endFlg) {
            FadeController.isFadeOut = true;
            endFlg = true;
            myTextWriter.writeEnding("end1"); // end 1
        }
    }

    // public static void setMyGetDictionary(string key) {
    //     if (!getList.ContainsKey(key)) {
    //         getList.Add(key, 1);
    //     } else {
    //         getList[key] += 1;
    //     }
    //     int sum = 0;
    //     foreach(KeyValuePair<string, int> item in getList) {
    //         sum += item.Value;
    //         Debug.Log(item.Key + " : " + item.Value);
    //     }

    //     if (sum > 3) {
    //         FadeController.isFadeOut = true;
    //         endFlg = true;
    //         myTextWriter.writeEnding("end0"); // end 0
    //     }
    // }

    // public static void setMyEatDictionary(string key) {
    //     if (!getList.ContainsKey(key)) {
    //         eatList.Add(key, 1);
    //     } else {
    //         eatList[key] += 1;
    //     }
    //     int sum = 0;
    //     foreach(KeyValuePair<string, int> item in eatList) {
    //         sum += item.Value;
    //         if(item.Key == "毒キノコ" && item.Value > 1) {
    //             FadeController.isFadeOut = true;
    //             endFlg = true;
    //             myTextWriter.writeEnding("end3"); // end 3
    //             return;
    //         }
    //         Debug.Log(item.Key + " : " + item.Value);  
    //     }
    //     if (sum > 3) {
    //         FadeController.isFadeOut = true;
    //         endFlg = true;
    //         myTextWriter.writeEnding("end2"); // end 2
    //     }
    // }

    public void gameEnd(string prefsKey) {
        if (PlayerPrefs.GetInt(prefsKey,0) > 3) {
            if (prefsKey == "") {

            }
        }
    }

    public void messageShow(string message){
        msgScript.SetMessagePanel(message);
    }
}
