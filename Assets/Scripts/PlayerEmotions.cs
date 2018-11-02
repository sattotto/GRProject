using Affdex;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEmotions : ImageResultsListener
{
    public float currentJoy;
    public float currentFear;
    public float currentDisgust;
    public float currentSadness;
    public float currentAnger;
    public float currentSurprise;
    public float currentContempt;

    public static float[,] currentEmotionArray = new float[7, 30]; // 0埋めで初期化

    private static int rateCount = 0;

    public FeaturePoint[] featurePointsList;

    public override void onFaceFound(float timestamp, int faceId)
    {
        Debug.Log("Found the face");
    }
    
    public override void onFaceLost(float timestamp, int faceId)
    {
        Debug.Log("Lost the face");
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        Debug.Log("Got face results");

        foreach (KeyValuePair<int, Face> pair in faces)
        {
            int FaceId = pair.Key;  // The Face Unique Id.
            Face face = pair.Value;    // Instance of the face class containing emotions, and facial expression values.

            //Retrieve the Emotions Scores
            face.Emotions.TryGetValue(Emotions.Joy, out currentJoy);
            face.Emotions.TryGetValue(Emotions.Fear, out currentFear);
            face.Emotions.TryGetValue(Emotions.Disgust, out currentDisgust);
            face.Emotions.TryGetValue(Emotions.Sadness, out currentSadness);
            face.Emotions.TryGetValue(Emotions.Anger, out currentAnger);
            face.Emotions.TryGetValue(Emotions.Surprise, out currentSurprise);
            face.Emotions.TryGetValue(Emotions.Contempt, out currentContempt);

            //Retrieve the coordinates of the facial landmarks (face feature points)
            featurePointsList = face.FeaturePoints;
            Debug.Log("hoge");
            setEmotionData(rateCount++);
            if (rateCount == 30) { rateCount = 0; }
        }
    }

    private void setEmotionData(int index)
    {
        currentEmotionArray[0, index] = currentJoy;
        currentEmotionArray[1, index] = currentFear;
        currentEmotionArray[2, index] = currentDisgust;
        currentEmotionArray[3, index] = currentSadness;
        currentEmotionArray[4, index] = currentAnger;
        currentEmotionArray[5, index] = currentSurprise;
        currentEmotionArray[6, index] = currentContempt;
    }

    /// <summary>呼ばれたらどの感情が一番大きく、その数値はいくらだったかを返却します。</summary>
    public static int[] getMaxEmotion()
    {
        int[] returnEmo = new int[2];
        for(int EmoNum = 0; EmoNum < currentEmotionArray.GetLength(0); EmoNum++)
        {
            float sum = 0;
            for (int second = 0;second < 30;second++)
            {
                sum += currentEmotionArray[EmoNum, second];
            }
            if (returnEmo[1] < sum)
            {
                returnEmo[0] = EmoNum;
                returnEmo[1] = (int)sum;
            }
        }
        return returnEmo;
    }
}
