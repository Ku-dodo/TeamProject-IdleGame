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
[개인 코드 레포지토리](https://github.com/Ku-dodo/TeamProject-IdleGame-PersonalCode)
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

<img src="https://private-user-images.githubusercontent.com/105593231/325212357-9c85d06c-a457-40a2-af48-5b08ef8070d0.gif?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MTM5NjA4NDMsIm5iZiI6MTcxMzk2MDU0MywicGF0aCI6Ii8xMDU1OTMyMzEvMzI1MjEyMzU3LTljODVkMDZjLWE0NTctNDBhMi1hZjQ4LTViMDhlZjgwNzBkMC5naWY_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwNDI0JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDQyNFQxMjA5MDNaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT05ZDIyNGMzYzMxNzExYjJmZDM3NWFkZWQyNzM3MzFlNTg0ZjgzYWEyM2RhNzI0ODk4NzgyZDg1NGIzMThkNDA5JlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.H04INR376mKLZK9NGGNvzfXGicbm349fiqLbilxUWuw" width="30%">   <img src="https://private-user-images.githubusercontent.com/105593231/325209158-0bbced27-f6fc-444b-8e62-d233daac8ec2.gif?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MTM5NjEwMzAsIm5iZiI6MTcxMzk2MDczMCwicGF0aCI6Ii8xMDU1OTMyMzEvMzI1MjA5MTU4LTBiYmNlZDI3LWY2ZmMtNDQ0Yi04ZTYyLWQyMzNkYWFjOGVjMi5naWY_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwNDI0JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDQyNFQxMjEyMTBaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT03ZGY3MWE4MmU1MjUzZDVmZjhmOTM0YmE4YWRhNjE1N2JjNjNiOGVkNTA5MzNiMzhlMTgwYWYxMDM1NTE4NzlkJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.7mdDjGGdVq1LkKe9Xz10RfpHDEp3lThKZv2IiYHr0Tc" width="30%"> <img src="https://private-user-images.githubusercontent.com/105593231/325209167-448aa4b9-1faf-454f-aed6-c85baf57c2ce.gif?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MTM5NjEwMzAsIm5iZiI6MTcxMzk2MDczMCwicGF0aCI6Ii8xMDU1OTMyMzEvMzI1MjA5MTY3LTQ0OGFhNGI5LTFmYWYtNDU0Zi1hZWQ2LWM4NWJhZjU3YzJjZS5naWY_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwNDI0JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDQyNFQxMjEyMTBaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT1hNTU5MTdlYTU4ZjVhODdiODNlZTY5MWVjODRjNTcwNmI5MzVlMjRmZDM2N2IxNDVlY2YzZTgxZGVjNmUzMDcyJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.VazTT7PDHynh_z2yXicR-hqip4i91nY2mkfUzmXkDy0" width="30%">
