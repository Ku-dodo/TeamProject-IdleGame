// 유저 인게임 스텟 정보
public class StatInfo
{
    private float scaling = 0.001f;

    public string Id;
    public int Level;
    public long BaseValue;
    public long BaseUpgradeCost;

    public long Value;
    public long Modifier;
    public long UpgradeCost;
    public long CostModifier;

    public StatModType ModType;
    public StatApplyType ApplyType;

    public StatInfo(string id, int level, StatModType modType, StatApplyType applyType)
    {
        Id = id;
        Level = level;
        ModType = modType;
        ApplyType = applyType;
    }

    #region Initialize

    public void InfoInit(long baseValue, long baseCost, long statMod, long costMod)
    {
        BaseValue = baseValue;
        BaseUpgradeCost = baseCost;
        Modifier = statMod;
        CostModifier = costMod;

        CalculateLevelStat();
        CalculateLevelCost();
    }

    #endregion

    public void AddModifier()
    {
        Level += 1;
        CalculateLevelStat();
        CalculateLevelCost();
    }

    public float GetFloat()
    {
        return Value / 1000f;
    }

    public string GetString()
    {
        if (ModType == StatModType.Percent)
        {
            float percent = Value / 10f;
            return $"{percent}%";
        }
        else if (ModType == StatModType.DecimalPoint)
        {
            float decimalPoint = Value / 1000f;
            return decimalPoint.ToString();
        }
        else
        { 
            return Utilities.ConvertToString(Value); 
        }
    }

    #region Calculate

    public void CalculateLevelStat()
    {
        Value = BaseValue + Modifier * (Level - 1);

        if (ApplyType == StatApplyType.EnhancedLinear)
        {
            Value += Modifier * ((Level - 1) * (Level - 1) / 100);
        }
    }

    public void CalculateLevelCost()
    {
        if (Level < 101)
        {
            UpgradeCost = (long)(BaseUpgradeCost * CostPow(1 + 60 * scaling, Level - 1));
        }
        else
        {
            UpgradeCost = (long)(BaseUpgradeCost * CostPow(1 + 60 * scaling, 100)
                          * CostPow(1 + CostModifier * scaling, Level - 101));
        }
    }

    public double CostPow(double modifier, int exponent)
    {
        if (exponent <= 0)
            return 1;
        if (exponent == 1)
            return modifier;

        // exponent를 절반으로 나누어 재귀 호출
        double temp = CostPow(modifier, exponent / 2);

        // exponent가 짝수인 경우
        if (exponent % 2 == 0)
            return temp * temp;
        // exponent가 홀수인 경우
        else
            return modifier * (temp * temp);
    }

    #endregion
}
