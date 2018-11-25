using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private MessageScript msgScript;
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
        
        "これで操作説明は終了です！\n" +
        "この黒い円を使っていろいろと行動をしてみて自分の物語を作ろう！";
    
	// Use this for initialization
	void Start () {
        hoge = GameObject.Find("MessageUI/Fade");
        filePath = Application.dataPath + @"\Resources\Narrative\narrative.txt"; // 生成した文章の保存パス
        ReadTXTFile("start");
        msgScript.SetMessagePanel(message);
        duration = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            writeText(NarrativeController.getEmotionText());
        }
        duration += Time.deltaTime;
        Debug.Log(duration);
        if (duration > 240 && !endFlg) {
            FadeController.isFadeOut = true;
            endFlg = true;
            ReadTXTFile("end1"); // end 1
        }
    }

    public static void writeText(string hoge) {
        StreamWriter textfile = new StreamWriter(filePath,true);// TextData.txtというファイルを新規で用意
        textfile.WriteLine(hoge);// ファイルに書き出したあと改行
        textfile.Flush();// StreamWriterのバッファに書き出し残しがないか確認
        textfile.Close();// ファイルを閉じる
    }

    public static void setMyGetDictionary(string key) {
        if (!getList.ContainsKey(key)) {
            getList.Add(key, 1);
        } else {
            getList[key] += 1;
        }
        int sum = 0;
        foreach(KeyValuePair<string, int> item in getList) {
            sum += item.Value;
            Debug.Log(item.Key + " : " + item.Value);
        }

        if (sum > 9) {
            FadeController.isFadeOut = true;
            endFlg = true;
            ReadTXTFile("end0"); // end 0
        }
    }

    public static void setMyEatDictionary(string key) {
        if (!getList.ContainsKey(key)) {
            eatList.Add(key, 1);
        } else {
            eatList[key] += 1;
        }
        int sum = 0;
        foreach(KeyValuePair<string, int> item in eatList) {
            sum += item.Value;
            if(item.Key == "毒キノコ" && item.Value > 4) {
                FadeController.isFadeOut = true;
                endFlg = true;
                ReadTXTFile("end3"); // end 3
                return;
            }
            Debug.Log(item.Key + " : " + item.Value);  
        }
        if (sum > 9) {
            FadeController.isFadeOut = true;
            endFlg = true;
            ReadTXTFile("end2"); // end 2
        }
    }

    public static void ReadTXTFile (string name) {
        string endMessage = "";
        TextAsset txtFile = Resources.Load(string.Format("Narrative/{0}", name)) as TextAsset; // Resouces/Narrative下の.txt読み込み
        StringReader reader = new StringReader(txtFile.text);

        while (reader.Peek() != -1) {
            string line = reader.ReadLine();
            writeText(line);
            endMessage += line + "\n";
        }
        if (endFlg) {
            var textObject = new GameObject("Text");
            textObject.transform.parent = hoge.transform;
            var text = textObject.AddComponent<Text>();
            text.rectTransform.sizeDelta = Vector2.zero;
            text.rectTransform.anchorMin = Vector2.zero;
            text.rectTransform.anchorMax = Vector2.one;
            text.rectTransform.anchoredPosition = new Vector2(.5f, .5f);
            text.text = endMessage;
            text.alignment = TextAnchor.MiddleCenter;
            text.font = Resources.FindObjectsOfTypeAll<Font>()[0];
            text.fontSize = 20;
        }
	}
}
