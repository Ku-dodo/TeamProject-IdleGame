using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIUseSkillSlots : MonoBehaviour
{
    [SerializeField] private Image ImgSkillIcon;
    [SerializeField] private Image ImgDurate;
    [SerializeField] private Image ImgCoolDown;
    private EquipSkillData _equipSkillData;

    private Button _skillBtn;

    private void Awake()
    {
        _skillBtn = GetComponent<Button>();
    }

    public void SetUISkillSlot(EquipSkillData equipSkillData)
    {
        _equipSkillData = equipSkillData;
        ImgDurate.fillAmount = 0;
        ImgCoolDown.fillAmount = 0;
        StopAllCoroutines();
        _skillBtn.onClick.RemoveAllListeners();

        if (_equipSkillData.SkillID == "Empty")
        {
            ImgSkillIcon.gameObject.SetActive(false);
            return;
        }
        else
        {
            ImgSkillIcon.sprite = Manager.Data.SkillDataDictionary[_equipSkillData.SkillID].Sprite;
            ImgSkillIcon.gameObject.SetActive(true);
            StartCoroutine(SetUICoolDown());
        }

        _skillBtn.onClick.AddListener(_equipSkillData.SkillScript.UseSkill);
        _skillBtn.onClick.AddListener(SetUIUseSkill);
    }

    public void SetUIUseSkill()
    {
        StartCoroutine(SetUIDurateTime());
    }

    IEnumerator SetUIDurateTime()
    {
        do
        {
            yield return new WaitForSeconds(0.1f);
            ImgDurate.fillAmount = _equipSkillData.SkillScript.CurrentDurateTime / _equipSkillData.SkillScript.EffectDurateTime;
        } while (_equipSkillData.SkillScript.CurrentDurateTime > Mathf.Epsilon);

        ImgDurate.fillAmount = 0f;
        StartCoroutine(SetUICoolDown());
    }

    IEnumerator SetUICoolDown()
    {
        do
        {
            yield return new WaitForSeconds(0.1f);
            ImgCoolDown.fillAmount = _equipSkillData.SkillScript.CurrentCoolDown / _equipSkillData.SkillScript.CoolDown;
        } while (_equipSkillData.SkillScript.CurrentCoolDown > Mathf.Epsilon);

        ImgCoolDown.fillAmount = 0f;
    }
}
