using System.Collections;
using UnityEngine;

public class Meteor : BaseSkill
{
    private string _skillID = "S0009";

    private long _damage;
    private DamageType _damageType;

    [SerializeField] private GameObject projectileSpawnArea;

    [SerializeField] private Vector2 minDestinationPosition;
    [SerializeField] private Vector2 maxDestinationPosition;

    private MeteorProjectile _projectile;
    private Coroutine _atkCor;

    protected override void ApplySkillEffect()
    {
        _atkCor = StartCoroutine(AtkLoop());
        CalculateDamageRatio(_skillID);
        Manager.Game.Player.FinalAttackDamage(out _damage, out _damageType);
    }

    protected override void RemoveSkillEffect()
    {
        StopCoroutine(_atkCor);
        _atkCor = null;
    }

    IEnumerator AtkLoop()
    {
        while (true)
        {
            _projectile = Manager.Address.InstantiatePrefab("MeteorProjectile").GetComponent<MeteorProjectile>();
            _projectile.Damage = (long)(_damage * _skillDamageRatio);
            _projectile.DamageTypeValue = _damageType;

            _projectile.transform.position = new Vector2(0, 5);

            _projectile.TargetPosition = new Vector2(Random.Range(minDestinationPosition.x, maxDestinationPosition.x), Random.Range(minDestinationPosition.y, maxDestinationPosition.y));
            yield return new WaitForSeconds(0.4f);
        }
    }
}
