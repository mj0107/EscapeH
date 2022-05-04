using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockDialButton : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    [SerializeField] GameObject button;

    private void Start()
    {
        button = this.gameObject;
    }

    private void Update()
    {
        // Camera.main을 Player로 조절해줘야할듯? 테스트 필요
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                unityEvent.Invoke();
            }
        }
    }
}
