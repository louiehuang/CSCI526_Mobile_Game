using System;

[Serializable]
public static class IceMageConfig {
    //special attrs
    public static float SkillCooldownTime = 5f;
    public static float SlowAmount = 0.5f;

    //level up related bonus
    public static float MaxHPBonus = 10f;
    public static float ATKBonus = 1f;
    public static float MATKBonus = 3f;
    public static float PDEFBonus = 1f;
    public static float MDEFBonus = 2f;

    //common base value
    public static int Level = 1;
    public static float Range = 30f;

    public static string CharacterName = "Ice";
    public static string CharacterDescription = "Default Description";

    public static float MaxHPValue = 100f;

    public static float ATKValue = 10f;
    public static float MATKValue = 32f;

    public static float PDEFValue = 10f;
    public static float MDEFValue = 10f;

    public static float CritValue = 0.1f;
    public static float CritDMGValue = 0.2f;

    public static float PernetrationValue = 0f;
    public static float ACCValue = 1f;
    public static float DodgeValue = 0f;
    public static float BlockValue = 0f;
    public static float CritResistanceValue = 0.1f;

    public static float ATKSpeedValue = 1f;  // 1 attack per second
}