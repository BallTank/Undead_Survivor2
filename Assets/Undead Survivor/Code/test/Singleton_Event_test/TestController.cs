using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    void Update()
    {
        // P: 싱글톤 직접 호출 테스트
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("======================================");
            Debug.Log("P키 입력. 싱글톤 직접 호출 시도.");

            // 직접호출: TestController는 CentralManager를 알고
            // CenterManger가 Receiver의 존재를 알아서 명령을 내린다.
            CentralManager.instance.CallReceiverDirectly();

            // 싱글톤의 장점: 데이터 반환을 즉시 확인할 수 있다.
            Debug.Log($"Manager에게서 받은 임무 상태: {CentralManager.instance.missionStatus}");
            Debug.Log("======================================");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("======================================");
            Debug.Log("E키 입력. 이벤트 발송 시도.");
            CentralManager.instance.SignalMissionStart();
            Debug.Log("신호만 보내고 누가 들었는지 모름");
            Debug.Log("======================================");
        }
    }
}
