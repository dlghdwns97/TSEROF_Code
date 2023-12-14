# TSEROF_Code

# 만든 사람들


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
![StartScene](https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/f3ceaa59-3157-4c13-91f0-4132d8e93e0f)
![StageSelectGIF](https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/357a6c6c-fc8b-4b5e-8638-fc987386b585)
![Stage3](https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/94c871c7-06c4-464c-a24e-fba756980607)

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
- **개발 환경** : ![Unity_Logo](https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/a53ce756-54c2-44d7-870c-71637721bb2f) 2022.3.2f1
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

# 3. 기능 명세서

<details>
<summary>UML, 기능 정리</summary>

#### 클라이언트 구조
<img width="1000" alt="어진이와_아이들_(2)" src="https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/064d53e4-f6ff-4b3e-b92c-6ce5fdf6596a">

#### JSON
![Untitled](https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/35f9aa2a-85c8-45c9-a4db-edcc2e458789)

#### 스테이지 관리
<img width="1000" alt="어진이와_아이들_(3)" src="https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/3182fc8c-3fa6-4227-b8b9-fd398cc5f4db">

#### 플레이어
![Untitled (1)](https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/88c687d6-285b-4044-a282-988cb3b34639)

#### 기믹
![Untitled (2)](https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/5a8e1a38-98ea-4857-b238-3e43e15446b3)
![Untitled (3)](https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/3f59170e-fc00-41c5-8119-0cb554f73d27)
![stage3uml](https://github.com/dlghdwns97/TSEROF_Code/assets/73785455/904bf4b7-7fec-45a0-90de-ae5189fcff0e)
</details>

## **매니저**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [GameManager](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Manager/GameManager.cs) | 게임 매니저 | 김형중 |
| [SoundManager](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Manager/SoundManager.cs) | 사운드 매니저 | 김형중 |
| [Stage2Manager](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Manager/Stage2Manager.cs) | Stage 2 관리 | 정재훈, 박지원 |
| [StartStoryUI](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Manager/StartStoryUI.cs) | 스토리 관리 | 김형중 |
| [GimmickForObject](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/GimmickForObject.cs) | Stage 3 관리 | 이홍준 |
| [EndingController](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Manager/EndingController.cs) | 전체 스테이지 클리어 및 엔딩씬 관리 | 박지원, 정재훈 |

## **Scene 변경 관련**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [AsyncLoading](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/ChangeScene/AsyncLoading.cs) | 로딩창 | 김어진 |
| [ChangeSceneManager](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/ChangeScene/ChangeSceneManager.cs) | 스테이지 선택 매니저 | 김형중 |
| [Stage1ClearCutScene](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/ChangeScene/Stage1ClearCutScene.cs) | 스테이지 1 클리어 화면 | 김어진 |

## **시작 화면**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [ConfirmationPopupMenu](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/StartScene/ConfirmationPopupMenu.cs) | 확인 버튼 메뉴 | 김어진 |
| [MainMenu](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/StartScene/MainMenu.cs) | 메인 메뉴 관리 | 김어진 |
| [Menu](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/StartScene/Menu.cs) | 메뉴 버튼 강조 | 김어진 |
| [SaveSlot](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/StartScene/SaveSlot.cs) | 세이브 슬롯 관리 | 김어진 |
| [SaveSlotsMenu](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/StartScene/SaveSlotsMenu.cs) | 세이브 슬롯 메뉴 | 김어진 |

## **스테이지 선택 화면**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [BgmController](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/StageSelect/BgmController.cs) | 배경음악 조절 | 김형중 |
| [MoveSelect](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/StageSelect/MoveSelect.cs) | 캐릭터 선택 화면 총괄 | 김형중 |
| [OptionMenu](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/StageSelect/OptionMenu.cs) | 옵션 창 | 김형중 |

## **데이터 저장(JSON)**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [DataPersistenceManager](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/DataPersistence/DataPersistenceManager.cs) | JSON 데이터 총괄 매니저 | 김어진 |
| [FileDataHandler](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/DataPersistence/FileDataHandler.cs) | JSON 데이터 핸들러 | 김어진 |
| [IDataPersistence](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/DataPersistence/IDataPersistence.cs) | JSON 데이터 불러오기/저장 관리 | 김어진 |
| [GameData](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/Data/GameData.cs) | JSON 데이터 | 김어진 |
| [HiddenItem](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/HiddenItems/HiddenItem.cs) | 히든 아이템 관리 | 김어진 |
| [SerializableDictionary](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/HiddenItems/SerializableTypes/SerializableDictionary.cs) | 히든 아이템 정보를 저장하는 딕셔너리 | 김어진 |
| [PuzzleParticle](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Json/HiddenItems/PuzzleParticle.cs) | 스테이지 별 퍼즐 파티클 | 김형중 |

## **캐릭터**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [Player](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Player/Player.cs) | 플레이어 총괄 | 박지원 |
| [ForceReceiver](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Player/ForceReceiver.cs) | 플레이어 점프 및 상태 관리 | 박지원 |
| [PlayerInput](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Player/PlayerInput.cs) | 플레이어 이동 가능상태 변경 | 박지원 |
| [Respawn](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Player/Respawn.cs) | 플레이어 리스폰 | 이홍준 |
| [RunSFX](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Player/RunSFX.cs) | 지형별 발걸음 소리 | 김형중 |
| [TopViewPlayer](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Player/TopViewPlayer.cs) | 탑뷰에서의 플레이어 | 박지원 |
| [JumpEffect](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Player/JumpEffect/JumpEffect.cs) | 점프 효과 | 김형중 |
| [ObjectPoolJump](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Player/JumpEffect/ObjectPoolJump.cs) | 점프 효과에 필요한 오브젝트 풀링 | 김형중 |

## **카메라**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [CamChange](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Camera/CamChange.cs) | 스테이지 1 카메라 회전 관리 | 김형중 |
| [FollowCam](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Camera/FollowCam.cs) | 스테이지 1 카메라 접근 관리 | 김형중 |
| [TrackingZone](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Camera/TrackingZone.cs) | 스테이지 1 카메라 이동 루트 관리 | 김형중 |
| [CamPos](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Camera/CamPos.cs) | 스테이지 2 카메라 회전 관리 | 정재훈 |

## **기믹**

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [JumpMush](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage1/JumpMush.cs) | 캐릭터를 점프시키는 점프대 | 이홍준 |
| [Log](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage1/Log.cs) | 캐릭터가 밟으면 잠시 후 떨어지는 발판 | 이홍준 |
| [LogChild](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage1/LogChild.cs) | Log 오브젝트에 신호 전달 | 이홍준 |
| [Obstacles](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage1/Obstacles.cs) | 캐릭터가 닿으면 밀쳐버리는 토네이도 | 정재훈, 박지원 |

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [CubeType](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/CubeType.cs) | 큐브 블록 속성 | 정재훈 |
| [FallingObject](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/FallingObject.cs) | 떨어지는 고드름 | 정재훈 |
| [FireTrap](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/FireTrap.cs) | 화염을 뿜는 트랩 | 박지원, 정재훈 |
| [Hammer](https://github.com/KimEoJin24/TSEROF/blob/main/TSEROF/Assets/Scripts/Gimmick/Hammer.cs) | 돌아가면서 플레이어를 공격하는 해머 | 정재훈 |
| [LaserPatternManager](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/LaserPatternManager.cs) | 레이저 패턴을 관리하는 매니저 | 박지원 |
| [LaserReceiver](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/LaserReceiver.cs) | 레이저 수신부 | 박지원 |
| [LaserTransmitter](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/LaserTransmitter.cs) | 레이저 발신부 | 박지원 |
| [Leaf](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/Leaf.cs) | 나뭇잎 발판 | 박지원 |
| [Lebu](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/Lebu.cs) | 레버를 이용한 입구 | 정재훈, 박지원 |
| [LebuMoving](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/LebuMoving.cs) | 레버에 따른 입구 이동통로 생성 | 정재훈 |
| [MovingPlatform](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/MovingPlatform.cs) | 웨이포인트에 따른 이동 발판 | 정재훈, 박지원 |
| [WaypointPath](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/WaypointPath.cs) | 이동 발판 웨이포인트 지정 | 정재훈 |
| [NeedleTrap](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/NeedleTrap.cs) | 가시 트랩 | 박지원 |
| [RotationCube](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/RotationCube.cs) | 큐브 움직임 | 정재훈 |
| [RotationObstacle](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/RotationObstacle.cs) | 움직이는 회전 장애물 | 정재훈 |
| [SideNeedleTraps](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/SideNeedleTraps.cs) | 지정된 곳에 가시 이동 | 정재훈 |
| [Transparent](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/Transparent.cs) | 투명한 가시벽 설정 | 정재훈 |
| [Transparents](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/Transparents.cs) | 전체적인 가시벽을 관리 | 정재훈, 박지원 |
| [TransparentObject](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage2/TransparentObject.cs) | 닿으면 드러나는 투명한 오브젝트 | 박지원, 정재훈 |

| 스크립트 | 내용 | 기여자 |
| -- | -- | -- |
| [Wind](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage3/Wind/Wind.cs) | 캐릭터를 특정 방향으로 밀어내는 바람 구역 | 이홍준 |
| [PopBlock](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage3/PopBlock.cs) | 캐릭터를 더 높게 점프시키는 일회용 점프대 | 이홍준 |
| [BallCannon](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage3/BallCannons/BallCannon.cs) | 지정한 위치로 공을 쏘는 캐논 | 이홍준 |
| [ChangeBtnColor](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage3/LinePlatform/ChangeBtnColor.cs) | 발판을 움직이는 버튼의 시각적 효과 | 이홍준 |
| [PlatformRespawn](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage3/LinePlatform/PlatformRespawn.cs) | 리스폰 될 때 발판 위치를 제자리로 | 이홍준 |
| [PressBtn](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage3/LinePlatform/PressBtn.cs) | 버튼으로 움직이는 발판 | 이홍준 |
| [PillarX](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage3/PillarX.cs) | X축으로 움직이는 기둥 | 이홍준 |
| [PillarZ](https://github.com/dlghdwns97/TSEROF_Code/blob/main/Scripts/Gimmick/Stage3/PillarZ.cs) | Z축으로 움직이는 기둥 | 이홍준 |

---


<br>
<br>

# 4. 사용 에셋

- [KUBIKOS - 3D Cube World](https://assetstore.unity.com/packages/3d/environments/kubikos-3d-cube-world-117341)
- [Fantasy Skybox FREE](https://assetstore.unity.com/packages/2d/textures-materials/sky/fantasy-skybox-free-18353)
- [Interactive Physical Door Pack](https://assetstore.unity.com/packages/tools/physics/interactive-physical-door-pack-163249)
- [Forest - Low Poly Toon Battle Arena / Tower Defense Pack](https://assetstore.unity.com/packages/3d/environments/forest-low-poly-toon-battle-arena-tower-defense-pack-100080)
- [URP Stylized Water Shader - Proto Series](https://assetstore.unity.com/packages/vfx/shaders/urp-stylized-water-shader-proto-series-187485)
- [Fantasy Wooden GUI : Free](https://assetstore.unity.com/packages/2d/gui/fantasy-wooden-gui-free-103811)
- [3D The Blacksmith's House](https://assetstore.unity.com/packages/3d/environments/fantasy/3d-the-blacksmith-s-house-252972)
- [Magic Effects FREE](https://assetstore.unity.com/packages/vfx/particles/spells/magic-effects-free-247933)
- [The Portal Collection](https://assetstore.unity.com/packages/3d/environments/fantasy/the-portal-collection-205438)
- [Epic Toon VFX 2](https://assetstore.unity.com/packages/vfx/particles/spells/epic-toon-vfx-2-157651)
- [Nature Sound FX](https://assetstore.unity.com/packages/audio/sound-fx/nature-sound-fx-180413)
- [Toon Fantasy Nature](https://assetstore.unity.com/packages/3d/environments/landscapes/toon-fantasy-nature-215197)
