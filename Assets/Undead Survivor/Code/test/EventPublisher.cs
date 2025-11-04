using System;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    public static event Action OnSpacePressed;  // 전역 연락망 선언
    void Update()
    {
        // 스페이스바를 누르면 신호를 쏜다
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("스페이스바 눌림. 신호 발송");

            // 구독자가 없으면 null호출
            OnSpacePressed?.Invoke();

            Debug.Log("스페이스바 눌림. 신호 끝!");
        }
    }
}
