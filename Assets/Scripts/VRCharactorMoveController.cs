using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCharactorMoveController : MonoBehaviour {
    /*
    public float speed = 3.0f;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        Debug.Log(Mathf.Sin(this.transform.rotation.y * Mathf.Deg2Rad) + "  :  " + Mathf.Cos(this.transform.rotation.y * Mathf.Deg2Rad));
        // 左手のアナログスティックの向きを取得
        Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector3 direction = new Vector3(-stickL.y*speed, 0, stickL.x*speed);

        controller.SimpleMove(direction);
    }
    */
    public float speed = 3.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
            moveDirection = new Vector3(-stickL.y * speed, 0, stickL.x * speed);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
