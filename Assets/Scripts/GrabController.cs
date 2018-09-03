using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {

    bool itemGrabFlg = false;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "item0") {
			Debug.Log("hoge");
            itemGrabFlg = true;
		}
	}

	void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "item0") {
            Debug.Log("fuga");
            itemGrabFlg = false;
        }
    }

	void Update () {

        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            // プレハブを取得
            GameObject prefab = (GameObject)Resources.Load("Prefabs/ToyCubePf");
            // プレハブからインスタンスを生成
            Instantiate(prefab, new Vector3(1, 1, 1), Quaternion.identity);
        } else
        {
            
        }
    }

}
