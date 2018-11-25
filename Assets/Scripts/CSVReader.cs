using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour {
    void Start() {
		// Debug.Log(ReadCSVFile("ColaMachine"));
    }

	public static List<string[]> ReadCSVFile (string name) {
		List<string[]> csvDatas = new List<string[]>();
        TextAsset csvFile = Resources.Load(string.Format("CSV/{0}", name)) as TextAsset; // Resouces/CSV下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
		csvDatas.RemoveAt(0); // headerのコメント部分の削除
		csvDatas.ForEach(items => {
			//Debug.Log(items.Length);
		});
		return csvDatas;
	}
}
