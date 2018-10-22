using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour {

    public static string GrabNarrative(string targetObj, string grabObj) {
        return targetObj + "から、" + grabObj + "を取り出した";
    }
}
