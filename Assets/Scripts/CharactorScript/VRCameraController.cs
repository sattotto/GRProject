using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraController : MonoBehaviour{

    public Transform eye;
    public Transform target;

    void Update()
    {
        if (eye == null || target == null)
        {
            return;
        }

        var diffRot = target.rotation * Quaternion.Inverse(eye.localRotation); // 1
        transform.position = diffRot * (-eye.localPosition) + target.position; // 2
        transform.rotation = diffRot; // 3
    }

}