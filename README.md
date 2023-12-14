# TSEROF_Code

# 만든 사람들
<a href="https://github.com/dlghdwns97/TSEROF_Code/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=dlghdwns97/TSEROF_Code" />
</a>

# [🤍 팀 노션](https://teamsparta.notion.site/dda40607a8e8402584e29b9b1aaa54b0)

# [🎞 시연 영상](https://youtu.be/1Lm-lpVsmq8)

# 목차

### 1. 게임 개요 및 개발 기간
### 2. 구현 기능
### 3. 기능 명세서
### 4. 사용 에셋

---
<br>
<br>

# 게임 미리보기

---
<br>
<br>

# 1. 게임 개요 및 개발 기간

- **게임명** : `TSEROF`
- **설명** : 3D 플랫포머 게임
- **개요** : 캐릭터를 조작해 숨겨진 아이템을 찾고 스테이지를 클리어하자.
- **게임 방법**
    - [WASD] : 이동
    - [SPACE] : 점프
    - [SPACE] + [SPACE] : 2단 점프
    - [R] : 리스폰
    - [F] : 상호작용 (In Stage 2)
    - [Esc] : 옵션
    - [Tab] : 업적창 (In StageSelect)
- **개발 환경** : Unity 2022.3.2f1
- **타겟 플랫폼** : Microsoft Windows
- **개발 기간** `2023.10.23 ~ 2023.12.15`

---
<br>
<br>

# 2. 구현 기능

## **시작 화면**
- 게임 시작시 실행되는 씬
- 새로하기, 이어하기, 불러오기, 게임 종료 선택지가 있다.

## **스테이지 선택 화면**
- 플레이할 스테이지를 선택하는 씬.
- 새로 시작하면 1스테이지만 열려있으며 스테이지를 클리어 할 시 다음 스테이지가 열리고 진행상황이 저장된다.

## **게임 화면**
- 게임의 최종 목표 (클리어 조건) : 스테이지 끝에 있는 포탈로 들어가기
- 눈에 보이지 않는 공간이나 특정 조작을 통해 갈 수 있는 장소에 있는 숨겨진 아이템을 획득한다. (수집 요소)
- 총 3스테이지가 존재한다.

---
<br>
<br>

# 3. 기능 명세서 (최종 수정중)

<details>
<summary>UML, 기능 정리</summary>

