using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("hoge");
        if (OVRInput.GetDown(OVRInput.RawButton.A)){
            Debug.Log("ボタンを押した");
            SceneManager.LoadScene("Main");
        }
    }
}
