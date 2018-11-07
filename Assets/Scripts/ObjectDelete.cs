using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour {

    private GameObject PlayerTarget;

    void Start() {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update () {
        float dist = Vector3.Distance(PlayerTarget.transform.position, transform.position);
        if (dist > 10.0f)
        {
            Destroy(gameObject);
        }
    }
}
