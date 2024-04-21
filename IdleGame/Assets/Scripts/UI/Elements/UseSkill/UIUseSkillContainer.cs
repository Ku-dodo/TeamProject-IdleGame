using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUseSkillContainer : MonoBehaviour
{
    private List<UIUseSkillSlots> _slots = new();
    private PlayerSkillHandler _playerSkillHandler;

    private void Start()
    {
        _playerSkillHandler = Manager.Game.Player.GetComponent<PlayerSkillHandler>();

        for (int i = 0; i < gameObject.GetComponentsInChildren<UIUseSkillSlots>().Length; i++)
        {
            _slots.Add(gameObject.GetComponentsInChildren<UIUseSkillSlots>()[i]);
            _slots[i].SetUISkillSlot(_playerSkillHandler.UserEquipSkillSlot[i]);
        }
        _playerSkillHandler.AddActionChangeSkill(SetSkillUI);
        _playerSkillHandler.AddActionUseSkill(SetSkillCoverUI);
    }

    public void SetSkillUI(int index)
    {
        _slots[index].SetUISkillSlot(_playerSkillHandler.UserEquipSkillSlot[index]);
    }

    public void SetSkillCoverUI(int index)
    {
        _slots[index].SetUIUseSkill();
    }

    private void OnDestroy()
    {
        if(_playerSkillHandler != null)
        {
            _playerSkillHandler.RemoveActionChangeSkill(SetSkillUI);
            _playerSkillHandler.RemoveActionUseSkill(SetSkillCoverUI);
        }
    }
}
