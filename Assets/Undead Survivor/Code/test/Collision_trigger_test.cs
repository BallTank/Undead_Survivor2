using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_trigger_test : MonoBehaviour
{
    // OnCollsionEnter2D: 물리적 충돌이 일어났을 떄
    /*
     * 조건:
     * 1. 양쪽 다 Collider2D가 있어야 함
     * 2. 최소 한쪽에 RidigBody2D가 있어야 함
     * 3. 양쪽 모두 Collider2D의 isTrigger가 해제되어있어야 함.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collsion.gameObject.name: 나와 부딪힌 객체의 이름
        Debug.Log($"==== OnCollisionEnter2D: {collision.gameObject.name}와 충돌");
    }

    // OnTriggerEnter2D: 영역 진입이 감지되었을 때
    /*
     * 조건:
     * 1. 양쪽 다 Collider2D가 있어야 함
     * 2. 최소 한쪽에 RidigBody2D가 있어야 함
     * 3. 둘 중 최소 한쪽의 Collider2D의 isTrigger가 켜저있어야 함.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision.gameOject.name: 내 영역에 들어온 객체의 이름
        Debug.Log($"==== OnTriggerEnter2D: {collision.gameObject.name}이 내영역에 진입");
    }
}
