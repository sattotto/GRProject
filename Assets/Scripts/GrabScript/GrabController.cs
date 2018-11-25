using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {

    public GameObject rightHand;
    public GameObject leftHand;

    public static bool itemGrabFlg = false;
    public static bool objItemGrabFlg = false;
    public static bool grabingObjectFlg = false;

    public static string objectName = "";
    public static string grabingObjectName = "";
    private List<string[]> objectKnowledgeList;
    private int index = 0;

	void Update () {
        if(itemGrabFlg == true && objItemGrabFlg == true && (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))) {
            getKnowledgeList(objectName);
            objectName = objectKnowledgeList[objectKnowledgeList.Count-1][1];
            GameObject prefab = (GameObject)Resources.Load(string.Format("Prefabs/{0}", objectKnowledgeList[index][0])); // ここでprefabの名前を入れる
            Vector3 GrabPos = OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) ? rightHand.transform.position : leftHand.transform.position;
            GameObject obj = Instantiate(prefab, GrabPos + new Vector3(0, 0.02f, 0), Quaternion.identity);
            obj.name = objectKnowledgeList[index][1];
            Debug.Log(NarrativeController.GrabNarrative(objectName, objectKnowledgeList[index][1])); // 生成文章
            GameManager.writeText(NarrativeController.GrabNarrative(objectName, objectKnowledgeList[index][1]));
            grabingObjectName = objectKnowledgeList[index][1];
            grabingObjectFlg = true;
            resetParam();
        }
        
        if(grabingObjectFlg && (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) < 0.2 || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) < 0.2)) {
            Debug.Log(NarrativeController.putThrowNarrative(grabingObjectName));
            GameManager.writeText(NarrativeController.putThrowNarrative(grabingObjectName));
            grabingObjectFlg = false;
            grabingObjectName = "";
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

    void resetParam() {
        objectName = "";
        objItemGrabFlg = false;
        index = 0;
    }
}
