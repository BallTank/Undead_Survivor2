# Undead Survivor

Unity 기반 2D 탑다운 생존 액션 프로젝트입니다.  
짧은 러닝타임(5분) 안에 이동, 자동 전투, 성장 선택을 반복하며 생존하는 게임 루프를 구현했습니다.

## 프로젝트 개요

- 프로젝트명: `Undead Survivor`
- 장르: 2D 탑다운 서바이벌
- 엔진: `Unity 2021.3.45f1`
- 언어: `C#`
- 주요 패키지: `Input System`, `Cinemachine`, `URP`, `UGUI`
- 개발 형태: 개인 포트폴리오 (클라이언트 중심 구현)

## 내가 구현한 핵심 내용

1. 기본 게임 루프 설계
- `GameManager`에서 게임 시작/종료/승리 상태를 통합 관리했습니다.
- 제한 시간 5분(`maxGameTime`) 생존 시 승리, HP 0 이하 시 패배로 상태 전환됩니다.
- 레벨/경험치/킬 수/UI 표시를 한 흐름으로 연결했습니다.

2. 전투 시스템 (자동 타겟팅 + 무기 타입 분리)
- `Scanner`에서 `CircleCastAll`로 주변 적을 탐지하고 최근접 타겟을 선택합니다.
- `Weapon`을 근접/원거리 타입으로 분기해 회전형 무기와 투사체 발사 로직을 분리했습니다.
- `Bullet` 충돌 처리에서 관통 횟수(pierce)와 반환 타이밍을 제어했습니다.

3. 성장/빌드 시스템
- `ItemData(ScriptableObject)` 기반 데이터 드리븐 구조로 아이템 스펙을 관리했습니다.
- 레벨업 시 3개 랜덤 선택지를 제시하고, 최대 레벨 아이템은 소비형 보상으로 대체합니다.
- `Gear`는 플레이어 이벤트(`OnApplyGear`)를 구독해 무기/이동 수치를 동기화합니다.

4. 성능 최적화
- `PoolManager`로 `Enemy / Shovel / Bullet` 풀을 분리해 Instantiate/Destroy 호출을 줄였습니다.
- `Reposition`으로 바닥 타일과 적 재배치를 처리해 무한 스테이지처럼 동작하도록 구성했습니다.

5. 캐릭터 차별화/해금
- 캐릭터별 스탯 보정(이동속도, 공격력, 회전/공속)을 `Character`에서 관리합니다.
- `AchieveManager` + `PlayerPrefs`로 해금 상태를 저장하고 세션 간 유지되도록 구현했습니다.

## 기술 포인트

- 싱글턴 기반 매니저 (`GameManager`, `AudioManager`)로 전역 상태 접근 단순화
- 이벤트 기반 결합도 완화 (`Player.OnApplyGear`)
- 데이터 중심 설계 (`ScriptableObject` 아이템 정의)
- 풀링 기반 런타임 성능 관리

## 실행 방법

1. Unity Hub에서 `2021.3.45f1` 에디터를 설치합니다.
2. 프로젝트 루트(`Undead_Survivor2`)를 엽니다.
3. `Assets/Scene0000.unity` 씬을 실행합니다.


## 폴더 구조 (요약)

```text
Assets/
  Undead Survivor/
    Code/        # 핵심 게임플레이 스크립트
    Data/        # 아이템/밸런스 데이터 에셋
    Prefabs/     # 플레이어/적/무기 프리팹
    Sprites/     # 2D 리소스
```


