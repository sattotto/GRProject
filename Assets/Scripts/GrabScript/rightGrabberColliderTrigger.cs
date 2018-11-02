using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightGrabberColliderTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "item0")
        {
            GrabController.itemGrabFlg = true;
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "targetObj-1")
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && GrabController.itemGrabFlg == true)
            {
                // プレハブを取得
                GameObject prefab = (GameObject)Resources.Load("Prefabs/ToyCube");
                // プレハブからインスタンスを生成
                //Instantiate(prefab, new Vector3(1, 1, 1), Quaternion.identity);
                Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
                Debug.Log(NarrativeController.GrabNarrative(other.name, "箱"));
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "item0")
        {
            GrabController.itemGrabFlg = false;
        }
        if (other.gameObject.tag == "targetObj-1")
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
            {
                GrabController.objItemGrabFlg = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {

	}
}
