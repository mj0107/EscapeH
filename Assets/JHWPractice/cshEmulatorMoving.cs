using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshEmulatorMoving : MonoBehaviour
{
    
    float mSpeed = 2.0f;

    private Quaternion mCharacterTargetRot;
    private Quaternion mCameraTargetRot;
    public Transform mPlayerCamera;

    Animator anim;

    void Start()
    {
        mCharacterTargetRot = transform.localRotation;
        mCameraTargetRot = mPlayerCamera.transform.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        anim = GetComponent<Animator>();
    }

 
    void Update()
    {
        float xRot = Input.GetAxis("Mouse Y");
        float yRot = Input.GetAxis("Mouse X");

        mCharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        transform.localRotation = mCharacterTargetRot;

        mCameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);
        mPlayerCamera.transform.localRotation = mCameraTargetRot;

        float vmv = Input.GetAxis("Vertical");
        float hmv = Input.GetAxis("Horizontal");

        Vector2 mInput = new Vector2(hmv, vmv);

        if(mInput.x >= 0.1 || mInput.y >= 0.1)
        {
            anim.SetFloat("Speed", 0.75f);
        }
        else
        {
            anim.SetFloat("Speed", 0.0f);
        }

        Vector3 desireMove = transform.forward * 1 * mInput.y +
            transform.right * 1 * mInput.x;
        transform.position += desireMove * mSpeed * Time.deltaTime;
       



    }
}
