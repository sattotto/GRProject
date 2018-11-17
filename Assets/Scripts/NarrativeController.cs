using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour {

    public enum EmotionEnum
    {
        Joy, Fear, Disgust, Sadness, Anger, Surprise, Contempt, None
    }

    static int[] EmotionValue = new int[2];

    public static string getEmotionText() {
        EmotionValue = PlayerEmotions.getMaxEmotion();
        Debug.Log("EmoNum : " + EmotionValue[0] + ", EmoValue : " + EmotionValue[1] + ", Emotion : " + (EmotionEnum)EmotionValue[0]);
        EmotionEnum Emo = (EmotionEnum)EmotionValue[0];
        return Emo.DisplayEmotion();
    }

    public static string getEmotion() {
        EmotionValue = PlayerEmotions.getMaxEmotion();
        Debug.Log("EmoNum : " + EmotionValue[0] + ", EmoValue : " + EmotionValue[1] + ", Emotion : " + (EmotionEnum)EmotionValue[0]);
        EmotionEnum Emo = (EmotionEnum)EmotionValue[0];
        return Emo.ToString();
    }

    public static string GrabNarrative(string targetObj, string grabObj) {
        return getEmotionText() + targetObj + "から、" + grabObj + "を取り出した。";
    }
}

// enum定義のヘルパクラス
static class EmotionExt {
  // Gender に対する拡張メソッドの定義
  public static string DisplayEmotion(this NarrativeController.EmotionEnum emotion)
  {
    string[] EmoNames = { "楽し気に", "恐る恐る", "嫌そうに", "悲しみながら", "怒りながら", "驚きながら", "Contempt", "興味なさげに" };
    return EmoNames[(int)emotion];
  }
}