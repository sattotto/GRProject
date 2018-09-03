using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCharactorMoveController : MonoBehaviour {

    public float speed = 3.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    private const float ANGLE_LIMIT_UP = 60f;
    private const float ANGLE_LIMIT_DOWN = -60f;

    void Update()
    {
        MoveController();
        VisionController();
    }

    private void MoveController()
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

    private void VisionController()
    {
        // 右手のアナログスティックの向きを取得
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        this.transform.eulerAngles += new Vector3(0, stickR.x, stickR.y);

        float angle_z = 180f <= transform.eulerAngles.z ? transform.eulerAngles.z - 360 : transform.eulerAngles.z;
        Debug.Log(angle_z);
        transform.eulerAngles = new Vector3(
            0,
            transform.eulerAngles.y,
            Mathf.Clamp(angle_z, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP)
        );
    }
}
