using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaTimeTest : MonoBehaviour
{
    // 잘못된 타이머: FixedUpdate가 호출된 '횟수'를 그냥 더한다.
    private float frameCounter = 0;

    // 올바른 타이머: FixedUpdate가 '의미하는 시간'을 더한다.
    private float timeAccumulator = 0;

    // 비교를 위해 실제 흐른 시간도 본다.
    // (Time.time은 게임 시작 후 총 시간을 의미함)

    void FixedUpdate()
    {
        // 1. 잘못된 방식 (단순 횟수 더하기)
        // 0.02초마다 1씩 더한다.
        frameCounter += 1;

        // 2. 올바른 방식 (시간 더하기)
        // 0.02초마다 0.02씩 더한다.
        timeAccumulator += Time.fixedDeltaTime;

        // 1초(50프레임)가 지날 때마다 콘솔에 로그를 찍어보자.
        // frameCounter가 50이 될 때마다 실행됨 (1초마다)
        if (frameCounter % 50 == 0)
        {
            Debug.Log("=====================================");
            Debug.Log($"실제 게임 시간 (Time.time): {Time.time} 초");
            Debug.Log($"[잘못된 계산] frameCounter: {frameCounter}"); // 1초 후 50, 2초 후 100...
            Debug.Log($"[올바른 계산] timeAccumulator: {timeAccumulator}"); // 1초 후 1.0, 2초 후 2.0...
            Debug.Log($"참고용 Time.fixedDeltaTime 값: {Time.fixedDeltaTime}");
        }
    }
}
