using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {

    private static string filePath;
    private static Dictionary<string, int> getList = new Dictionary<string, int>();

	// Use this for initialization
	void Start () {
        filePath = Application.dataPath + @"\Resources\Narrative\narrative.txt"; // 生成した文章の保存パス
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            writeText(NarrativeController.getEmotionText());
        }
    }

    public static void writeText(string hoge) {
        StreamWriter textfile = new StreamWriter(filePath,true);// TextData.txtというファイルを新規で用意
        textfile.WriteLine(hoge);// ファイルに書き出したあと改行
        textfile.Flush();// StreamWriterのバッファに書き出し残しがないか確認
        textfile.Close();// ファイルを閉じる
    }

    public static void setMyDictionary(string key) {
        if (!getList.ContainsKey(key)) {
            getList.Add(key, 1);
        } else {
            getList[key] += 1;
        }
        foreach(KeyValuePair<string, int> item in getList) {
            Debug.Log(item.Key + " : " + item.Value);  
        }
    }

    public static void ReadTXTFile (string name) {
		List<string[]> csvDatas = new List<string[]>();
        TextAsset txtFile = Resources.Load(string.Format("Narrative/{0}", name)) as TextAsset; // Resouces/Narrative下の.txt読み込み
        StringReader reader = new StringReader(txtFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            writeText(line);
        }
		
	}
}
