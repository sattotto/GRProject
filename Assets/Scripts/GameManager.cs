using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            int[] hoge = new int[2];
            hoge = PlayerEmotions.getMaxEmotion();
            Debug.Log("EmoNum : " + hoge[0] +", EmoValue : " + hoge[1]);
        }
    }
}
