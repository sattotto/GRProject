using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCharactorMoveController : MonoBehaviour {

    public float speed = 3.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 2000.0F;
    private Vector3 moveDirection = Vector3.zero;

    private const float ANGLE_LIMIT_UP = 60f;
    private const float ANGLE_LIMIT_DOWN = -60f;

    private TextWriter myTextWriter;
    private GrabController myGrabController;

    void Start () {
        myTextWriter = new TextWriter();
        myGrabController = GameObject.Find("GameManager").GetComponent<GrabController>();
    }  
    void Update() {
        MoveController();
        VisionController();
    }

    // 食べる、飲むなどの処理
    void OnTriggerEnter(Collider other) {
        if (myGrabController.rightHandObjectGrabing() && myGrabController.rightHandObject == other.gameObject && (other.gameObject.tag == "eat" || other.gameObject.tag == "drink" || other.gameObject.tag == "test")) {
            myGrabController.myTextWriter.writeText(GameObject.Find("GameManager").GetComponent<NarrativeController>().eatDrinkNarrative(other.gameObject.name, other.gameObject.tag));
            myGrabController.myTextWriter.writeText_non(GameObject.Find("GameManager").GetComponent<NarrativeController>().eatDrinkNarrative_non(other.gameObject.name, other.gameObject.tag));
            int count = PlayerPrefs.GetInt("eat",0) + 1;
			PlayerPrefs.SetInt("eat",count);
            GameObject.Find("GameManager").GetComponent<GameManager>().gameEnd("eat");
            myGrabController.rightHandObject = null;
			Destroy(other.gameObject); // myGrabController.rightHandObject
        }
        if (myGrabController.leftHandObjectGrabing() && myGrabController.leftHandObject == other.gameObject && (other.gameObject.tag == "eat" || other.gameObject.tag == "drink" || other.gameObject.tag == "test")) {
            myGrabController.myTextWriter.writeText(GameObject.Find("GameManager").GetComponent<NarrativeController>().eatDrinkNarrative(other.gameObject.name, other.gameObject.tag));
            myGrabController.myTextWriter.writeText_non(GameObject.Find("GameManager").GetComponent<NarrativeController>().eatDrinkNarrative_non(other.gameObject.name, other.gameObject.tag));
            int count = PlayerPrefs.GetInt("eat",0) + 1;
			PlayerPrefs.SetInt("eat",count);
            GameObject.Find("GameManager").GetComponent<GameManager>().gameEnd("eat");
            myGrabController.leftHandObject = null;
			Destroy(other.gameObject); // myGrabController.rightHandObject
        }
    }

    private void MoveController() {
        // 左手のアナログスティックの向きを取得
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
            moveDirection = new Vector3(stickL.x * speed, 0, stickL.y * speed);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void VisionController() {
        // 右手のアナログスティックの向きを取得
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        this.transform.eulerAngles += new Vector3(stickR.y, stickR.x, 0);

        float angle_x = 180f <= transform.eulerAngles.x ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angle_x, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.eulerAngles.y,
            0
        );
    }
}
