using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshOVRPlayerMove : MonoBehaviour
{
    float mSpeed = 6.0f;

    private Quaternion mCharacterTargetRot;
    private Quaternion mCameraTargetRot;
    public Transform mPlayerCamera;

    Animator mAnim;
    // Start is called before the first frame update
    void Start()
    {
        mCharacterTargetRot = transform.localRotation;
        mCameraTargetRot = mPlayerCamera.transform.localRotation;

        mAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        /*
         * 오큘러스에서 제공하는 OVRCameraRig는 찾아본 결과,
         * 해당 카메라가 바라보는 방향을 찾아낼 수 없다.
         */

        //1. 첫 번째 캐릭터 회전 방법
        //HMD가 바라보는 좌표가 Mouse의 좌표를 따라와 준다는 가정하에
        float xRot = Input.GetAxis("Mouse Y");
        float yRot = Input.GetAxis("Mouse X");

        mCharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        mCharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        transform.localRotation = mCharacterTargetRot;

        mCameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);
        mPlayerCamera.transform.localRotation = mCameraTargetRot;

        transform.localRotation = mPlayerCamera.localRotation;

        //2. 1번의 방법이 안될 경우 밑에 주석 한 줄 제거, 1번 제거
        //transform.localRotation = mPlayerCamera.localRotation;


        //3. 1,2번 방법이 둘 다 안될 경우 캐릭터의 이동을 Teleport로
        //만드는게 어떨지..


        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            if(coord.x >= 0.1 || coord.y >= 0.1)
            {
                mAnim.SetFloat("Speed", 0.75f);
            }
            else
            {
                mAnim.SetFloat("Speed", 0.0f);
            }


            Vector3 desireMove = transform.forward * coord.y +
                transform.right * coord.x;
            transform.position += desireMove * mSpeed * Time.deltaTime;
        }
        

    }
}
