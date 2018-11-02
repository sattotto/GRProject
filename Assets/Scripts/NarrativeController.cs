using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour {

    enum EmotionEnum: int
    {
        Joy = 0, Fear, Disgust, Sadness, Anger, Surprise, Contempt
    }

    private static int[] EmotionValue = new int[2];

    public static void getEmotion()
    {
        EmotionValue = PlayerEmotions.getMaxEmotion();
        Debug.Log("EmoNum : " + EmotionValue[0] + ", EmoValue : " + EmotionValue[1]);
    }

    public static string GrabNarrative(string targetObj, string grabObj) {
        return targetObj + "から、" + grabObj + "を取り出した";
    }
}
