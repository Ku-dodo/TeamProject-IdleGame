using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class SummonManager
{
    #region Fields

    private Player _player;
    private DataManager _dataManager;
    private FollowerDataManager _followerDataManager;
    private UISubSceneShopSummon _shopSummon;

    private List<int> summonResurt = new(200);
    private List<string> resultIdList = new(200);
    
    private Coroutine _repeatCoroutine;

    // 확인용
    private int[] testResult;
    private string[] itemIndex;
    private Dictionary<string, int> indexResult = new();

    #endregion

    #region Properties

    public bool SummonRepeatCheck => _repeatCoroutine != null;

    #endregion

    #region Initialize

    public void SetSummon()
    {
        _player = Manager.Game.Player;
        _dataManager = Manager.Data;
    }

    public void Initialize()
    {
        _summonConfig = Manager.Asset.GetBlueprint("SummonConfig") as SummonConfig;

        foreach (var list in _summonConfig.SummonLists)
        {
            TableInitalize(list);
        }
    }

    public void SetShopPopup(UISubSceneShopSummon uIPopupShopSummon)
    {
        _shopSummon = uIPopupShopSummon;
    }

    #endregion

    #region Summon

    public bool SummonTry(int addcount, string tableLink, UIBtn_Check_Gems btnUI)
    {
        switch (btnUI.ButtonInfo.ResourceType)
        {
            case ResourceType.Gold:
                if (_player.IsTradeGold(btnUI.ButtonInfo.Amount))
                {
                    btnUI.ApplyRestriction();
                    if (btnUI.ButtonInfo.OnEvent)
                    {
                        SummonTables.TryGetValue(tableLink, out var summonTable);
                        summonTable.ApplySummonCountAdd();
                    }

                    Summon(btnUI.ButtonInfo.SummonCount + addcount, tableLink);
                    return true;
                }
                break;

            case ResourceType.Gems:
                if (_player.IsTradeGems(btnUI.ButtonInfo.Amount))
                {
                    btnUI.ApplyRestriction();
                    if (btnUI.ButtonInfo.OnEvent)
                    {
                        SummonTables.TryGetValue(tableLink, out var summonTable);
                        summonTable.ApplySummonCountAdd();
                    }

                    Summon(btnUI.ButtonInfo.SummonCount + addcount, tableLink);
                    return true;
                }
                break;
        }

        return false;
    }

    private void Summon(int count, string typeLink)
    {
        // 현재 소환된 팝업이 존재할 경우 => 제거
        Manager.UI.CloseCurrentSummonPopup();

        // 횟수만큼 랜덤값 뽑아서 배열로 만들고 리스트 비우기, 소환 횟수 증가
        for (int i = 0; i < count; i++)
        {
            summonResurt.Add(Random.Range(0, 1000000));
        }

        int[] summonResultValue = summonResurt.ToArray();
        summonResurt.Clear();

        // 소환 레벨에서 딕셔너리 키(누적 확률)만 뽑은 후 랜덤값보다 높은 숫자 중 가장 가까운 키를 찾아 인덱스 반환
        SummonTables.TryGetValue(typeLink, out var summonTable);
        var curLevelTable = summonTable.GetProbabilityTable();
        var curprobability = curLevelTable.Select(x => x.Key).ToArray();

        // 테스트 결과 확인용 배열 세팅
        //testResult = new int[curLevelTable.Count];
        //itemIndex = curLevelTable.Select(x => x.Value).ToArray();

        //for (int i = 0; i < itemIndex.Length; i++)
        //{
        //    indexResult[itemIndex[i]] = i;
        //}

        int idx = 0; // 배열 인덱스

        while (count > 0)
        {
            int getResultKey = curprobability.OrderBy(x => (summonResultValue[idx] - x >= 0)).First(); // 나중에 이진 탐색으로 줄여봅시다
            curLevelTable.TryGetValue(getResultKey, out string index);
            //Debug.Log($"idx : {idx}, summonResultValue : {summonResultValue[idx]}, getResultKey : {getResultKey}, index : {index}");       
            resultIdList.Add(index);
            
            // 확인용 획득 수 카운트 증가
            //indexResult.TryGetValue(index, out int result);
            //testResult[result]++;
            count--;
            idx++;
            if (summonTable.ApplySummonCount())
            {
                // 이거 trygetvalue 다시 안해도 될듯 나중에 확인
                SummonTables.TryGetValue(typeLink, out var newSummonTable);
                curLevelTable = newSummonTable.GetProbabilityTable();
                curprobability = curLevelTable.Select(x => x.Key).ToArray();
            }
        }
        // 디버그용 테이블 체크하기
        //int[] getResultKeyArr = curLevelTable.Select(x => x.Key).ToArray();
        //string txtsum = string.Empty;
        //foreach (var item in getResultKeyArr)
        //{
        //    curLevelTable.TryGetValue(item, out int index);
        //    txtsum += $"{index}, ";
        //}
        //Debug.Log(txtsum);

        //TestDebugLog();

        // 최종 획득한 아이템 목록 배열 출력 후 인벤토리에 넣고 팝업 실행
        string[] finalResult = resultIdList.ToArray();
        // TODO : typeLink에 따라 item Add하는 메소드 다르게 연결
        switch (typeLink)
        {
            case "Equipment":
                EquipmentAdd(finalResult);
                break;
            case "Skills":
                SkillAdd(finalResult);
                break;
            case "Follower":
                FollowerAdd(finalResult);
                break;
        }
        
        var popup = Manager.UI.ShowSummonPopup<UIPopupRewardsSummon>("UIPopupRewardsSummon");
        popup.DataInit(typeLink, finalResult);
        popup.PlayStart();
        popup.SummonButtonInit(summonTable.SummonList);
        _shopSummon.BannerUpdate(typeLink, summonTable.SummonCountsAdd);
        summonResurt.Clear();
        resultIdList.Clear();

        Manager.Notificate.SetPlayerStateNoti();

        // Data Save
        Manager.Data.Save();
    }

    private void EquipmentAdd(string[] summonResult)
    {
        for (int i = 0; i < summonResult.Length; i++)
        {
            UserItemData itemData = _dataManager.SearchItem(summonResult[i]);
            itemData.hasCount++;
        }
    }

    private void FollowerAdd(string[] summonResult)
    {
        for (int i = 0; i < summonResult.Length; i++)
        {
            UserInvenFollowerData followerData = Manager.FollowerData.SearchFollower(summonResult[i]);
            followerData.hasCount++;
        }
    }

    private void SkillAdd(string[] summonResult)
    {
        for (int i = 0; i < summonResult.Length; i++)
        {
            UserInvenSkillData skillData = Manager.Data.SearchSkill(summonResult[i]);
            skillData.hasCount++;
        }
    }
    #endregion

    #region Summon Repeat

    public void SetSummonRepeat(string tableLink, UIBtn_Check_Gems btnUI)
    {
        _repeatCoroutine = CoroutineHelper.StartCoroutine(SummonRepeat(tableLink, btnUI));
    }

    public void StopSummonRepeat()
    {
        CoroutineHelper.StopCoroutine(_repeatCoroutine);
        _repeatCoroutine = null;
    }

    private IEnumerator SummonRepeat(string tableLink, UIBtn_Check_Gems btnUI)
    {
        while (true)
        {
            if (!SummonTry(0, tableLink, btnUI))
            {
                _repeatCoroutine = null;
                Manager.UI.CurrentSummonPopup.NotEnoughResource();
                yield break;
            }

            yield return new WaitUntil(() => Manager.UI.CurrentSummonPopup.IsSkip);
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }

    #endregion

    #region Debug Method

    private void TestDebugLog()
    {
        Debug.Log($"{itemIndex.Length}, {testResult.Length}");
        Debug.Log($"{itemIndex[0]} : {testResult[0]}, {itemIndex[1]} : {testResult[1]}, {itemIndex[2]} : {testResult[2]}, {itemIndex[3]} : {testResult[3]}, {itemIndex[4]} : {testResult[4]}, {itemIndex[5]} : {testResult[5]}");
        for (int i = 0; i < testResult.Length; i++)
        {
            testResult[i] = 0;
        }
    }

    #endregion
}


