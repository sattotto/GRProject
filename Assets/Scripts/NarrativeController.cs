using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour {

    enum EmotionEnum
    {
        Joy,
        Fear,
        Disgust,
        Sadness,
        Anger,
        Surprise,
        Contempt
    }

    static int[] EmotionValue = new int[2];

    public static string getEmotion()
    {
        EmotionValue = PlayerEmotions.getMaxEmotion();
        Debug.Log("EmoNum : " + EmotionValue[0] + ", EmoValue : " + EmotionValue[1] + ", Emotion : " + (EmotionEnum)EmotionValue[0]);
        EmotionEnum hoge = (EmotionEnum)EmotionValue[0];
        return hoge.ToString();
    }

    public static string GrabNarrative(string targetObj, string grabObj) {
        return getEmotion() + "な顔をして," + targetObj + "から、" + grabObj + "を取り出した";
    }
}
