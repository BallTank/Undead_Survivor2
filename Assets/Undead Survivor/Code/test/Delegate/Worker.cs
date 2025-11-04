using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    // Action 델리게이트변수 반환 값이 없는 '명령'을 담는 변수
    public Action onWorkCommand;

    // Func 델리게이트 변수 반환값이 있는 '규칙'을 담는 변수
    // onCalculateBonus(int) {return int}
    public Func<int, int> onCalculateBonus;
 
    public void StartWorking(int basePay)
    {
        Debug.Log("WORKER: 명령을 수행합니다.");

        onWorkCommand?.Invoke();

        Debug.Log($"WORKER: '기본급'{basePay}원으로 '규칙'을 계산합니다.");

        // onCalculateBonus에 할당된 '규칙'이 있다면 호출
        // null이면 ?? 뒤의 0을 사용
        int bonus = onCalculateBonus?.Invoke(basePay) ?? 0;

        int finalPay = basePay + bonus;
        Debug.Log($"WORKER: 보너스 {bonus}원 받음. 최종급여: {finalPay}원");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
