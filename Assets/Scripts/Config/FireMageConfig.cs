using System;

[Serializable]
public static class FireMageConfig {
    //special attrs
    public static float SkillCooldownTime = 5f;
    public static float Radius = 8f;  //explosion radius

    //level up related bonus (set in IceMageConfig)

    //common
    public static int Level = 1;
    public static float Range = 30f;

    public static string CharacterName = "Fire";
    public static string CharacterDescription = "Default Fire Mage Description";

    public static float MaxHPValue = 100f;

    public static float ATKValue = 2f;
    public static float MATKValue = 25f;

    public static float PDEFValue = 10f;
    public static float MDEFValue = 10f;

    public static float CritValue = 0.1f;
    public static float CritDMGValue = 0.2f;

    public static float PernetrationValue = 0f;
    public static float ACCValue = 1f;
    public static float DodgeValue = 0f;
    public static float BlockValue = 0f;
    public static float CritResistanceValue = 0.1f;

    public static float ATKSpeedValue = 2f;  // 2 attacks per second
}