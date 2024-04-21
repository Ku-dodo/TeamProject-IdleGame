## 🖥️ 용력 사무소

+ [소개 영상](https://www.youtube.com/watch?v=AbceaCXGerw)

## 📆 Develop Schedule

* 24.01.10 ~ 24.03.08

## ⚙️ Environment

- `Unity 2022.3.15`
- **IDE** : Visual Studio 2022
- **VCS** : Git (GitHub Desktop)
- **Envrionment** : Android

## 📌 Develop Link

- [Team Brochure](https://evening-chord-d32.notion.site/48cb378fe23d4b2cb75316d979209550?pvs=4)
- [Team Notion](https://www.notion.so/68656b3df2a3484695ce7d5b89b83b9d)

## 담당 영역

|**대분류**|**기능**|**설명**|
|:-:|:-:|-|
|`플레이`|Enemy Frame|SO를 이용해 다양한 몬스터를 구현할 수 있도록 하였습니다.|
|`플레이`|플레이어, 적 발사체와 상호작용|발사체 상위 클래스와 데미지 인터페이스를 통해 플레이어와 적의 상호작용을 구현 하였습니다.|
|`플레이`|플레이어 애니메이션 컨트롤 및 상태|HashSet을 이용한 애니메이션 컨트롤을 구현 하였습니다.|
|`플레이`|장비, 스킬 UI 및 기능|유저가 UI를 통해 장비, 스킬에 상호작용할 수 있도록 UI를 구성하고, 장착, 해제, 교체, 강화 등의 기능을 구현 하였습니다.|
|`플레이`|스킬 15종 구현|BaseSkill 추상 클래스를 이용하여 플레이어가 사용할 수 있는 15종의 스킬을 구현하였습니다.|
|`데이터`|JSON, SO 데이터|유저 데이터는 JSON, 아이템 이름, 기본 공격력과 같이 정적으로 참고되는 데이터는 SO에 담아 저장하였습니다.|
|`편의성`|컨텐츠 알림 UI|유저가 장비 등의 팝업에서 어떤 행동을 할 수 있는지에 대해 알림을 주는 노티마크 UI를 구현 하였습니다.|
|`편의성`|시스템 팝업, 메시지 UI|유저가 제한된 행동을 했을때, 시각적으로 피드백을 주기 위해 팝업형, 플로팅 텍스트형 시스템 메시지를 구현 하였습니다.|
|`편의성`|수치 단순화|1,000 단위로 A > B > C 단위를 붙여 수치를 출력하는 기능을 구현하였습니다.|

## 인게임 미리보기

<img src="https://file.notion.so/f/f/8f3c0d2f-fe29-4d8d-b883-11d50d4210d8/3ca815d7-1c52-4328-b2f3-8efb48d3324f/%EC%A0%84%ED%88%AC.gif?id=b8675189-592b-4033-a8fc-d706717bbe7b&table=block&spaceId=8f3c0d2f-fe29-4d8d-b883-11d50d4210d8&expirationTimestamp=1713830400000&signature=QuLnfytfbfm2withYlTXw2wO50sYLWdkbnM31aKQ9ws" width="30%">   <img src="https://file.notion.so/f/f/8f3c0d2f-fe29-4d8d-b883-11d50d4210d8/a41c25d6-76d8-43ab-aa11-52619d685d24/%EB%B3%B4%EC%8A%A4.gif?id=c93c9f8b-7c80-4c34-8a38-ff6f5b911d0e&table=block&spaceId=8f3c0d2f-fe29-4d8d-b883-11d50d4210d8&expirationTimestamp=1713830400000&signature=JZfRyr1pmtv_1CL1Z8ALPZs1j1Cvg0Wdlr96LUu9EQg" width="30%">   <img src="https://file.notion.so/f/f/8f3c0d2f-fe29-4d8d-b883-11d50d4210d8/ec9598ab-dd30-4efc-9fe0-e7801d1895a4/%EB%BD%91%EA%B8%B0.gif?id=8715c450-7c45-41dd-b3c0-8dbfc082409b&table=block&spaceId=8f3c0d2f-fe29-4d8d-b883-11d50d4210d8&expirationTimestamp=1713830400000&signature=oSSQY4Ffl0PlGDYiP66IpLTKS_ZMYfZ9oVP-YFIQ210" width="30%">
