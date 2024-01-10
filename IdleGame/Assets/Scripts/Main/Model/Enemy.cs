using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Serialize Fields

    [SerializeField] private SpriteRenderer spriteRenderer;

    #endregion

    #region Properties

    public int Attack { get; private set; }
    public int Hp { get; private set; }
    public float AttackRange { get; private set; }
    public float AttackSpeed { get; private set; }

    #endregion

    #region Init

    public void SetEnemy(EnemyBlueprint blueprint)
    {
        // TODO : �� ������ �����ͼ� �ʱ�ȭ
    }

    #endregion
}
