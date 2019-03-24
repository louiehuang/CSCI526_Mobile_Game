using System;

[Serializable]
public static class PriestConfig {
    //special attrs
    public static float SkillCooldownTime = 5f;

    //level up related bonus
    public static float MaxHPBonus = 15f;
    public static float ATKBonus = 1.5f;
    public static float MATKBonus = 2f;
    public static float PDEFBonus = 1.5f;
    public static float MDEFBonus = 2f;

    //common
    public static int Level = 1;
    public static float Range = 25f;  //heal heros within this range (normal heals)

    public static string CharacterName = "Priest";
    public static string CharacterDescription = "Default Priest Description";

    public static float MaxHPValue = 150f;

    public static float ATKValue = 10f;
    public static float MATKValue = 20f;

    public static float PDEFValue = 10f;
    public static float MDEFValue = 10f;

    public static float CritValue = 0.1f;
    public static float CritDMGValue = 0.2f;

    public static float PernetrationValue = 0f;
    public static float ACCValue = 1f;
    public static float DodgeValue = 0f;
    public static float BlockValue = 0f;
    public static float CritResistanceValue = 0.1f;

    public static float ATKSpeedValue = 0.5f;  // 0.5 attack per second
}