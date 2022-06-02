using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UMA;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] float mouseSensitivity; // 마우스 감도
    //[SerializeField] float sprintSpeed; // 뛰는 속도
    //[SerializeField] float walkSpeed; // 걷는 속도
    //[SerializeField] float jumpForce; // 점프 힘
    //[SerializeField] float smoothTime; // 뛰기->걷기 바뀌는 가속시간

    //[SerializeField] GameObject cameraHolder; // 카메라
    //float verticalLookRotation; // 위아래 각도 조절할 변수

    //bool grounded; // 점프 가능한 상태인지 체크
    //Vector3 smoothMoveVelocity;
    //Vector3 moveAmount; // 실제 이동거리


    //Rigidbody rb;
    PhotonView PV; // 자기 컨트롤러만 움직이기 위해 사용


    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (!PV.IsMine) // 내꺼가 아닌 카메라, 리지드바디 제거
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            //Destroy(rb);
        }
    }

    /*
    private void Update()
    {
        if (PV.IsMine) // 내꺼일때만 작동
        {
            Look();
            Move();
            Jump();
        }
    }

    // 프레임 기반으로 호출되는 Update()와 달리, Fixed TimeStep에 설정된 값에 따라
    // 일정한 간격으로 호출됨 -> Update보다 규칙적인 호출이어서 충돌검사에 안전함
    private void FixedUpdate()
    {
        if (PV.IsMine)
        {
            // 0.2초마다 계산한 moveAmount만큼 이동
            rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        }
    }


    void Look()
    {
        // 마우스 움직이는 정도 * 민감도만큼 좌우로 고개 돌림
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);

        // 마우스 움직이는 정도 * 민감도만큼 위아래 각도 초기화, -90도 ~ 90도로 각도 제한해서 카메라 돌림
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void Move()
    {
        // 크기를 1로 노말라이즈한 벡터 방향
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        // 쉬프트가 눌렸다면 뛰는속도, 아니라면 걷는속도 -> 3항연산자
        // smoothVelocity 만큼씩??, smoothTime만큼에 걸쳐 이동
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift)
            ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }

    void Jump()
    {
        Debug.Log("Grounded State : " + grounded);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }
    */
}
