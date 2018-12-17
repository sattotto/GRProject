using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {

    public GameObject rightHand;
    public GameObject leftHand;

    public GameObject rightHandObject;
    public GameObject leftHandObject;

    private string grabHand = "";

    public string objectName = "";
    private List<string[]> objectKnowledgeList;
    private int index = 0;
    private CSVReader myCSVReader;
    public TextWriter myTextWriter;
    
    void Start() {
        myCSVReader = new CSVReader();
        myTextWriter = new TextWriter();
    }

	void Update () {
        if(ItemGrab() && objectName != "") {
            getKnowledgeList(objectName);
            GameObject prefab = (GameObject)Resources.Load(string.Format("Prefabs/{0}", objectKnowledgeList[index][0])); // ここでprefabの名前を入れる
            Vector3 GrabPos = OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) ? rightHand.transform.position : leftHand.transform.position;
            GameObject obj = Instantiate(prefab, GrabPos + new Vector3(0, 0.02f, 0), Quaternion.identity);
            obj.name = objectKnowledgeList[index][1];
            if (grabHand == "Right") { rightHandObject = obj; }
            if (grabHand == "Left") { leftHandObject = obj; }
            myTextWriter.writeText(GameObject.Find("GameManager").GetComponent<NarrativeController>().GrabNarrative(objectName, objectKnowledgeList[index][1]));
            resetParam();
        }
        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) < 0.2 && rightHandObjectGrabing() ) {
            myTextWriter.writeText(GameObject.Find("GameManager").GetComponent<NarrativeController>().putThrowNarrative(rightHandObject.name));
            rightHandObject = null;
        }
        if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) < 0.2 && leftHandObjectGrabing()) {
            myTextWriter.writeText(GameObject.Find("GameManager").GetComponent<NarrativeController>().putThrowNarrative(leftHandObject.name));
            leftHandObject = null;
        }
        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) < 0.2) { rightHandObject = null; }
        if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) < 0.2) { leftHandObject = null; }
    }

    void getKnowledgeList(string objName) {
        objectKnowledgeList = myCSVReader.ReadCSVFile(objName);
        getListIndex();
    }

    void getListIndex(){
        string EmoString = GameObject.Find("GameManager").GetComponent<NarrativeController>().getEmotion();
        for(int i = 0;i < objectKnowledgeList.Count;i++) {
            var item = objectKnowledgeList[i];
            if (item[2].Contains(EmoString)) {
                index = i;
            }
        }
    }

    void resetParam() {
        index = 0;
        grabHand = "";
    }

    public bool ItemGrab() {
        if (rightHandObject != null && leftHandObject == null) {
            if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger) && rightHandObject.tag == "item0") {
                grabHand = "Left";
                return true;
            }
        }
        if (leftHandObject != null && rightHandObject == null) {
            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && leftHandObject.tag == "item0") {
                grabHand = "Right";
                return true;
            }
        }
        return false;
    }

    public bool rightHandObjectGrabing() {
        if (rightHandObject != null) {
            if (rightHandObject.tag != "item0") {
                return true;
            }
        }
        return false;
    }
    public bool leftHandObjectGrabing() {
        if (leftHandObject != null) {
            if (leftHandObject.tag != "item0") {
                return true;
            }
        }
        return false;
    }
}
