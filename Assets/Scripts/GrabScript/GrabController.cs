using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {

    public GameObject rightHand;
    public GameObject leftHand;

    public static bool itemGrabFlg = false;
    public static bool objItemGrabFlg = false;

    void Start() {

    }

	void Update () {
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            // プレハブを取得
            GameObject prefab = (GameObject)Resources.Load("Prefabs/ToyCubePf");
            // プレハブからインスタンスを生成
            //Instantiate(prefab, new Vector3(1, 1, 1), Quaternion.identity);
            Instantiate(prefab, leftHand.transform.position, Quaternion.identity);
        }
    }

}
