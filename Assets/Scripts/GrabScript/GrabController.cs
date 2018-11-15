using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {

    public GameObject rightHand;
    public GameObject leftHand;

    public static bool itemGrabFlg = false;
    public static bool objItemGrabFlg = false;

    public static string objectName = "";
    private List<string[]> objectKnowledgeList;
    private int index;

	void Update () {
        /*
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            // プレハブを取得
            GameObject prefab = (GameObject)Resources.Load("Prefabs/ToyCubePf");
            // プレハブからインスタンスを生成
            //Instantiate(prefab, new Vector3(1, 1, 1), Quaternion.identity);
            Instantiate(prefab, leftHand.transform.position, Quaternion.identity);
        }
        */
        if(itemGrabFlg == true && objItemGrabFlg == true && (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))) {
            getKnowledgeList(objectName);
            GameObject prefab = (GameObject)Resources.Load(string.Format("Prefabs/{0}", objectKnowledgeList[index][0])); // ここでprefabの名前を入れる
            Vector3 GrabPos = OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) ? rightHand.transform.position : leftHand.transform.position;
            Instantiate(prefab, GrabPos + new Vector3(0, 0.02f, 0), Quaternion.identity);
            Debug.Log(NarrativeController.GrabNarrative(objectName, objectKnowledgeList[index][1])); // 生成文章
            objectName = "";
            objItemGrabFlg = false;
        }
    }

    void getKnowledgeList(string objName) {
        objectKnowledgeList = CSVReader.ReadCSVFile(objName);
        getListIndex();
    }

    void getListIndex(){
        string EmoString = NarrativeController.getEmotion();
        for(int i = 0;i < objectKnowledgeList.Count;i++) {
            var item = objectKnowledgeList[i];
            if (item[2].Contains(EmoString)) {
                index = i;
            }
        }
    }
}
