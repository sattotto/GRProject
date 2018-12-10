using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextWriter : MonoBehaviour {

	private string filePath = Application.dataPath + @"\Resources\Narrative\narrative.txt";

	void Start () {
                filePath = Application.dataPath + @"\Resources\Narrative\narrative.txt"; // 生成した文章の保存パス
                Debug.Log("Start!!!");
	}

	public void writeText(string hoge) {
                StreamWriter textfile = new StreamWriter(filePath,true);// TextData.txtというファイルを新規で用意
                textfile.WriteLine(hoge);// ファイルに書き出したあと改行
                textfile.Flush();// StreamWriterのバッファに書き出し残しがないか確認
                textfile.Close();// ファイルを閉じる
        }

	public void writeEnding (string name) {
                string endMessage = "";
                TextAsset txtFile = Resources.Load(string.Format("Narrative/{0}", name)) as TextAsset; // Resouces/Narrative下の.txt読み込み
                StringReader reader = new StringReader(txtFile.text);

                while (reader.Peek() != -1) {
                        string line = reader.ReadLine();
                        writeText(line);
                        endMessage += line + "\n";
                }
	}

	public void writeOpening (string name) {
                Debug.Log(filePath);
                string startMessage = "";
                TextAsset txtFile = Resources.Load(string.Format("Narrative/{0}", name)) as TextAsset; // Resouces/Narrative下の.txt読み込み
                StringReader reader = new StringReader(txtFile.text);

                while (reader.Peek() != -1) {
                        string line = reader.ReadLine();
                        writeText(line);
                        startMessage += line + "\n";
                }
	}
}
