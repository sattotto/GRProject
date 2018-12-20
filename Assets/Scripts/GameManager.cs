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
		"\n" +

        "周りを見渡すには右のコントローラーのスティックを使うよ！\n" +
        "周りを見渡してプリンターを見つけよう！\n\n" +
        "\n" +

        "次はプリンターのところまで移動してください。\n" +
        "\n\n" +
        "\n" +

        "プリンターからは黒い円の書かれた紙が出ている。\n" +
        "この机に対して、紙を当てて中から物を取り出す動作をしてみましょう。\n" +
        "\n"　+
        "\n" +
        
        "\n" +
        "この机に対して、紙を当てて中から物を取り出す動作をしてみましょう。\n" +
        "一度どのような動作か近くのお兄さんに聞いて実践をしてみよう。\n\n" +
        
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

        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log(PlayerPrefs.GetInt("get"));
            Debug.Log(PlayerPrefs.GetInt("eat"));
            PlayerPrefs.DeleteAll();
        }
    }

    public void gameEnd(string prefsKey) {
        string endMessage = "";
        if (PlayerPrefs.GetInt(prefsKey,0) > 3) {
            if (prefsKey == "eat") {
                FadeController.isFadeOut = true;
                endFlg = true;
                myTextWriter.writeEnding("end0"); // end 0
                TextAsset txtFile = Resources.Load(string.Format("Narrative/end0")) as TextAsset; // Resouces/Narrative下の.txt読み込み
                StringReader reader = new StringReader(txtFile.text);
                while (reader.Peek() != -1) {
                    string line = reader.ReadLine();
                    endMessage += line + "\n";
                }
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
            if (prefsKey == "get") {
                FadeController.isFadeOut = true;
                endFlg = true;
                myTextWriter.writeEnding("end2"); // end 2
                TextAsset txtFile = Resources.Load(string.Format("Narrative/end2")) as TextAsset; // Resouces/Narrative下の.txt読み込み
                StringReader reader = new StringReader(txtFile.text);
                while (reader.Peek() != -1) {
                    string line = reader.ReadLine();
                    endMessage += line + "\n";
                }
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

    public void messageShow(string message){
        msgScript.SetMessagePanel(message);
    }
}
