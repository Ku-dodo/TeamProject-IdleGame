using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillHandler : MonoBehaviour
{
    private Coroutine _autoSkillCoroutine;

    private Dictionary<int, EquipSkillData> _userEquipSkillSlot = new();
    public Dictionary<int, EquipSkillData> UserEquipSkillSlot => _userEquipSkillSlot;


    private event Action<int> _skillUesAction;
    public void AddActionUseSkill(Action<int> skillUesAction)
    {
        _skillUesAction += skillUesAction;
    }
    public void RemoveActionUseSkill(Action<int> skillUesAction)
    {
        _skillUesAction -= skillUesAction;
    }


    private event Action<int> _skillChangeAction;
    public void AddActionChangeSkill(Action<int> skillUesAction)
    {
        _skillChangeAction += skillUesAction;
    }
    public void RemoveActionChangeSkill(Action<int> skillUesAction)
    {
        _skillChangeAction -= skillUesAction;
    }



    private void Start()
    {
        InitSkillSlot();
    }

    private void InitSkillSlot()
    {
        int equipslotIndex = 0;
        foreach (var item in Manager.Data.UserSkillData.UserEquipSkill)
        {
            var go = new GameObject("SkillObj");
            go.transform.parent = transform;
            _userEquipSkillSlot.Add(equipslotIndex, go.AddComponent<EquipSkillData>());
            _userEquipSkillSlot[equipslotIndex].SetSkillObject(Manager.Data.UserSkillData.UserEquipSkill[equipslotIndex].itemID);
            equipslotIndex++;
        }
    }

    public void ChangeEquipSkillData(int slotIndex)
    {
        _userEquipSkillSlot[slotIndex].SetSkillObject(Manager.Data.UserSkillData.UserEquipSkill[slotIndex].itemID);
        _skillChangeAction?.Invoke(slotIndex);
    }

    public bool ToggleAutoSkill(bool state)
    {
        if (state)
        {
            StopCoroutine(_autoSkillCoroutine);
            return false;
        }
        else
        {
            _autoSkillCoroutine = StartCoroutine(UseSkillLoop());
            return true;
        }
    }

    IEnumerator UseSkillLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < _userEquipSkillSlot.Count; i++)
            {
                if (_userEquipSkillSlot[i].SkillScript != null)
                {
                    _userEquipSkillSlot[i].SkillScript.UseSkill();
                    _skillUesAction?.Invoke(i);
                }
            }
        }
    }
}

public class EquipSkillData : MonoBehaviour
{
    public GameObject SkillObject { get; private set; }
    public BaseSkill SkillScript { get; private set; }
    public string SkillID {  get; private set; }
    public void SetSkillObject(string itemID)
    {
        SkillID = itemID;

        if (itemID == "Empty")
        {
            if (SkillObject != null)
            {
                Destroy(SkillObject);
                SkillScript = null;
            }
            return;
        }

        //슬롯에 스킬이 있으나 이미 프로퍼티가 설정되어 있는 경우 초기화
        if (SkillObject != null)
        {
            Destroy(SkillObject);
            SkillScript = null;
        }
        //프로퍼티를 설정함
        SkillObject = Manager.Resource.InstantiatePrefab((Manager.Resource.GetBlueprint(itemID) as SkillBlueprint).SkillObject.name, Manager.Game.Player.transform);
        SkillObject.transform.parent = transform;
        SkillScript = SkillObject.GetComponent<BaseSkill>();
    }
}
