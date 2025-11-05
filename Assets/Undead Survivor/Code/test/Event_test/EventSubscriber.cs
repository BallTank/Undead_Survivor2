using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    private void OnEnable()
    {
        // 구독한다
        EventPublisher.OnSpacePressed += ReactToSignal;
        Debug.Log("구독 시작");
    }

    private void OnDisable()
    {
        // 구독 해제한다.
        EventPublisher.OnSpacePressed -= ReactToSignal;
        Debug.Log("구독 종료");
    }

    private void ReactToSignal()
    {
        Debug.Log("신호 수신 완료");
    }
}
