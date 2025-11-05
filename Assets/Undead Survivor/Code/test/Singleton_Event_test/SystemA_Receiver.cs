using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemA_Receiver : MonoBehaviour
{
    private void OnEnable()
    {
        // 이벤트 구독: CentralManager의 신호를 듣겠다고 등록
        CentralManager.OnMissionStart += ExecuteMission;
        Debug.Log("OnMissionStart 이벤트 구독 완료.");
    }

    private void OnDisable()
    {
        // 이벤트 해지
        CentralManager.OnMissionStart -= ExecuteMission;
    }

    // 실행될 임무 메서드(직접 호출과 이벤트 구독이 모두 연결되는 메서드)
    public void ExecuteMission()
    {
        Debug.Log("Receiver_A: 임무 실행");
    }

    // 데이터를 반환하는 메서드 (싱글톤 호출의 장점)
    public string GetMissionResult()
    {
        return "완료";
    }
}
