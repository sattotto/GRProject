using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextWriter : MonoBehaviour {

	private string filePath = Application.dataPath + @"\Resources\Narrative\narrative.txt";
        private string filePath_non = Application.dataPath + @"\Resources\Narrative\narrative_nonEmo.txt";

	void Start () {
                filePath = Application.dataPath + @"\Resources\Narrative\narrative.txt"; // 生成した文章の保存パス
                filePath_non = Application.dataPath + @"\Resources\Narrative\narrative_nonEmo.txt"; // 生成した文章の保存パス
                Debug.Log("Start!!!");
	}

	public void writeText(string hoge) {
                if (GameObject.Find("GameManager").GetComponent<GameManager>().isTutorial) {
                        return;
                }
                StreamWriter textfile = new StreamWriter(filePath,true);// TextData.txtというファイルを新規で用意
                textfile.WriteLine(hoge);// ファイルに書き出したあと改行
                textfile.Flush();// StreamWriterのバッファに書き出し残しがないか確認
                textfile.Close();// ファイルを閉じる
        }

        public void writeText_non(string hoge) {
                if (GameObject.Find("GameManager").GetComponent<GameManager>().isTutorial) {
                        return;
                }
                StreamWriter textfile_non = new StreamWriter(filePath_non,true);// TextData.txtというファイルを新規で用意
                textfile_non.WriteLine(hoge);// ファイルに書き出したあと改行
                textfile_non.Flush();// StreamWriterのバッファに書き出し残しがないか確認
                textfile_non.Close();// ファイルを閉じる
        }

	public void writeEnding (string name) {
                string endMessage = "";
                TextAsset txtFile = Resources.Load(string.Format("Narrative/{0}", name)) as TextAsset; // Resouces/Narrative下の.txt読み込み
                StringReader reader = new StringReader(txtFile.text);

                while (reader.Peek() != -1) {
                        string line = reader.ReadLine();
                        writeText(line);
                        writeText_non(line);
                        endMessage += line + "\n";
                }
	}

	public void writeOpening (string name) {
                string startMessage = "";
                TextAsset txtFile = Resources.Load(string.Format("Narrative/{0}", name)) as TextAsset; // Resouces/Narrative下の.txt読み込み
                StringReader reader = new StringReader(txtFile.text);

                while (reader.Peek() != -1) {
                        string line = reader.ReadLine();
                        writeText(line);
                        writeText_non(line);
                        startMessage += line + "\n";
                }
	}
}