![Json UML](https://github.com/KimEoJin24/TSEROF/assets/73785455/9ac54799-3078-4d6f-8774-aa33c621e336)
![StageSelect UML](https://github.com/KimEoJin24/TSEROF/assets/73785455/8e18c49f-5d53-443c-9d2f-942a19f43b04)
![Player UML](https://github.com/KimEoJin24/TSEROF/assets/73785455/10734b51-ef35-454b-8061-f4721dec3b41)
![Gimmick(정재훈)](https://github.com/KimEoJin24/TSEROF/assets/73785455/1cec1605-e430-4544-94a2-83c063205e93)
![Gimmick(이홍준)](https://github.com/KimEoJin24/TSEROF/assets/73785455/706e2897-272c-4904-884a-c114e43787c3)

</details>

## **매니저**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [GameManager](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Manager/GameManager.cs) | 게임 매니저 |  |
| [SoundManager](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Manager/SoundManager.cs) | 사운드 매니저 |  |

## **시작 화면**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [GameStartBtn](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StartScene/GameStartBtn.cs) | 게임 시작 버튼을 누르면 스테이지 선택 화면을 로드 | 김어진 |
| [ConfirmationPopupMenu](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/StartScene/ConfirmationPopupMenu.cs) | 확인 버튼 메뉴 | 김어진 |
| [MainMenu](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/StartScene/MainMenu.cs) | 메인 메뉴 관리 | 김어진 |
| [Menu](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/StartScene/Menu.cs) |  | 김어진 |
| [SaveSlot](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/StartScene/SaveSlot.cs) | 세이브 슬롯 관리 | 김어진 |
| [SaveSlotsMenu](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/StartScene/SaveSlotsMenu.cs) |  | 김어진 |

## **스테이지 선택 화면**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [BgmController](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageSelect/BgmController.cs) | 배경음악 조절 | 김형중 |
| [MoveSelect](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageSelect/MoveSelect.cs) | 캐릭터 선택 화면 총괄 | 김형중 |
| [OptionBtn](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageSelect/OptionBtn.cs) | 옵션 창 | 김형중 |
| [ChangeSceneManager](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/ChangeScene/ChangeSceneManager.cs) | 스테이지 선택 매니저 | 김형중 |

## **데이터 저장(JSON)**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [DataPersistenceManager](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/Data%20Persistence/DataPersistenceManager.cs) | JSON 데이터 총괄 매니저 | 김어진 |
| [FileDataHandler](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/Data%20Persistence/FileDataHandler.cs) | JSON 데이터 핸들러 | 김어진 |
| [IDataPersistence](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/Data%20Persistence/IDataPersistence.cs) | JSON 데이터 불러오기/저장 관리 | 김어진 |
| [GameData](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/Data/GameData.cs) | JSON 데이터 | 김어진 |
| [GameEventsManager](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/Etc/GameEventsManager.cs) | 게임 이벤트 매니저 | 김어진 |
| [HiddenItemCollected](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/Etc/HiddenItemCollected.cs) | 히든 아이템 수집 관리 | 김어진 |
| [HiddenItem](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/HiddenItems/HiddenItem.cs) | 히든 아이템 | 김어진 |
| [SerializableDictionary](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Json/Serializable%20Types/SerializableDictionary.cs) | 히든 아이템 정보를 저장하는 딕셔너리 | 김어진 |

## **캐릭터**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [Player](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Player/Player.cs) | 플레이어 총괄 | 박지원 |
| [ForceReceiver](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Player/ForceReceiver.cs) | 플레이어 이동 관리 | 박지원 |
| [PlayerInput](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Player/PlayerInput.cs) | 플레이어 이동 가능상태 변경 | 박지원 |
| [Respawn](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Player/Respawn.cs) | 플레이어 리스폰 | 이홍준 |

## **카메라**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [CamChange](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Camera/CamChange.cs) | 스테이지 1 카메라 회전 관리 | 김형중 |
| [FollowCam](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Camera/FollowCam.cs) | 스테이지 1 카메라 접근 관리 | 김형중 |
| [TrackingZone](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Camera/TrackingZone.cs) | 스테이지 1 카메라 이동 루트 관리 | 김형중 |
| [CamPos](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Camera/CamPos.cs) | 스테이지 2 카메라 회전 관리 | 정재훈 |

## **기믹**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [JumpMush](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageObject/JumpMush.cs) | 캐릭터를 점프시키는 점프대 | 이홍준 |
| [PopBlock](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageObject/PopBlock.cs) | 캐릭터를 더 높게 점프시키는 일회용 점프대 | 이홍준 |
| [Log](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageObject/Log.cs) | 캐릭터가 밟으면 잠시 후 떨어지는 발판 | 이홍준 |
| [ChainSpawn](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageObject/ChainSpawn.cs) | 발판을 달아놓을 수 있는 체인 | 이홍준 |
| [SwitchingBlock](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageObject/SwitchingBlock.cs) | 캐릭터의 점프에 반응해서 나타났다가 사라지는 발판 | 이홍준 |
| [BackWind](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageObject/BackWind.cs) | 캐릭터를 뒤로 미는 바람 구역 | 이홍준 |
| [FrontWind](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageObject/FrontWind.cs) | 캐릭터를 앞으로 미는 바람 구역 | 이홍준 |
| [BallCannon](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageObject/BallCannon.cs) | 캐릭터를 앞으로 미는 바람 구역 | 이홍준 |
| [Respawn](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Player/Respawn.cs) | 캐릭터가 데드존에 닿거나 R키를 눌렀을 때 리스폰 | 이홍준 |
| [LogRespawn](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/StageObject/LogRespawn.cs) | 캐릭터가 리스폰 될 때 떨어졌던 발판도 원상복구 | 이홍준 |

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [Cannon](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/Cannon.cs) | 플레이어를 넣고 발사시키는 캐논 | 정재훈 |
| [Hammer](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/Hammer.cs) | 돌아가면서 플레이어를 공격하는 해머 | 정재훈 |
| [Lebu](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/Lebu.cs) | 레버를 이용한 입구 | 정재훈 |
| [LebuMoving](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/LebuMoving.cs) | 레버에 따른 입구 이동통로 생성 | 정재훈 |
| [MovingPlatform](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/MovingPlatform.cs) | 웨이포인트에 따른 이동 발판 | 정재훈 |
| [WaypointPath](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/WaypointPath.cs) | 이동 발판 웨이포인트 지정 | 정재훈 |
| [Obstacles](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/Obstacles.cs) | 각 장애물에 닿았을 때의 반응 | 정재훈 |
| [RotationObstacle](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/RotationObstacle.cs) | 움직이는 회전 장애물 | 정재훈 |
| [SideNeedleTraps](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/SideNeedleTraps.cs) | 지정된 곳에 가시 이동 | 정재훈 |
| [Transparent](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/Transparent.cs) | 투명한 가시벽 설정 | 정재훈 |
| [Transparents](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/Transparents.cs) | 전체적인 가시벽을 관리 | 정재훈 |
| [Tree_Obstacle](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/Tree_Obstacle.cs) | 큰 나무 주변을 회전하는 장애물 | 정재훈 |

---


<br>
<br>

# 4. 사용 에셋

- [KUBIKOS - 3D Cube World](https://assetstore.unity.com/packages/3d/environments/kubikos-3d-cube-world-117341)
- [Fantasy Skybox FREE](https://assetstore.unity.com/packages/2d/textures-materials/sky/fantasy-skybox-free-18353)
