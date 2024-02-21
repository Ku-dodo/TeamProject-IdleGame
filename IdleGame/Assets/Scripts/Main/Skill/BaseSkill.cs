using System.Collections;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    protected float _currentDurateTime;
    public float CurrentDurateTime => _currentDurateTime;


    protected float _currentCoolDown;
    public float CurrentCoolDown => _currentCoolDown;

    protected float _skillDamageRatio;

    private bool _canUse;

    protected Player _player;

    [Header("Skill Time Setter")]
    [SerializeField] private float effectDurateTime;
    public float EffectDurateTime => effectDurateTime;

    [SerializeField] private float coolDown;
    public float CoolDown => coolDown;

    Coroutine _skillDurateTimeCoroutine;
    Coroutine _coolDownCoroutine;

    protected virtual void Start()
    {
        _player = Manager.Game.Player;
        _canUse = false;
        StartCoroutine(CountSkillCooldown());
    }

    protected abstract void ApplySkillEffect();

    protected abstract void RemoveSkillEffect();

    public void UseSkill()
    {
        if (!_canUse)
        {
            return;
        }

        if(Manager.Game.Player.enemyList.Count == 0) 
        {
            return;
        }

        if(Manager.Game.Player.State != PlayerState.Battle)
        {
            return;
        }

        _canUse = false;
        StartCoroutine(CountDurateTime());
    }
    protected float CalculateDamageRatio(string skillID)
    {
        return (Manager.SkillData.SkillDataDictionary[skillID].SkillDamage
            + (Manager.Data.SkillInvenDictionary[skillID].level - 1) + Manager.SkillData.SkillDataDictionary[skillID].ReinforceDamage)
            / 100;
    }

    private IEnumerator CountDurateTime()
    {
        if (_skillDurateTimeCoroutine == null)
        {
            gameObject.GetComponent<BaseSkill>().ApplySkillEffect();
            _currentDurateTime = effectDurateTime;
            while (_currentDurateTime >= 0)
            {
                yield return null;
                _currentDurateTime -= Time.deltaTime;
            }
            _skillDurateTimeCoroutine = null;

            gameObject.GetComponent<BaseSkill>().RemoveSkillEffect();
            StartCoroutine(CountSkillCooldown());
        }
    }


    private IEnumerator CountSkillCooldown()
    {
        if (_coolDownCoroutine == null)
        {
            _currentCoolDown = coolDown;
            while (_currentCoolDown >= 0)
            {
                yield return null;
                _currentCoolDown -= Time.deltaTime;
            }
            _canUse = true;
            _coolDownCoroutine = null;
        }
    }
}
