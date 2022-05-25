using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// LineRenderer를 이용해서 VR 컨트롤러에 레이저포인터 만들기
// 참고 : https://fun-coding-study.tistory.com/9

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser; // 레이저로 쓸 라인렌더러
    private RaycastHit hitObj; // 레이저와 충돌한 물체
    private GameObject curObj; // 가장 최근에 충돌한 객체

    public float raycastDistance = 5f; // 레이저 포인터 감지 거리


    private void Start()
    {
        // LineRenderer 컴포넌트 생성
        layser = this.gameObject.AddComponent<LineRenderer>();

        // Line이 가지게 될 색상
        Material mtrl = new Material(Shader.Find("Standard"));
        mtrl.color = new Color(240, 240, 240, 0.5f);

        // 레이저의 색상, 꼭지점 갯수, 굵기 설정
        layser.material = mtrl;
        layser.positionCount = 2;
        layser.startWidth = 0.005f;
        layser.endWidth = 0.005f;
    }

    private void Update()
    {
        // Start()에서 만든 2개의 점 중 시작점 위치. Update()내부에 만들어 위치가 갱신된다.
        layser.SetPosition(0, transform.position);
        // 설정된 길이로 레이저 그린다.
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.white, 0.5f);

        // 충돌 감지시
        if (Physics.Raycast(transform.position, transform.forward, out hitObj, raycastDistance))
        {
            layser.SetPosition(1, hitObj.point); // 해당 위치까지만 레이저 그린다.

            //curObj = hitObj.collider.gameObject;
            //Debug.Log("curObj = " + curObj);

            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                if (hitObj.collider.gameObject.CompareTag("LockButton"))
                {
                    hitObj.collider.gameObject.GetComponent<LockButton>().OnClick();
                }
            }

        }
        else // 충돌이 감지되지 않는다면,
        {
            // 레이저를 설정된 길이로 바꾼다.
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));
        }
    }

    private void LateUpdate()
    {
        // 오른손 인덱스 버튼 누르면 색 변경
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            layser.material.color = new Color(0, 190, 255, 0.5f);
        }
        // 오른손 인덱스 버튼 놓으면 원래 색으로 돌아옴
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            layser.material.color = new Color(240, 240, 240, 0.5f);
        }
    }
}
