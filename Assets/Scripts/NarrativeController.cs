using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour {

    private GameManager myGameManager;

    void Start() {
        myGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public enum EmotionEnum
    {
        Joy, Fear, Disgust, Sadness, Anger, Surprise, Contempt, None
    }

    static int[] EmotionValue = new int[2];

    public string getEmotionText() {        
        EmotionValue = GameObject.Find("VRCameraController").GetComponent<PlayerEmotions>().getMaxEmotion();
        //Debug.Log("EmoNum : " + EmotionValue[0] + ", EmoValue : " + EmotionValue[1] + ", Emotion : " + (EmotionEnum)EmotionValue[0]);
        EmotionEnum Emo = (EmotionEnum)EmotionValue[0];
        return Emo.DisplayEmotion();
    }

    public string getEmotion() {
        EmotionValue = GameObject.Find("VRCameraController").GetComponent<PlayerEmotions>().getMaxEmotion();
        EmotionEnum Emo = (EmotionEnum)EmotionValue[0];
        return Emo.ToString();
    }

    public string GrabNarrative(string targetObj, string grabObj) {
        sendMessageScript(getEmotionText() + targetObj + "から、" + grabObj + "を取り出した。");
        return getEmotionText() + targetObj + "から、" + grabObj + "を取り出した。";
    }

    public string GrabNarrative_non(string targetObj, string grabObj) {
        sendMessageScript(getEmotionText() + targetObj + "から、" + grabObj + "を取り出した。");
        return targetObj + "から、" + grabObj + "を取り出した。";
    }

    public string putThrowNarrative(string grabObj){
        if(OVRInput.GetLocalControllerVelocity (OVRInput.Controller.LTouch).magnitude > 0.7 || OVRInput.GetLocalControllerVelocity (OVRInput.Controller.RTouch).magnitude > 0.7) {
            sendMessageScript(getEmotionText() + grabObj + "を投げた。");
            return getEmotionText() + grabObj + "を投げた。";
        }
        sendMessageScript(getEmotionText() + grabObj + "を置いた。");
        return getEmotionText() + grabObj + "を置いた。";
    }

    public string putThrowNarrative_non(string grabObj){
        if(OVRInput.GetLocalControllerVelocity (OVRInput.Controller.LTouch).magnitude > 0.7 || OVRInput.GetLocalControllerVelocity (OVRInput.Controller.RTouch).magnitude > 0.7) {
            sendMessageScript(getEmotionText() + grabObj + "を投げた。");
            return grabObj + "を投げた。";
        }
        sendMessageScript(getEmotionText() + grabObj + "を置いた。");
        return grabObj + "を置いた。";
    }

    public string eatDrinkNarrative(string grabObj, string grabObjTag) {
        if (grabObjTag == "eat" || grabObjTag == "test") {
            sendMessageScript(getEmotionText() + grabObj + "を食べた。");
            return getEmotionText() + grabObj + "を食べた。";
        }
        if (grabObjTag == "drink") {
            sendMessageScript(getEmotionText() + grabObj + "を飲んだ。");
            return getEmotionText() + grabObj + "を飲んだ。";
        }
        return "";
    }

    public string eatDrinkNarrative_non(string grabObj, string grabObjTag) {
        if (grabObjTag == "eat" || grabObjTag == "test") {
            sendMessageScript(getEmotionText() + grabObj + "を食べた。");
            return grabObj + "を食べた。";
        }
        if (grabObjTag == "drink") {
            sendMessageScript(getEmotionText() + grabObj + "を飲んだ。");
            return grabObj + "を飲んだ。";
        }
        return "";
    }

    public string getObjectNarrative(string grabObj) {
        sendMessageScript(getEmotionText() + grabObj + "を手に入れた。");
        return getEmotionText() + grabObj + "を手に入れた。";
    }

    public string getObjectNarrative_non(string grabObj) {
        sendMessageScript(getEmotionText() + grabObj + "を手に入れた。");
        return grabObj + "を手に入れた。";
    }

    private void sendMessageScript(string message) {
        Debug.Log(message);
        myGameManager.messageShow(message);
    }
}

// enum定義のヘルパクラス
static class EmotionExt {
  // Gender に対する拡張メソッドの定義
    public static string DisplayEmotion(this NarrativeController.EmotionEnum emotion)
    {
        string[] EmoNames = { "楽しそうに", "恐る恐る", "嫌そうに", "悲しみながら", "怒りながら", "驚きながら", "", "興味なさげに" };
        return EmoNames[(int)emotion];
    }
}