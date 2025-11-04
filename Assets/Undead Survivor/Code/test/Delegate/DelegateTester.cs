using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTester : MonoBehaviour
{
    public Worker worker;

    void Start()
    {
        if (!worker)
        {
            Debug.LogError("Worker가 할당되지 않았습니다.");
            return;
        }

        // Action 델리게이트에 '명령'할당
        worker.onWorkCommand = MakeSound;

        // Func 델리게이트에 '규칙' 할당
        worker.onCalculateBonus = (p) => p * 2;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("TESTER: Worker에게 기본급 100원 주고 일 시킴");
            worker.StartWorking(100);
        }
    }

    void MakeSound()
    {
        Debug.Log("TESTER: (소리) Worker가 일하는 소리");
    }
}
