using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 유니티 이벤트에 파라미터를 넣기 위한 부분
// 참고 : https://wergia.tistory.com/243
[System.Serializable]
public class UnityEventButton : UnityEvent<char, int>
{

}

public class LockButton : MonoBehaviour
{
    public UnityEventButton unityEvent;

    [SerializeField] GameObject button;

    [SerializeField] char direction; // {U, D, L, R} -> 다이얼이 돌아갈 방향
    [SerializeField] int procedure; // {0, 1, 2, 3} -> n번째 다이얼



    /*
    private void Update()
    {
        // Camera.main을 Player로 조절해줘야할듯? 테스트 필요
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                unityEvent.Invoke(direction, procedure);
            }
        }
    }
    */

    public void OnClick()
    {
        unityEvent.Invoke(direction, procedure);
    }
}


