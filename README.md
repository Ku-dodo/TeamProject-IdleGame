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

- [Team Brochure](https://teamsparta.notion.site/9c278f934a6e4a89a3760f864d683992)
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

## 인게임 이미지

<img src="https://private-user-images.githubusercontent.com/105593231/317803316-6b2445b4-452f-4691-b56a-59fff8151715.gif?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MTE2NDMzMjAsIm5iZiI6MTcxMTY0MzAyMCwicGF0aCI6Ii8xMDU1OTMyMzEvMzE3ODAzMzE2LTZiMjQ0NWI0LTQ1MmYtNDY5MS1iNTZhLTU5ZmZmODE1MTcxNS5naWY_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwMzI4JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDMyOFQxNjIzNDBaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT1kMmVlNzYxMmIxNjY1OGQxMTIzOTVhN2Y1ZTJkMjQ2ZTk0ZWE4NmE5ZDgxZDQ5ZDljM2UyNGY4ZTc2OWEwY2E0JlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.RiWFOEeLL7LNac_xUiiqHPF67SAqouK2jRHkUuLSvGo" width="30%"><img src="https://private-user-images.githubusercontent.com/105593231/317803283-ab876f9d-e63a-4ff0-bf92-ab7473cfafd8.gif?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MTE2NDMzMjAsIm5iZiI6MTcxMTY0MzAyMCwicGF0aCI6Ii8xMDU1OTMyMzEvMzE3ODAzMjgzLWFiODc2ZjlkLWU2M2EtNGZmMC1iZjkyLWFiNzQ3M2NmYWZkOC5naWY_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwMzI4JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDMyOFQxNjIzNDBaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT00YjU1MGQ4NWVmNzI0NGEyNzdmNjNiNGZkZWU4ZjY3N2YzOGUzNDc1ZGI3NTQ0YjQ3ZjgyNTQ4NmIxZjkzNWIyJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.oC33uj5amgCz5oLvC0aj6GRQF2J3pJ7GLHnTgZ0EBcQ" width="30%"><img src="https://private-user-images.githubusercontent.com/105593231/317803347-71cc80c6-5bc4-4bc1-8e51-1b927681251b.gif?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MTE2NDMzMjAsIm5iZiI6MTcxMTY0MzAyMCwicGF0aCI6Ii8xMDU1OTMyMzEvMzE3ODAzMzQ3LTcxY2M4MGM2LTViYzQtNGJjMS04ZTUxLTFiOTI3NjgxMjUxYi5naWY_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwMzI4JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDMyOFQxNjIzNDBaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT03ZWYxMzhjMGI5YzBjYjZlM2EwM2RlMjdhYzI1ZWEyNWQwYjAwYmQ3OGJiMDdlMDczYmVjZWZmMmFkMjBkNGZmJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.m5yFIioRdpP-vCCID87cZ0BbEnDJIQOrkblJmisR8a0" width="30%">
