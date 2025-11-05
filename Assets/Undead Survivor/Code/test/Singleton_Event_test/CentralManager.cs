using System;
using UnityEngine;

public class CentralManager : MonoBehaviour
{
    // 싱글톤
    public static CentralManager instance;

    // 강한 참조: 이벤트가 아닌, 직접 호출용으로 Receiver_A를 참조
    [Header("1. 싱글톤 직접 참조용")]
    public SystemA_Receiver receiverA;
    public string missionStatus = "미정";

    // 이벤트: 느슨한 결합 통신용 신호탄
    public static event Action OnMissionStart;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 싱글톤으로 호출될 메서드
    public void CallReceiverDirectly()
    {
        Debug.Log("Receiver_A에게 임무를 직접 할당합니다.");

        // 강한 결합: Manager는 Receiver_A의 존재와 ExecuteMission() 메서드를 알고 있다.
        receiverA.ExecuteMission();

        // 데이터 반환 요구 (싱글톤의 장점)
        missionStatus = receiverA.GetMissionResult();
    }

    // 이벤트 발송 메서드
    public void SignalMissionStart()
    {
        Debug.Log("임무 시작 신호탄(Event)를 발사합니다.");

        // 느슨한 결합: 누가 듣는지 모른다. 그냥 신호만 보낸다.
        OnMissionStart?.Invoke();
    }
}
