using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {

    public GameObject rightHand;

    bool itemGrabFlg = false;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "item0") {
            itemGrabFlg = true;
		}
	}

	void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "item0") {
            itemGrabFlg = false;
        }
    }

	void Update () {

        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            // プレハブを取得
            GameObject prefab = (GameObject)Resources.Load("Prefabs/ToyCubePf");
            // プレハブからインスタンスを生成
            //Instantiate(prefab, new Vector3(1, 1, 1), Quaternion.identity);
            Instantiate(prefab, rightHand.transform.position, Quaternion.identity);
        }
    }

}
